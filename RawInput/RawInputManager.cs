using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RawInput
{
    public class RawInputManager:NativeWindow
    {
        static RawKeyBoard keyBoardDriver;
        public VKey[] HotKeys
        {
            set
            {
                int[] keys = new int[value.Length];
                for (int i = 0; i < value.Length;i++ )
                {
                    keys[i] = (int)value[i];
                }
                keyBoardDriver.hotkeys = keys;
            }
            get
            {
                VKey[] keys = new VKey[keyBoardDriver.hotkeys.Length];
                for (int i = 0; i < keyBoardDriver.hotkeys.Length; i++)
                {
                    keys[i] = (VKey)keyBoardDriver.hotkeys[i];
                }
                return keys;
            }
        }
        public event RawKeyBoard.DeviceHotKeyEventHandler OnHotKeyPressed
        {
             add { keyBoardDriver.OnHotKeyPressed += value; }
            remove { keyBoardDriver.OnHotKeyPressed -= value;}
        }
        public event RawKeyBoard.DeviceEventHandler OnKeyPressed
        {
            add { keyBoardDriver.KeyPressed += value; }
            remove { keyBoardDriver.KeyPressed -= value; }
        }
        readonly IntPtr devNotifyHandle;
        static readonly Guid DeviceInterfaceHid = new Guid("4D1E55B2-F16F-11CF-88CB-001111000030");
        private PreMessageFilter filter;
         public int NumberOfKeyboards
        {
            get { return keyBoardDriver.NumberOfKeyboards; } 
        }
        
        public void AddMessageFilter()
        {
            if (null != filter) return;
            
            filter = new PreMessageFilter();
            Application.AddMessageFilter(filter);
        }

        private void RemoveMessageFilter()
        {
            if (null == filter) return;

            Application.RemoveMessageFilter(filter);
        }

        public RawInputManager(IntPtr parentHandle, bool captureOnlyInForeground)
        {
            AssignHandle(parentHandle);

            keyBoardDriver = new RawKeyBoard(parentHandle, captureOnlyInForeground);
            keyBoardDriver.EnumerateDevices();
            devNotifyHandle = RegisterForDeviceNotifications(parentHandle);
        }
        static IntPtr usbNotifyHandle = IntPtr.Zero;
        static IntPtr RegisterForDeviceNotifications(IntPtr parent)
        {
            usbNotifyHandle = IntPtr.Zero;
            var bdi = new BroadcastDeviceInterface();
            bdi.DbccSize = Marshal.SizeOf(bdi);
            bdi.BroadcastDeviceType = BroadcastDeviceType.DBT_DEVTYP_DEVICEINTERFACE;
            bdi.DbccClassguid = DeviceInterfaceHid;

            var mem = IntPtr.Zero;
            try
            {
                mem = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(BroadcastDeviceInterface)));
                Marshal.StructureToPtr(bdi, mem, false);
                usbNotifyHandle = Win32API.RegisterDeviceNotification(parent, mem, DeviceNotificationFlags.DEVICE_NOTIFY_WINDOW_HANDLE);
            }
            catch (Exception e)
            {
                //Debug.Print("Registration for device notifications Failed. Error: {0}", Marshal.GetLastWin32Error());
                //System.Diagnostics.Debug.WriteLine(
                Debug.Print(e.StackTrace);
            }
            finally
            {
                Marshal.FreeHGlobal(mem);
            }

            if (usbNotifyHandle == IntPtr.Zero)
            {
                //Debug.Print("Registration for device notifications Failed. Error: {0}", Marshal.GetLastWin32Error());
            }
            
            return usbNotifyHandle;
        }
        ~RawInputManager()
        {
            Win32API.UnregisterDeviceNotification(usbNotifyHandle);
        }
        protected override void WndProc(ref Message message)
        {
            switch (message.Msg)        
            {
                case WinMessage.WM_INPUT:
                    {
                        keyBoardDriver.ProcessRawInput(message.LParam);
                    }
                    break;

                case WinMessage.WM_USB_DEVICECHANGE:
                    {
                        keyBoardDriver.EnumerateDevices();
                    }
                    break;
            }

            base.WndProc(ref message);
        }
    }
}
