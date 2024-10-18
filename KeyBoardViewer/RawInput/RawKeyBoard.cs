using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RawInput
{
    public class RawKeyEventArg : EventArgs
    {
        public KeyPressEvent KeyPressEvent { get; private set; }
        public RawKeyEventArg(KeyPressEvent arg)
        {
            KeyPressEvent = arg;
        }
    }
    public class RawHotKeyEventArg : EventArgs
    {
        public HotKeyPressEvent HotKeyPressEvent { get; private set; }
        public RawHotKeyEventArg(HotKeyPressEvent arg)
        {
            HotKeyPressEvent = arg;
        }
    }

    public sealed class RawKeyBoard
    {
        private readonly Dictionary<IntPtr, KeyPressEvent> deviceList = new Dictionary<IntPtr, KeyPressEvent>();
        private readonly object padLock = new object();
        public delegate void DeviceEventHandler(object sender, RawKeyEventArg e);
        public delegate void DeviceHotKeyEventHandler(object sender, RawHotKeyEventArg e);
        public event DeviceEventHandler KeyPressed;
        private HotKeyPressEvent hotkeyPressEvent = new HotKeyPressEvent();
        public event DeviceHotKeyEventHandler OnHotKeyPressed;
        internal int[] hotkeys
        {
            set
            {
                if (value != null)
                    hotkeyPressEvent.HotKeys = value;
            }
            get{
                return hotkeyPressEvent.HotKeys;
            }
        }
        public int NumberOfKeyboards { get; private set; }
        static InputData _rawBuffer;
        public RawKeyBoard(IntPtr hwnd, bool captureOnlyInForeground)
        {
            var rid = new RawInputDevice[1];

            rid[0].usUsagePage = HidUsagePage.GENERIC;
            rid[0].usUsage = HidUsage.Keyboard;
            rid[0].dwFlags = (captureOnlyInForeground ? RawInputDeviceFlags.UNDEFINE : RawInputDeviceFlags.RIDEV_INPUTSINK) | RawInputDeviceFlags.RIDEV_DEVNOTIFY;
            rid[0].hwndTarget = hwnd;

            if (!Win32API.RegisterRawInputDevices(rid, (uint)rid.Length, (uint)Marshal.SizeOf(rid[0])))
            {
                throw new ApplicationException("注册设备失败");
            }
        }
        public void EnumerateDevices()
        {
            lock (padLock)
            {
                deviceList.Clear();

                var keyboardNumber = 0;

                var globalDevice = new KeyPressEvent
                {
                    DeviceName = "Global Keyboard",
                    DeviceHandle = IntPtr.Zero,
                    DeviceType = Win32API.GetDeviceType(DeviceType.RimTypeKeyboard),
                    Name = "Fake Keyboard. Some keys (ZOOM, MUTE, VOLUMEUP, VOLUMEDOWN) are sent to rawinput with a handle of zero.",
                    Source = keyboardNumber++.ToString(CultureInfo.InvariantCulture)
                };

                deviceList.Add(globalDevice.DeviceHandle, globalDevice);

                var numberOfDevices = 0;
                uint deviceCount = 0;
                var dwSize = (Marshal.SizeOf(typeof(RAWINPUTDEVICELIST)));

                if (Win32API.GetRawInputDeviceList(IntPtr.Zero, ref deviceCount, (uint)dwSize) == 0)
                {
                    var pRawInputDeviceList = Marshal.AllocHGlobal((int)(dwSize * deviceCount));
                    Win32API.GetRawInputDeviceList(pRawInputDeviceList, ref deviceCount, (uint)dwSize);

                    for (var i = 0; i < deviceCount; i++)
                    {
                        uint pcbSize = 0;
                        var rid = (RAWINPUTDEVICELIST)Marshal.PtrToStructure(new IntPtr((pRawInputDeviceList.ToInt64() + (dwSize * i))), typeof(RAWINPUTDEVICELIST));

                        Win32API.GetRawInputDeviceInfo(rid.hwnDevice, RawInputDeviceInfo.RIDI_DEVICENAME, IntPtr.Zero, ref pcbSize);

                        if (pcbSize <= 0) continue;

                        var pData = Marshal.AllocHGlobal((int)pcbSize);
                        Win32API.GetRawInputDeviceInfo(rid.hwnDevice, RawInputDeviceInfo.RIDI_DEVICENAME, pData, ref pcbSize);
                        var deviceName = Marshal.PtrToStringAnsi(pData);

                        if (rid.dwType == DeviceType.RimTypeKeyboard || rid.dwType == DeviceType.RimTypeHid)
                        {
                            var deviceDesc = Win32API.GetDeviceDescription(deviceName);

                            var dInfo = new KeyPressEvent
                            {
                                DeviceName = Marshal.PtrToStringAnsi(pData),
                                DeviceHandle = rid.hwnDevice,
                                DeviceType = Win32API.GetDeviceType(rid.dwType),
                                Name = deviceDesc,
                                Source = keyboardNumber++.ToString(CultureInfo.InvariantCulture)
                            };

                            if (!deviceList.ContainsKey(rid.hwnDevice))
                            {
                                numberOfDevices++;
                                deviceList.Add(rid.hwnDevice, dInfo);
                            }
                        }

                        Marshal.FreeHGlobal(pData);
                    }

                    Marshal.FreeHGlobal(pRawInputDeviceList);

                    NumberOfKeyboards = numberOfDevices;
                    return;
                }
            }

            throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        public int ProcessRawInput(IntPtr hdevice)
        {
            if (deviceList.Count == 0) return 0;

            var dwSize = 0;
            Win32API.GetRawInputData(hdevice, RawInputDataCommand.RID_INPUT, IntPtr.Zero, ref dwSize, Marshal.SizeOf(typeof(Rawinputheader)));

            if (dwSize != Win32API.GetRawInputData(hdevice, RawInputDataCommand.RID_INPUT, out _rawBuffer, ref dwSize, Marshal.SizeOf(typeof(Rawinputheader))))
            {
                //Error getting the rawinput buffer
                return 1;
            }

            int virtualKey = _rawBuffer.data.keyboard.VKey;
            int makeCode = _rawBuffer.data.keyboard.Makecode;
            int flags = _rawBuffer.data.keyboard.Flags;

            if (virtualKey == WinMessage.KEYBOARD_OVERRUN_MAKE_CODE) return 0;

            var isE0BitSet = ((flags & WinMessage.RI_KEY_E0) != 0);

            KeyPressEvent keyPressEvent;

            if (deviceList.ContainsKey(_rawBuffer.header.hDevice))
            {
                lock (padLock)
                {
                    keyPressEvent = deviceList[_rawBuffer.header.hDevice];
                }
            }
            else
            {

                //Handle: was not in the device list.
                return 2;
            }

            var isBreakBitSet = ((flags & WinMessage.RI_KEY_BREAK) != 0);
            keyPressEvent.KeyPressState = isBreakBitSet;
            keyPressEvent.Message = _rawBuffer.data.keyboard.Message;
            keyPressEvent.VKey = VirtualKeyCorrection(virtualKey, isE0BitSet, makeCode);
            //keyPressEvent.VKey = virtualKey;
            if (KeyPressed != null)
            {
                hotkeyPressEvent.CheckKey(keyPressEvent);
                KeyPressed(this, new RawKeyEventArg(keyPressEvent));
            }
            if(hotkeyPressEvent.hotActived)
            {
                OnHotKeyPressed(this, new RawHotKeyEventArg(hotkeyPressEvent));
            }
            return 0;
        }
        private static int VirtualKeyCorrection(int virtualKey, bool isE0BitSet, int makeCode)
        {
            var correctedVKey = virtualKey;

            if (_rawBuffer.header.hDevice == IntPtr.Zero)
            {
                // When hDevice is 0 and the vkey is VK_CONTROL indicates the ZOOM key
                if (_rawBuffer.data.keyboard.VKey == WinMessage.VK_CONTROL)
                {
                    correctedVKey = WinMessage.VK_ZOOM;
                }
            }
            else
            {
                switch (virtualKey)
                {
                    // Right-hand CTRL and ALT have their e0 bit set 
                    case WinMessage.VK_CONTROL:
                        correctedVKey = isE0BitSet ? WinMessage.VK_RCONTROL : WinMessage.VK_LCONTROL;
                        break;
                    case WinMessage.VK_MENU:
                        correctedVKey = isE0BitSet ? WinMessage.VK_RMENU : WinMessage.VK_LMENU;
                        break;
                    case WinMessage.VK_SHIFT:
                        correctedVKey = makeCode == WinMessage.SC_SHIFT_R ? WinMessage.VK_RSHIFT : WinMessage.VK_LSHIFT;
                        break;
                    default:
                        correctedVKey = virtualKey;
                        break;
                }
            }
            return correctedVKey;
        }

    }
}
