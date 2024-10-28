
using System;
using System.ComponentModel;

namespace KartRiderKeyViewer
{
    #region VKEY
    public enum VKey:byte
    {
        NONE = 0x00,
        LBUTTON = 0x01,
        RBUTTON = 0x02,
        CANCEL = 0x03,
        MBUTTON = 0x04,   /* NOT contiguous with L & RBUTTON */
        XBUTTON1 = 0x05,   /* NOT contiguous with L & RBUTTON */
        XBUTTON2 = 0x06,   /* NOT contiguous with L & RBUTTON */
        BACK = 0x08,
        TAB = 0x09,
        CLEAR = 0x0C,
        RETURN = 0x0D,
        SHIFT = 0x10,
        CONTROL = 0x11,
        MENU = 0x12,
        PAUSE = 0x13,
        CAPITAL = 0x14,
        KANA = 0x15,
        HANGEUL = 0x15, /* old name - should be here for compatibility */
        HANGUL = 0x15,
        JUNJA = 0x17,
        FINAL = 0x18,
        HANJA = 0x19,
        KANJI = 0x19,
        ESCAPE = 0x1B,
        CONVERT = 0x1C,
        NONCONVERT = 0x1D,
        ACCEPT = 0x1E,
        MODECHANGE = 0x1F,
        SPACE = 0x20,
        PRIOR = 0x21,
        NEXT = 0x22,
        END = 0x23,
        HOME = 0x24,
        LEFT = 0x25,
        UP = 0x26,
        RIGHT = 0x27,
        DOWN = 0x28,
        SELECT = 0x29,
        PRINT = 0x2A,
        EXECUTE = 0x2B,
        SNAPSHOT = 0x2C,
        INSERT = 0x2D,
        DELETE = 0x2E,
        HELP = 0x2F,
        D0 = 0x30,
        D1 = 0x31,
        D2 = 0x32,
        D3 = 0x33,
        D4 = 0x34,
        D5 = 0x35,
        D6 = 0x36,
        D7 = 0x37,
        D8 = 0x38,
        D9 = 0x39,
        A = 0x41,
        B = 0x42,
        C = 0x43,
        D = 0x44,
        E = 0x45,
        F = 0x46,
        G = 0x47,
        H = 0x48,
        I = 0x49,
        J = 0x4A,
        K = 0x4B,
        L = 0x4C,
        M = 0x4D,
        N = 0x4E,
        O = 0x4F,
        P = 0x50,
        Q = 0x51,
        R = 0x52,
        S = 0x53,
        T = 0x54,
        U = 0x55,
        V = 0x56,
        W = 0x57,
        X = 0x58,
        Y = 0x59,
        Z = 0x5A,
        LWIN = 0x5B,
        RWIN = 0x5C,
        APPS = 0x5D,
        SLEEP = 0x5F,
        NUMPAD0 = 0x60,
        NUMPAD1 = 0x61,
        NUMPAD2 = 0x62,
        NUMPAD3 = 0x63,
        NUMPAD4 = 0x64,
        NUMPAD5 = 0x65,
        NUMPAD6 = 0x66,
        NUMPAD7 = 0x67,
        NUMPAD8 = 0x68,
        NUMPAD9 = 0x69,
        MULTIPLY = 0x6A,
        ADD = 0x6B,
        SEPARATOR = 0x6C,
        SUBTRACT = 0x6D,
        DECIMAL = 0x6E,
        DIVIDE = 0x6F,
        F1 = 0x70,
        F2 = 0x71,
        F3 = 0x72,
        F4 = 0x73,
        F5 = 0x74,
        F6 = 0x75,
        F7 = 0x76,
        F8 = 0x77,
        F9 = 0x78,
        F10 = 0x79,
        F11 = 0x7A,
        F12 = 0x7B,
        F13 = 0x7C,
        F14 = 0x7D,
        F15 = 0x7E,
        F16 = 0x7F,
        F17 = 0x80,
        F18 = 0x81,
        F19 = 0x82,
        F20 = 0x83,
        F21 = 0x84,
        F22 = 0x85,
        F23 = 0x86,
        F24 = 0x87,
        NAVIGATION_VIEW = 0x88,
        NAVIGATION_MENU = 0x89,
        NAVIGATION_UP = 0x8A,
        NAVIGATION_DOWN = 0x8B,
        NAVIGATION_LEFT = 0x8C,
        NAVIGATION_RIGHT = 0x8D,
        NAVIGATION_ACCEPT = 0x8E,
        NAVIGATION_CANCEL = 0x8F,
        NUMLOCK = 0x90,
        SCROLL = 0x91,
        OEM_NEC_EQUAL = 0x92,  // '=' key on numpad
        OEM_FJ_JISHO = 0x92,  // 'Dictionary' key
        OEM_FJ_MASSHOU = 0x93,  // 'Unregister word' key
        OEM_FJ_TOUROKU = 0x94,  // 'Register word' key
        OEM_FJ_LOYA = 0x95,  // 'Left OYAYUBI' key
        OEM_FJ_ROYA = 0x96,  // 'Right OYAYUBI' key
        LSHIFT = 0xA0,
        RSHIFT = 0xA1,
        LCONTROL = 0xA2,
        RCONTROL = 0xA3,
        LMENU = 0xA4,
        RMENU = 0xA5,
        BROWSER_BACK = 0xA6,
        BROWSER_FORWARD = 0xA7,
        BROWSER_REFRESH = 0xA8,
        BROWSER_STOP = 0xA9,
        BROWSER_SEARCH = 0xAA,
        BROWSER_FAVORITES = 0xAB,
        BROWSER_HOME = 0xAC,
        VOLUME_MUTE = 0xAD,
        VOLUME_DOWN = 0xAE,
        VOLUME_UP = 0xAF,
        MEDIA_NEXT_TRACK = 0xB0,
        MEDIA_PREV_TRACK = 0xB1,
        MEDIA_STOP = 0xB2,
        MEDIA_PLAY_PAUSE = 0xB3,
        LAUNCH_MAIL = 0xB4,
        LAUNCH_MEDIA_SELECT = 0xB5,
        LAUNCH_APP1 = 0xB6,
        LAUNCH_APP2 = 0xB7,
        OEM_1 = 0xBA,  // ';:' for US
        OEM_PLUS = 0xBB,  // '+' any country
        OEM_COMMA = 0xBC,  // ',' any country
        OEM_MINUS = 0xBD,  // '-' any country
        OEM_PERIOD = 0xBE,  // '.' any country
        OEM_2 = 0xBF,  // '/?' for US
        OEM_3 = 0xC0,  // '`~' for US
        GAMEPAD_A = 0xC3,
        GAMEPAD_B = 0xC4,
        GAMEPAD_X = 0xC5,
        GAMEPAD_Y = 0xC6,
        GAMEPAD_RIGHT_SHOULDER = 0xC7,
        GAMEPAD_LEFT_SHOULDER = 0xC8,
        GAMEPAD_LEFT_TRIGGER = 0xC9,
        GAMEPAD_RIGHT_TRIGGER = 0xCA,
        GAMEPAD_DPAD_UP = 0xCB,
        GAMEPAD_DPAD_DOWN = 0xCC,
        GAMEPAD_DPAD_LEFT = 0xCD,
        GAMEPAD_DPAD_RIGHT = 0xCE,
        GAMEPAD_MENU = 0xCF,
        GAMEPAD_VIEW = 0xD0,
        GAMEPAD_LEFT_THUMBSTICK_BUTTON = 0xD1,
        GAMEPAD_RIGHT_THUMBSTICK_BUTTON = 0xD2,
        GAMEPAD_LEFT_THUMBSTICK_UP = 0xD3,
        GAMEPAD_LEFT_THUMBSTICK_DOWN = 0xD4,
        GAMEPAD_LEFT_THUMBSTICK_RIGHT = 0xD5,
        GAMEPAD_LEFT_THUMBSTICK_LEFT = 0xD6,
        GAMEPAD_RIGHT_THUMBSTICK_UP = 0xD7,
        GAMEPAD_RIGHT_THUMBSTICK_DOWN = 0xD8,
        GAMEPAD_RIGHT_THUMBSTICK_RIGHT = 0xD9,
        GAMEPAD_RIGHT_THUMBSTICK_LEFT = 0xDA,
        OEM_4 = 0xDB, //  '[{' for US
        OEM_5 = 0xDC, //  '\|' for US
        OEM_6 = 0xDD, //  ']}' for US
        OEM_7 = 0xDE, //  ''"' for US
        OEM_8 = 0xDF,
        OEM_AX = 0xE1, //  'AX' key on Japanese AX kbd
        OEM_102 = 0xE2, //  "<>" or "\|" on RT 102-key kbd.
        ICO_HELP = 0xE3, //  Help key on ICO
        ICO_00 = 0xE4, //  00 key on ICO
        PROCESSKEY = 0xE5,
        ICO_CLEAR = 0xE6,
        PACKET = 0xE7,
        OEM_RESET = 0xE9,
        OEM_JUMP = 0xEA,
        OEM_PA1 = 0xEB,
        OEM_PA2 = 0xEC,
        OEM_PA3 = 0xED,
        OEM_WSCTRL = 0xEE,
        OEM_CUSEL = 0xEF,
        OEM_ATTN = 0xF0,
        OEM_FINISH = 0xF1,
        OEM_COPY = 0xF2,
        OEM_AUTO = 0xF3,
        OEM_ENLW = 0xF4,
        OEM_BACKTAB = 0xF5,
        ATTN = 0xF6,
        CRSEL = 0xF7,
        EXSEL = 0xF8,
        EREOF = 0xF9,
        PLAY = 0xFA,
        ZOOM = 0xFB,
        NONAME = 0xFC,
        PA1 = 0xFD,
        OEM_CLEAR = 0xFE
    }
    #endregion
    public class KeyItem : INotifyPropertyChanged
    {
        #region 静态变量 ItemNames KeyNames
        // Up,Right,Left,Down,Shift,Ctrl,Alt,X
        public static string[] ItemNames = new String[8]
        {
            "前进键","右方向键","左方向键","后退键","漂移键","使用道具键"," 道具换位卡键","必杀技/超负荷"
        };
        public static String[] KeyNames = new string[256]
{
"","","","","","","","",         //  "","Lbutton","Rbutton","Cancel","Mbutton","Xbutton1","Xbutton2","",
"Back","Tab","","","Clear","Enter","","",
"","","","","CAPS_LOCK","","","",         // "Shift","Control","Menu","Pause","Capital","Hangul","","Junja",
"","","","","","","","",         //  "Final","Kanji","","Escape","Convert","Nonconvert","Accept","Modechange",
"Space","Pageup","Pagedown","End","Home","Left","Up","Right",
"Down","Select","Print","Execute","Snapshot","Insert","Delete","Help",
"","","","","","","","",         // "D0","D1","D2","D3","D4","D5","D6","D7",
"","","","","","","","",         // "D8","D9","","","","","","",
"","A","B","C","D","E","F","G",
"H","I","J","K","L","M","N","O",
"P","Q","R","S","T","U","V","W",
"X","Y","Z","","","","","",         // "X","Y","Z","Lwin","Rwin","Apps","","Sleep",
"0(Numpad)","1(Numpad)","2(Numpad)","3(Numpad)","4(Numpad)","5(Numpad)","6(Numpad)","7(Numpad)",
"8(Numpad)","9(Numpad)","*(Numpad)","+(Numpad)","Separator(Numpad)","-(Numpad)",".(Numpad)","/(Numpad)",
"","","","","","","","",         // "F1","F2","F3","F4","F5","F6","F7","F8",
"","","","","","","","",         // "F9","F10","F11","F12","F13","F14","F15","F16",
"","","","","","","","",         // "F17","F18","F19","F20","F21","F22","F23","F24",
"","","","","","","","",         // "Navigation_View","Navigation_Menu","Navigation_Up","Navigation_Down","Navigation_Left","Navigation_Right","Navigation_Accept","Navigation_Cancel",
"","","","","","","","",         // "Numlock","Scroll","Oem_Fj_Jisho","Oem_Fj_Masshou","Oem_Fj_Touroku","Oem_Fj_Loya","Oem_Fj_Roya","",
"","","","","","","","",
"Shift(Left)","Shift(Right)","Ctrl(Left)","Ctrl(Right)","Alt(Left)","Alt(Right)","","",         // "Lshift","Rshift","Lcontrol","Rcontrol","Lmenu","Rmenu","Browser_Back","Browser_Forward",
"","","","","","","","",         // "Browser_Refresh","Browser_Stop","Browser_Search","Browser_Favorites","Browser_Home","Volume_Mute","Volume_Down","Volume_Up",
"","","","","","","","",         // "Media_Next_Track","Media_Prev_Track","Media_Stop","Media_Play_Pause","Launch_Mail","Launch_Media_Select","Launch_App1","Launch_App2",
"","",";","=",",","-",".","/",         // "","","OEM_1","OEM_PLUS","OEM_COMMA","OEM_MINUS","OEM_PERIOD","OEM_2",
"`","","","","","","","",           // "OEM_3","","","Gamepad_A","Gamepad_B","Gamepad_X","Gamepad_Y","Gamepad_Right_Shoulder",
"","","","","","","","",         // "Gamepad_Left_Shoulder","Gamepad_Left_Trigger","Gamepad_Right_Trigger","Gamepad_Dpad_Up","Gamepad_Dpad_Down","Gamepad_Dpad_Left","Gamepad_Dpad_Right","Gamepad_Menu",
"","","","","","","","",         // "Gamepad_View","Gamepad_Left_Thumbstick_Button","Gamepad_Right_Thumbstick_Button","Gamepad_Left_Thumbstick_Up","Gamepad_Left_Thumbstick_Down","Gamepad_Left_Thumbstick_Right","Gamepad_Left_Thumbstick_Left","Gamepad_Right_Thumbstick_Up",
"","","","[","\\","]","'","",      // "Gamepad_Right_Thumbstick_Down","Gamepad_Right_Thumbstick_Right","Gamepad_Right_Thumbstick_Left","Oem_4","Oem_5","Oem_6","Oem_7","Oem_8",
"","","","","","","","",         // "","Oem_Ax","Oem_102","Ico_Help","Ico_00","Processkey","Ico_Clear","Packet",
"","","","","","","","",         // "","Oem_Reset","Oem_Jump","Oem_Pa1","Oem_Pa2","Oem_Pa3","Oem_Wsctrl","Oem_Cusel",
"","","","","","","","",         // "Oem_Attn","Oem_Finish","Oem_Copy","Oem_Auto","Oem_Enlw","Oem_Backtab","Attn","Crsel",
"","","","","","","","",         // "Exsel","Ereof","Play","Zoom","Noname","Pa1","Oem_Clear",""
};

