using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Controls;

namespace ConsoleApp1
{
    public static class Program
    {

        public static void print(this object obj)
        {
            Console.WriteLine(obj.ToString());
        }
        public static void print(this String formater,params object[] objs)
        {
            Console.WriteLine(formater, objs);
        }
        public enum K:Byte { Up, Right, Left, Down, Shift, Ctrl, Alt, X }
        public static K[] DefaultKeys = new K[16] {
            K.Up, K.Right, K.Left,K.Down, K.Shift, K.Ctrl,K.Alt,K.X,
            K.Up, K.Right, K.Left,K.Down, K.Shift, K.Ctrl,K.Alt,K.X
        };
        public static void sss()
        {
            string path = "SOFTWARE\\KeyBoardViewer";
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey key = registry.OpenSubKey(path, true);
            if (key == null)
            {
                key = registry.CreateSubKey(path);
            }
            //key.SetValue("Keys", Convert.ToBase64String(DefaultKeys),RegistryValueKind.String);
            // key.SetValue("Keys2", DefaultKeys, RegistryValueKind.Binary);
            key.DeleteValue("Keys");
        }

        public static void EventPrint(EventInfo info)
        {
            // item.Name.print();
            StringBuilder sb = new StringBuilder();
            sb.Append("public void TextBox_").Append(info.Name).Append("(");
            Type type = info.EventHandlerType;
            MethodInfo invoke = type.GetMethod("Invoke");
            ParameterInfo[] pars = invoke.GetParameters();

            // TextChanged
            // TextChangedEventHandler
            // System.Object
            //  System.Windows.Controls.TextChangedEventArgs
            ParameterInfo p;
            Type pt;
            for (int i = 0; i < pars.Length; i++)
            {
                p= pars[i];
                pt = p.ParameterType;
                sb.Append(pt.Name).Append(" ").Append("arg").Append(i).Append(",");
            }
  
            sb.Remove(sb.Length - 1, 1);
            sb.Append(")\n");
            sb.Append("{\n");
            sb.Append("Console.WriteLine(MethodBase.GetCurrentMethod().Name);\n");
            sb.Append("}\n\n");
            Console.WriteLine(sb.ToString());
        }
        public static void EventHandle()
        {
            Type type = typeof(TextBox);
            EventInfo[] eventInfos = type.GetEvents();
            int i= 0;
            foreach (EventInfo item in eventInfos)
            {
                Console.Write(item.Name+ "=\"TextBox_" + item.Name + "\" " );
                i++;
                if (i == 3)
                {
                    Console.WriteLine("");
                    i = 0;
                }
            }
            // TextChanged="TextBox_TextChanged"
        }
        static void Main(string[] args)
        {
            string f = @"C:\Windows\System32\wow64.dll";
            if (File.Exists(f))
            {
                Console.WriteLine("存在");
            }
            else
            {
                Console.WriteLine("文件不存在");
            }
        }
        static void Main2(string[] args)
        {
            //Type type = typeof(TextBox);
            //EventInfo[] eventInfos = type.GetEvents();
            //foreach (EventInfo item in eventInfos)
            //{
            //    EventPrint(item);
            //}
            // TextChanged="TextBox_TextChanged"
            //EventInfo item = eventInfos[0];
            //item.Name.print();
            //item.EventHandlerType.print();
            //item.DeclaringType.print();
            //item.GetAddMethod().print();

            //// 
            //type = item.EventHandlerType;

            //MethodInfo invoke = type.GetMethod("Invoke");
            //ParameterInfo[] pars = invoke.GetParameters();

            //// TextChanged
            //// TextChangedEventHandler
            //// System.Object
            ////  System.Windows.Controls.TextChangedEventArgs
            //foreach (ParameterInfo p in pars)
            //{
            //    Console.WriteLine(p.ParameterType);
            //}

        }
    }
}
