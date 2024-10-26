using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uninstall
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //if (System.Environment.OSVersion.ToString().IndexOf("NT 5") != -1)
            //{
            //    //  {29B91F1A-A137-406D-8D21-54C4A2EEB092} {29B91F1A-A137-406D-8D21-54C4A2EEB092}
            //    Process.Start("msiexec", "/X {29B91F1A-A137-406D-8D21-54C4A2EEB092}");
            //}

            string sysroot = System.Environment.SystemDirectory;
            Process.Start(sysroot + "\\msiexec.exe", "/x {29B91F1A-A137-406D-8D21-54C4A2EEB092} /qr");
            //{50026DC8-69DC-4B92-89CC-3D10AD4CA8C4} 就是上诉的ProductCode
        }
    }
}