        public static bool TryGetKeyName(int vk, out String KeyName)
        {
            if ((uint)vk > 0xFF)
            {
                KeyName = "";
                return false;
            }
            KeyName = KeyNames[vk & 0xFF];
            return !KeyName.Equals("");
        }
        public static String GetKeyName(int vk)
        {
            String KeyName = "";
            if ((uint)vk > 0xFF)
            {
                return KeyName;
            }
            KeyName = KeyNames[vk & 0xFF];
            return KeyName;
        }
        #endregion

        #region 类数据定义
        public string ItemName { get; }
        public int Tag0 { get; set; }
        public int Tag1 { get; set; }
        private int vKey0;
        private int vKey1;
        public int Key0 { get { return vKey0; } set { vKey0 = value; KeyStr0 = KeyNames[this.Key0]; OnPropertyChanged("KeyStr0"); } }
        public int Key1 { get { return vKey1; } set { vKey1 = value; KeyStr1 = KeyNames[this.Key1]; OnPropertyChanged("KeyStr1"); } }

        public string KeyStr0 { get; set; }
        public string KeyStr1 { get; set; }
        //public string NewKey0 { get { return KeyNames[this.newCode0]; } }
        //public string NewKey1 { get { return KeyNames[this.newCode1]; } }

        public KeyItem(int index)
        {
            ItemName = ItemNames[index];
            Tag0 = 2 * index;
            Tag1 = Tag0 + 1;
        }
        public KeyItem(int itemName, int key0, int key1) : this(itemName)
        {
            Key0 = key0;
            Key1 = key1;
        }

        //private void UpdateProperty<T>(ref T properValue, T newValue, [CallerMemberName] string propertyName = "")
        //{
        //    if (object.Equals(properValue, newValue))
        //    {
        //        return;
        //    }
        //    properValue = newValue;

        //    OnPropertyChanged(propertyName);
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string strPropertyInfo)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(strPropertyInfo));
            }
        }
        #endregion

    }
}
