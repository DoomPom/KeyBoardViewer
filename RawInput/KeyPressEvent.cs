using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawInput
{
    public class KeyPressEvent
    {
        public string DeviceName;       // i.e. \\?\HID#VID_045E&PID_00DD&MI_00#8&1eb402&0&0000#{884b96c3-56ef-11d1-bc8c-00a0c91405dd}
        public string DeviceType;       // KEYBOARD or HID
        public IntPtr DeviceHandle;     // Handle to the device that send the input
        public uint Message;            // WM_KEYDOWN or WM_KEYUP        
        public bool KeyPressState;
        public string Name;             // i.e. Microsoft USB Comfort Curve Keyboard 2000 (Mouse and Keyboard Center)
        private string _source;         // Keyboard_XX
        private int vKey;                // Virtual Key. Corrected for L/R keys(i.e. LSHIFT/RSHIFT) and Zoom
        //private string vKeyName;        // Virtual Key Name. Corrected for L/R keys(i.e. LSHIFT/RSHIFT) and Zoom
        private HashSet<VKey> pressKeys;
        public KeyPressEvent()
        {
            pressKeys = new HashSet<VKey>();
        }
        public int VKey
        {
            get { return vKey; }
            set
            {
                vKey = value;
                if (KeyPressState)
                {
                    pressKeys.Remove((VKey)value);

                }
                else
                {
                    if (!pressKeys.Contains((VKey)value))
                    {
                        pressKeys.Add((VKey)value);
                    }
                }
            }
        }
        public string PressKeys
        {
            get
            {
                StringBuilder str = new StringBuilder(); 
                foreach (int item in pressKeys)
                {
                    str.Append(KeyMapper.GetKeyName((VKey)item)).Append("+");
                }
                if (str.Length > 0)
                {
                    str.Remove(str.Length - 1, 1);
                }
                
                return str.ToString();
            }
        }
        public string Source
        {
            get { return _source; }
            set { _source = string.Format("Keyboard_{0}", value.PadLeft(2, '0')); }
        }

        public override string ToString()
        {
            return string.Format("Device\n DeviceName: {0}\n DeviceType: {1}\n DeviceHandle: {2}\n Name: {3}\n", DeviceName, DeviceType, DeviceHandle.ToInt64().ToString("X"), Name);
        }
    }
    public class HotKeyPressEvent
    {
        public string DeviceName;       // i.e. \\?\HID#VID_045E&PID_00DD&MI_00#8&1eb402&0&0000#{884b96c3-56ef-11d1-bc8c-00a0c91405dd}
        public string DeviceType;       // KEYBOARD or HID
        public IntPtr DeviceHandle;     // Handle to the device that send the input
        public uint Message;            // WM_KEYDOWN or WM_KEYUP        
        public bool KeyPressState;
        public int[] HotKeys;
        internal bool hotActived;
        private List<int> pressKeys;

        public HotKeyPressEvent()
        {
            pressKeys = new List<int>();
            hotActived = false;
        }
        internal void CheckKey(KeyPressEvent e)
        {
            DeviceHandle = e.DeviceHandle;
            DeviceType = e.DeviceType;
            DeviceName = e.DeviceName;
            Message = e.Message;
            KeyPressState = e.KeyPressState;
            if (HotKeys != null)
            {
                if (KeyPressState)
                {
                    if (!pressKeys.Contains(e.VKey))
                    {
                        pressKeys.Add(e.VKey);
                    }
                }
                else
                {
                    pressKeys.Remove(e.VKey);
                }
                if ((HotKeys.Length > 0) && (HotKeys.Length == pressKeys.Count))
                {
                    for (int i = 0; i < HotKeys.Length; i++)
                    {
                        if (HotKeys[i] == pressKeys[i])
                        {
                            continue;
                        }
                        else
                        {
                            hotActived = false;
                            return;
                        }
                    }
                    hotActived = true;
                }
            }
        }
    }
}
