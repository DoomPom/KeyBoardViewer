using Microsoft.Win32;
using RawInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Resources.ResXFileRef;

namespace KeyBoardViewer
{
    public enum Option_e:int
    {
        Topmost = 0x01,
        HideButton=0x02
    }
    internal static class Config
    {
        public const string path = "SOFTWARE\\KeyBoardViewer";
        public const string KeysItem = "Keys";
        public const string OptionItem = "Option";
        public static VKey[] DefaultKeys = new VKey[16] {
                VKey.UP,VKey.NUMPAD8,
                VKey.RIGHT,VKey.NUMPAD6,
                VKey.LEFT,VKey.NUMPAD4,
                VKey.DOWN,VKey.NUMPAD2,
                VKey.LSHIFT,VKey.RSHIFT,
                VKey.LCONTROL,VKey.RCONTROL,
                VKey.LMENU,VKey.RMENU,
                VKey.X,VKey.SPACE
        };
        public static VKey[] Keys = new VKey[16];
        public static int Option = 1;
        static Config()
        {
            // 注册表
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey key = registry.OpenSubKey(path, true);
            if (key == null)
            {
                key = registry.CreateSubKey(path);
            }
            object value = key.GetValue(KeysItem);
            if (value == null)
            {
                Array.Copy(DefaultKeys, Keys, Keys.Length);
                key.SetValue(KeysItem, Keys, RegistryValueKind.Binary);
                key.SetValue(OptionItem, Option, RegistryValueKind.DWord);
            }
            else
            { // 不存在值。 .
                byte[] keys = (byte[])value;
                for (int i = 0; i < keys.Length; i++)
                {
                    Keys[i] = (VKey)keys[i];
                }
                // 读取
                Option = (int)key.GetValue(OptionItem, RegistryValueKind.DWord);
            }
            registry.Close();
        }

        public static void RebackDefault()
        {
            Array.Copy(DefaultKeys, Keys, Keys.Length);
            SaveConfig();
        }
        public static void SaveConfig()
        {
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey key = registry.OpenSubKey(path, true);
            if (key == null)
            {
                key = registry.CreateSubKey(path);
            }
            key.SetValue(KeysItem, Keys, RegistryValueKind.Binary);
            key.SetValue(OptionItem, Option, RegistryValueKind.DWord);
            registry.Close();
        }

        public static bool TopMost
        {
            get => (Option & (int)Option_e.Topmost) != 0;
            set { Option = Option & (~(int)Option_e.Topmost) | (value ? (int)Option_e.Topmost : 0); }
        }
        public static bool HideButton
        {
            get => (Option & (int) Option_e.HideButton) != 0;
            set { Option = Option & (~(int)Option_e.HideButton) | (value ? (int) Option_e.HideButton : 0);}
        }
    }
}
