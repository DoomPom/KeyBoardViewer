using KartRiderKeyViewer;
using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace KartRiderKeyViewer
{
    public enum Option_e:int
    {
        Topmost = 0x01,
        HideButton=0x02
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct Location
    {
        public double X;
        public double Y;
        public double Width;
    }

    public class StructUtil
    {
        public static T BytesToStruct<T>(byte[] bytes, int offset, int length)
        {
            IntPtr ptr = Marshal.AllocHGlobal(length);
            Marshal.Copy(bytes, offset, ptr, length);
            T obj= Marshal.PtrToStructure<T>(ptr);
            Marshal.FreeHGlobal(ptr);
            return obj;
        }
        public static T BytesToStruct<T>(byte[] bytes)
        {
            return BytesToStruct<T>(bytes, 0, bytes.Length);
        }
        public static byte[] ToByteArray(object obj)
        {
            int rawsize= Marshal.SizeOf(obj);
            IntPtr intPtr = Marshal.AllocHGlobal(rawsize);
            Marshal.StructureToPtr(obj, intPtr, false);
            byte[] bytes = new byte[rawsize];
            Marshal.Copy(intPtr, bytes, 0, rawsize);
            Marshal.FreeHGlobal(intPtr);
            return bytes;
        }
    }

    internal static class Config
    {
        public const string path = "SOFTWARE\\KartRiderKeyViewer";
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
        public static Location Loc;
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
                Option = (int)key.GetValue(OptionItem,0);
                // 读取位置:
                value = key.GetValue("Location");
                if (value != null)
                {
                    byte[] bytes = (byte[])value;
                    Loc = StructUtil.BytesToStruct<Location>(bytes);
                }
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

        public static void SaveLocation()
        {
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey key = registry.OpenSubKey(path, true);
            if (key == null)
            {
                key = registry.CreateSubKey(path);
            }
            key.SetValue("Location", StructUtil.ToByteArray(Loc), RegistryValueKind.Binary);

            registry.Close();
        }

        public static bool TopMost
        {
            get => (Option & (int)Option_e.Topmost) != 0;
            set { Option = (Option & (~(int)Option_e.Topmost)) | (value ? (int)Option_e.Topmost : 0); }
        }
        public static bool HideButton
        {
            get => (Option & (int) Option_e.HideButton) != 0;
            set { Option = (Option & (~(int)Option_e.HideButton)) | (value ? (int) Option_e.HideButton : 0);}
        }
    }
}
