﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RawInput
{
    public class PreMessageFilter : IMessageFilter
    {
        /// <summary>
        /// 本应用程序已对按键消息处理，不必传递给下一级处理
        /// </summary>
        /// <param name="m"></param>
        /// <returns>true为消息已处理，将不会再往下传递</returns>
        public bool PreFilterMessage(ref Message m)
        {
            return m.Msg == WinMessage.WM_KEYDOWN;
        }
    }
    internal static class WinMessage
    {

        public const int KEYBOARD_OVERRUN_MAKE_CODE = 0xFF;
        public const int WM_APPCOMMAND = 0x0319;
        private const int FAPPCOMMANDMASK = 0xF000;
        internal const int FAPPCOMMANDMOUSE = 0x8000;
        internal const int FAPPCOMMANDOEM = 0x1000;

        public const int WM_KEYDOWN = 0x0100;  //普通按键
        public const int WM_KEYUP = 0x0101;
        internal const int WM_SYSKEYDOWN = 0x0104; //系统按键（按下了ALT）
        internal const int WM_INPUT = 0x00FF;
        internal const int WM_USB_DEVICECHANGE = 0x0219;

        internal const int VK_SHIFT = 0x10;

        internal const int RI_KEY_MAKE = 0x00;      // Key Down
        internal const int RI_KEY_BREAK = 0x01;     // Key Up
        internal const int RI_KEY_E0 = 0x02;        // Left version of the key
        internal const int RI_KEY_E1 = 0x04;        // Right version of the key. Only seems to be set for the Pause/Break key.

        internal const int VK_CONTROL = 0x11;
        internal const int VK_MENU = 0x12;
        internal const int VK_ZOOM = 0xFB;
        internal const int VK_LSHIFT = 0xA0;
        internal const int VK_RSHIFT = 0xA1;
        internal const int VK_LCONTROL = 0xA2;
        internal const int VK_RCONTROL = 0xA3;
        internal const int VK_LMENU = 0xA4;
        internal const int VK_RMENU = 0xA5;

        internal const int SC_SHIFT_R = 0x36;
        internal const int SC_SHIFT_L = 0x2a;
        internal const int RIM_INPUT = 0x00;
    }
}
