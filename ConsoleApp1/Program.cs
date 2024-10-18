using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        internal enum K:Byte { Up, Right, Left, Down, Shift, Ctrl, Alt, X }
        public static K[] DefaultKeys = new K[16] {
            K.Up, K.Right, K.Left,K.Down, K.Shift, K.Ctrl,K.Alt,K.X,
            K.Up, K.Right, K.Left,K.Down, K.Shift, K.Ctrl,K.Alt,K.X
        };
        static void Main(string[] args)
        {
            string path = "SOFTWARE\\KeyBoardViewer";
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey key = registry.OpenSubKey(path,true);
            if (key == null)
            {
                key = registry.CreateSubKey(path);
            }
            //key.SetValue("Keys", Convert.ToBase64String(DefaultKeys),RegistryValueKind.String);
            // key.SetValue("Keys2", DefaultKeys, RegistryValueKind.Binary);
            key.DeleteValue("Keys");
        }
    }
}
