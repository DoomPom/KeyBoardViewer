using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RawInput
{
    //参考文档
    //Raw Input：https://msdn.microsoft.com/en-us/library/ms645536(VS.85).aspx
    //RAWINPUTDEVICE structure：https://msdn.microsoft.com/en-us/library/ms645565(v=vs.85).aspx
    //HID USB UsageTable：http://www.usb.org/developers/hidpage/Hut1_12v2.pdf


    //常用usUsagePage和usUsage值表（更多请参考UsageTable链接）

    //usUsagePage值
    //1 for generic desktop controls
    //2 for simulation controls
    //3 for vr
    //4 for sport
    //5 for game
    //6 for generic device
    //7 for keyboard
    //8 for leds
    //9 button

    //usUsage值（当usUsagePage为1时）
    //0 - undefined
    //1 - pointer
    //2 - mouse
    //3 - reserved
    //4 - joystick
    //5 - game pad
    //6 - keyboard
    //7 - keypad
    //8 - multi-axis controller
    //9 - Tablet PC controls

    [Flags]
    internal enum RawInputDeviceFlags
    {
        /// <summary>
        /// 无标识
        /// </summary>
        UNDEFINE = 0x0000,
        /// <summary>
        /// 从内容列表移除顶级集合，操作系统停止对该顶级集合设备的数据读取
        /// </summary>
        RIDEV_REMOVE = 0x0001,
        /// <summary>
        /// 指示顶级集合拒绝读取复杂的用法页，该标记只影响被RIDEV_PAGEONLY指定用法页的顶级集合
        /// </summary>
        RIDEV_EXCLUDE = 0x0010,
        /// <summary>
        /// 指示所有设备的用法页来自于指定的用法页（usUsagePage参数），而用法（usUsage参数）必须为Zero。若需要拒绝特定顶级集合，请使用RIDEV_EXCLUDE
        /// </summary>
        RIDEV_PAGEONLY = 0x0020,
        /// <summary>
        /// 阻止任何由生成的遗留信息中用法页（usUsagePage）或用法（usUsage）指定的设备，只适用于鼠标和键盘
        /// </summary>
        RIDEV_NOLEGACY = 0x0030,
        /// <summary>
        /// 允许调用方不在前台运行时也能接收输入事件，但其窗口句柄必须被指定
        /// </summary>
        RIDEV_INPUTSINK = 0x0100,
        /// <summary>
        /// 鼠标按钮的单击不会激活其他窗口
        /// </summary>
        RIDEV_CAPTUREMOUSE = 0x0200,
        /// <summary>
        /// 应用程序定义的键盘快捷键将不会被处理，而系统快捷键除外。即便RIDEV_NOLEGACY没被指定或hwndTarget为空时它仍然能被指定
        /// </summary>
        RIDEV_NOHOTKEYS = 0x0200,
        /// <summary>
        /// 应用程序命令键将被处理，只有RIDEV_NOLEGACY指定键盘设备时，RIDEV_APPKEYS才能被指定
        /// </summary>
        RIDEV_APPKEYS = 0x0400,
        /// <summary>
        /// 仅当前台应用不能处理原始数据时（未注册）允许已注册的后台应用接收输入信息
        /// </summary>
        RIDEV_EXINPUTSINK = 0x1000,
        /// <summary>
        /// 允许调用方在设备接入或移除时接收WM_INPUT_DEVICE_CHANGE通知
        /// </summary>
        RIDEV_DEVNOTIFY = 0x2000
    }

    public enum HidUsagePage : ushort
    {
        /// <summary>
        /// 无标识
        /// </summary>
        UNDEFINED = 0x00,
        /// <summary>
        /// 一般桌面控制器
        /// </summary>
        GENERIC = 0x01,
        /// <summary>
        /// 模拟控制器
        /// </summary>
        SIMULATION = 0x02,
        /// <summary>
        /// 虚拟现实控制器
        /// </summary>
        VR = 0x03,
        /// <summary>
        /// 运动控制器
        /// </summary>
        SPORT = 0x04,
        /// <summary>
        /// 游戏控制器
        /// </summary>
        GAME = 0x05, 
        /// <summary>
        /// 键盘控制器
        /// </summary>
        KEYBOARD = 0x07,
    }

    public enum HidUsage : ushort
    {
        /// <summary>
        /// 无标识
        /// </summary>
        UNDEFINED = 0x00,
        /// <summary>
        /// 触屏
        /// </summary>
        Pointer = 0x01,
        /// <summary>
        /// 鼠标
        /// </summary>
        Mouse = 0x02,
        /// <summary>
        /// 操纵杆
        /// </summary>
        Joystick = 0x04,
        /// <summary>
        /// 游戏摇杆
        /// </summary>
        Gamepad = 0x05,
        /// <summary>
        /// 键盘
        /// </summary>
        Keyboard = 0x06,
        /// <summary>
        /// 小型键盘或辅助键盘
        /// </summary>
        Keypad = 0x07,
        /// <summary>
        /// 多轴控制
        /// </summary>
        SystemControl = 0x80,
        /// <summary>
        /// 平板电脑控制
        /// </summary>
        Tablet = 0x80,
        /// <summary>
        /// 用户定义
        /// </summary>
        Consumer = 0x0C,
    }
    public enum DeviceNotificationFlags
    {
        /// <summary>
        /// hRecipient参数是一个窗口句柄
        /// </summary>
        DEVICE_NOTIFY_WINDOW_HANDLE = 0x00000000,
        /// <summary>
        /// hRecipient参数是一个服务状态句柄
        /// </summary>
        DEVICE_NOTIFY_SERVICE_HANDLE = 0x00000001,
        /// <summary>
        /// Notifies the recipient of device interface events for all device interface classes. (The dbcc_classguid member is ignored.)
        /// This value can be used only if the dbch_devicetype member is DBT_DEVTYP_DEVICEINTERFACE.
        /// </summary>
        DEVICE_NOTIFY_ALL_INTERFACE_CLASSES = 0x00000004
    }
    public enum RawInputDataCommand : uint
    {
        /// <summary>
        /// 从RAWINPUT结构获取头信息
        /// </summary>
        RID_HEADER = 0x10000005,
        /// <summary>
        /// 从RAWINPUT结构获取原始数据
        /// </summary>
        RID_INPUT = 0x10000003
    }
    public enum DeviceType : int
    {
        RimTypeMouse = 0,
        RimTypeKeyboard = 1,
        RimTypeHid = 2,
    }
    internal enum RawInputDeviceInfo : uint
    {
        RIDI_DEVICENAME = 0x20000007,
        RIDI_DEVICEINFO = 0x2000000b,
        PREPARSEDDATA = 0x20000005
    }

    /// <summary>
    /// 定义原始数据设备信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct RawInputDevice
    {
        /// <summary>
        /// 顶级集合用法页，接口设备用法页
        /// </summary>
        internal HidUsagePage usUsagePage;
        /// <summary>
        /// 顶级集合用法，即监听设备标识
        /// </summary>
        internal HidUsage usUsage;
        /// <summary>
        /// 模式标识，指示如何解释处理由用法页和用法提供的信息，默认为Zero时，操作系统会在已经注册的应用窗口获得焦点时传送顶级集合指定的设备原始数据
        /// </summary>
        internal RawInputDeviceFlags dwFlags;
        /// <summary>
        /// 与监听设备关联的目标窗口句柄，如果为空，则遵循键盘焦点
        /// </summary>
        internal IntPtr hwndTarget;
    }
    enum BroadcastDeviceType
    {
        DBT_DEVTYP_OEM = 0,
        DBT_DEVTYP_DEVNODE = 1,
        DBT_DEVTYP_VOLUME = 2,
        DBT_DEVTYP_PORT = 3,
        DBT_DEVTYP_NET = 4,
        DBT_DEVTYP_DEVICEINTERFACE = 5,
        DBT_DEVTYP_HANDLE = 6,
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RAWHID
    {
        public uint dwSizHid;
        public uint dwCount;
        public byte bRawData;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct RAWMOUSE
    {
        [FieldOffset(0)]
        public ushort usFlags;
        [FieldOffset(4)]
        public uint ulButtons;
        [FieldOffset(4)]
        public ushort usButtonFlags;
        [FieldOffset(6)]
        public ushort usButtonData;
        [FieldOffset(8)]
        public uint ulRawButtons;
        [FieldOffset(12)]
        public int lLastX;
        [FieldOffset(16)]
        public int lLastY;
        [FieldOffset(20)]
        public uint ulExtraInformation;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RAWKEYBOARD
    {
        public ushort Makecode;                 // Scan code from the key depression
        public ushort Flags;                    // One or more of RI_KEY_MAKE, RI_KEY_BREAK, RI_KEY_E0, RI_KEY_E1
        private readonly ushort Reserved;       // Always 0    
        public ushort VKey;                     // Virtual Key Code
        public uint Message;                    // Corresponding Windows message for exmaple (WM_KEYDOWN, WM_SYASKEYDOWN etc)
        public uint ExtraInformation;           // The device-specific addition information for the event (seems to always be zero for keyboards)
    }
    [StructLayout(LayoutKind.Sequential)]
    internal struct RAWINPUTDEVICELIST
    {
        public IntPtr hwnDevice;
        public DeviceType dwType;
    }
    [StructLayout(LayoutKind.Explicit)]
    public struct RawData
    {
        [FieldOffset(0)]
        internal RAWMOUSE mouse;
        [FieldOffset(0)]
        internal RAWKEYBOARD keyboard;
        [FieldOffset(0)]
        internal RAWHID hid;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct InputData
    {
        public Rawinputheader header;           // 64 bit header size: 24  32 bit the header size: 16
        public RawData data;                    // Creating the rest in a struct allows the header size to align correctly for 32/64 bit
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Rawinputheader
    {
        public uint dwType;                     // Type of raw input (RIM_TYPEHID 2, RIM_TYPEKEYBOARD 1, RIM_TYPEMOUSE 0)
        public uint dwSize;                     // Size in bytes of the entire input packet of data. This includes RAWINPUT plus possible extra input reports in the RAWHID variable length array. 
        public IntPtr hDevice;                  // A handle to the device generating the raw input data. 
        public IntPtr wParam;                   // RIM_INPUT 0 if input occurred while application was in the foreground else RIM_INPUTSINK 1 if it was not.
    }

    /// <summary>
    /// 包含来自设备的原始输入
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct RAWINPUT
    {
        [FieldOffset(0)]
        internal RAWMOUSE mouse;
        [FieldOffset(0)]
        internal RAWKEYBOARD keyboard;
        [FieldOffset(0)]
        internal RAWHID hid;
    }
    [StructLayout(LayoutKind.Explicit)]
    public struct DeviceInfo
    {
        [FieldOffset(0)]
        public int Size;
        [FieldOffset(4)]
        public int Type;

        [FieldOffset(8)]
        public DeviceInfoMouse MouseInfo;
        [FieldOffset(8)]
        public DeviceInfoKeyboard KeyboardInfo;
        [FieldOffset(8)]
        public DeviceInfoHid HIDInfo;
    }
    public struct DeviceInfoMouse
    {
        // ReSharper disable MemberCanBePrivate.Global
        public uint Id;                         // Identifier of the mouse device
        public uint NumberOfButtons;            // Number of buttons for the mouse
        public uint SampleRate;                 // Number of data points per second.
        public bool HasHorizontalWheel;         // True is mouse has wheel for horizontal scrolling else false.
    }

    public struct DeviceInfoKeyboard
    {
        public uint Type;                       // Type of the keyboard
        public uint SubType;                    // Subtype of the keyboard
        public uint KeyboardMode;               // The scan code mode
        public uint NumberOfFunctionKeys;       // Number of function keys on the keyboard
        public uint NumberOfIndicators;         // Number of LED indicators on the keyboard
        public uint NumberOfKeysTotal;          // Total number of keys on the keyboard
    }

    public struct DeviceInfoHid
    {
        public uint VendorID;       // Vendor identifier for the HID
        public uint ProductID;      // Product identifier for the HID
        public uint VersionNumber;  // Version number for the device
        public ushort UsagePage;    // Top-level collection Usage page for the device
        public ushort Usage;        // Top-level collection Usage for the device
    }
    struct BroadcastDeviceInterface
    {
        // ReSharper disable NotAccessedField.Global
        // ReSharper disable UnusedField.Compiler
        public Int32 DbccSize;
        public BroadcastDeviceType BroadcastDeviceType;
        public Int32 DbccReserved;
        public Guid DbccClassguid;
        public char DbccName;
        // ReSharper restore NotAccessedField.Global
        // ReSharper restore UnusedField.Compiler
    }
    public class Win32API
    {
        /// <summary>
        /// 注册监听原始输入设备
        /// </summary>
        /// <param name="pRawInputDevices">原始输入设备集</param>
        /// <param name="uiNumDevices">设备集的元素个数</param>
        /// <param name="cbSize">原始输入设备信息占用的字节数</param>
        /// <returns>如果执行成功则返回True，否则为False，可通过调用GetLastError方法获取关于失败的更多信息</returns>
        [DllImport("User32.dll", SetLastError = true)]
        internal static extern bool RegisterRawInputDevices(RawInputDevice[] pRawInputDevices, uint uiNumDevices, uint cbSize);

        [DllImport("User32.dll", SetLastError = true)]
        internal static extern int GetRawInputData(IntPtr hRawInput, RawInputDataCommand uiCommand, [Out] IntPtr pData, [In, Out] ref int pcbSize, int cbSizeHeader);
        [DllImport("User32.dll", SetLastError = true)]
        internal static extern int GetRawInputData(IntPtr hRawInput, RawInputDataCommand command, [Out] out InputData buffer, [In, Out] ref int size, int cbSizeHeader);

        [DllImport("User32.dll", SetLastError = true)]
        internal static extern uint GetRawInputDeviceList(IntPtr pRawInputDeviceList, ref uint numberDevices, uint size);

        [DllImport("User32.dll", SetLastError = true)]
        internal static extern uint GetRawInputDeviceInfo(IntPtr hDevice, RawInputDeviceInfo command, IntPtr pData, ref uint size);

        [DllImport("user32.dll")]
        private static extern uint GetRawInputDeviceInfo(IntPtr hDevice, uint command, ref DeviceInfo data, ref uint dataSize);

        /// <summary>
        /// 注册设备通
        /// </summary>
        /// <param name="hRecipient">接收由NotificationFilter参数指定设备的设备事件的窗口或服务的句柄.多次调用RegisterDeviceNotification方法时可以使用同样的句柄</param>
        /// <param name="NotificationFilter">指定消息应被传送的设备的数据块指针</param>
        /// <param name="Flags">标识</param>
        /// <returns>是否执行成功</returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr RegisterDeviceNotification(IntPtr hRecipient, IntPtr NotificationFilter, DeviceNotificationFlags Flags);

        /// <summary>
        /// 关闭由RegisterDeviceNotification注册返回的设备通知
        /// </summary>
        /// <param name="handle">由RegisterDeviceNotification注册返回的设备句柄</param>
        /// <returns>是否执行成功</returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool UnregisterDeviceNotification(IntPtr handle);

        /// <summary>
        /// 区分设备类型
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static string GetDeviceType(DeviceType device)
        {
            string deviceType;
            switch (device)
            {
                case DeviceType.RimTypeMouse: deviceType = "MOUSE"; break;
                case DeviceType.RimTypeKeyboard: deviceType = "KEYBOARD"; break;
                case DeviceType.RimTypeHid: deviceType = "HID"; break;
                default: deviceType = "UNKNOWN"; break;
            }

            return deviceType;
        }
        /// <summary>
        /// 通过注册表获取设备详情
        /// </summary>
        /// <param name="device">设备标识</param>
        /// <returns></returns>
        public static string GetDeviceDescription(string device)
        {
            string deviceDesc;
            try
            {
                var deviceKey = RegistryAccess.GetDeviceKey(device);
                deviceDesc = deviceKey.GetValue("DeviceDesc").ToString();
                deviceDesc = deviceDesc.Substring(deviceDesc.IndexOf(';') + 1);
            }
            catch (Exception)
            {
                deviceDesc = "Device is malformed unable to look up in the registry";
            }
            return deviceDesc;
        }

    }
}
