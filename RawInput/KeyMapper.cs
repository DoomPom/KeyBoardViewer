
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RawInput
{


    #region VKEY
    public enum VKey:int
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
    public static class KeyMapper
    {
        #region VKEYMAP
        public static String[] KeyNames = new string[256]
        {
           "","LBUTTON","RBUTTON","CANCEL","MBUTTON","XBUTTON1","XBUTTON2","",
"BACK","TAB","","","CLEAR","RETURN","","",
"SHIFT","CONTROL","MENU","PAUSE","CAPITAL","HANGUL","","JUNJA",
"FINAL","KANJI","","ESCAPE","CONVERT","NONCONVERT","ACCEPT","MODECHANGE",
"SPACE","PRIOR","NEXT","END","HOME","LEFT","UP","RIGHT",
"DOWN","SELECT","PRINT","EXECUTE","SNAPSHOT","INSERT","DELETE","HELP",
"D0","D1","D2","D3","D4","D5","D6","D7",
"D8","D9","","","","","","",
"","A","B","C","D","E","F","G",
"H","I","J","K","L","M","N","O",
"P","Q","R","S","T","U","V","W",
"X","Y","Z","LWIN","RWIN","APPS","","SLEEP",
"NUMPAD0","NUMPAD1","NUMPAD2","NUMPAD3","NUMPAD4","NUMPAD5","NUMPAD6","NUMPAD7",
"NUMPAD8","NUMPAD9","MULTIPLY","ADD","SEPARATOR","SUBTRACT","DECIMAL","DIVIDE",
"F1","F2","F3","F4","F5","F6","F7","F8",
"F9","F10","F11","F12","F13","F14","F15","F16",
"F17","F18","F19","F20","F21","F22","F23","F24",
"NAVIGATION_VIEW","NAVIGATION_MENU","NAVIGATION_UP","NAVIGATION_DOWN","NAVIGATION_LEFT","NAVIGATION_RIGHT","NAVIGATION_ACCEPT","NAVIGATION_CANCEL",
"NUMLOCK","SCROLL","OEM_FJ_JISHO","OEM_FJ_MASSHOU","OEM_FJ_TOUROKU","OEM_FJ_LOYA","OEM_FJ_ROYA","",
"","","","","","","","",
"LSHIFT","RSHIFT","LCONTROL","RCONTROL","LMENU","RMENU","BROWSER_BACK","BROWSER_FORWARD",
"BROWSER_REFRESH","BROWSER_STOP","BROWSER_SEARCH","BROWSER_FAVORITES","BROWSER_HOME","VOLUME_MUTE","VOLUME_DOWN","VOLUME_UP",
"MEDIA_NEXT_TRACK","MEDIA_PREV_TRACK","MEDIA_STOP","MEDIA_PLAY_PAUSE","LAUNCH_MAIL","LAUNCH_MEDIA_SELECT","LAUNCH_APP1","LAUNCH_APP2",
"","","OEM_1","OEM_PLUS","OEM_COMMA","OEM_MINUS","OEM_PERIOD","OEM_2",
"OEM_3","","","GAMEPAD_A","GAMEPAD_B","GAMEPAD_X","GAMEPAD_Y","GAMEPAD_RIGHT_SHOULDER",
"GAMEPAD_LEFT_SHOULDER","GAMEPAD_LEFT_TRIGGER","GAMEPAD_RIGHT_TRIGGER","GAMEPAD_DPAD_UP","GAMEPAD_DPAD_DOWN","GAMEPAD_DPAD_LEFT","GAMEPAD_DPAD_RIGHT","GAMEPAD_MENU",
"GAMEPAD_VIEW","GAMEPAD_LEFT_THUMBSTICK_BUTTON","GAMEPAD_RIGHT_THUMBSTICK_BUTTON","GAMEPAD_LEFT_THUMBSTICK_UP","GAMEPAD_LEFT_THUMBSTICK_DOWN","GAMEPAD_LEFT_THUMBSTICK_RIGHT","GAMEPAD_LEFT_THUMBSTICK_LEFT","GAMEPAD_RIGHT_THUMBSTICK_UP",
"GAMEPAD_RIGHT_THUMBSTICK_DOWN","GAMEPAD_RIGHT_THUMBSTICK_RIGHT","GAMEPAD_RIGHT_THUMBSTICK_LEFT","OEM_4","OEM_5","OEM_6","OEM_7","OEM_8",
"","OEM_AX","OEM_102","ICO_HELP","ICO_00","PROCESSKEY","ICO_CLEAR","PACKET",
"","OEM_RESET","OEM_JUMP","OEM_PA1","OEM_PA2","OEM_PA3","OEM_WSCTRL","OEM_CUSEL",
"OEM_ATTN","OEM_FINISH","OEM_COPY","OEM_AUTO","OEM_ENLW","OEM_BACKTAB","ATTN","CRSEL",
"EXSEL","EREOF","PLAY","ZOOM","NONAME","PA1","OEM_CLEAR",""
        };
        public static string GetKeyName(VKey value)
        {
            return value.ToString();
        }
        #endregion

        #region 废弃
        //public enum KeyMap : int
        //{
        //    A, Add, Alt, Apps, Attn, B, Back, BrowserBack, BrowserFavorites, BrowserForward, BrowserHome,
        //    BrowserRefresh, BrowserSearch, BrowserStop, C, Cancel, Capital, CapsLock, Clear, Control,
        //    ControlKey, Crsel, D, D0, D1, D2, D3, D4, D5, D6, D7, D8, D9, Decimal, Delete, Divide, Down,
        //    E, End, Enter, EraseEof, Escape, Execute, Exsel, F, F1, F10, F11, F12, F13, F14, F15, F16,
        //    F17, F18, F19, F2, F20, F21, F22, F23, F24, F3, F4, F5, F6, F7, F8, F9, FinalMode, G, H,
        //    HanguelMode, HangulMode, HanjaMode, Help, Home, I, IMEAceept, IMEConvert, IMEModeChange,
        //    IMENonconvert, Insert, J, JunjaMode, K, KanaMode, KanjiMode, KeyCode, L, LaunchApplication1,
        //    LaunchApplication2, LaunchMail, LButton, LControl, Left, LineFeed, LMenu, LShift, LWin, M,
        //    MButton, MediaNextTrack, MediaPlayPause, MediaPreviousTrack, MediaStop, Menu, Modifiers,
        //    Multiply, N, Next, NoName, None, NumLock, NumPad0, NumPad1, NumPad2, NumPad3, NumPad4, NumPad5,
        //    NumPad6, NumPad7, NumPad8, NumPad9, O, Oem8, OemBackslash, OemClear, OemCloseBrackets, OemComma,
        //    OemMinus, OemOpenBrackets, OemPeriod, OemPipe, Oemplus, OemQuestion, OemQuotes, OemSemicolon,
        //    Oemtilde, P, Pa1, PageDown, PageUp, Pause, Play, Print, PrintScreen, Prior, ProcessKey, Q, R,
        //    RButton, RControl, Return, Right, RMenu, RShift, RWin, S, Scroll, Select, SelectMedia, Separator,
        //    Shift, ShiftKey, Snapshot, Space, Subtract, T, Tab, U, Up, V, VolumeDown, VolumeMute, VolumeUp,
        //    W, X, XButton1, XButton2, Y, Z, Zoom,

        //}
        //public enum VK : byte
        //{
        //    None = 0x00,
        //    LButton = 0x01,
        //    RButton = 0x02,
        //    Cancel = 0x03,
        //    MButton = 0x04,
        //    XButton1 = 0x05,
        //    XButton2 = 0x06,
        //    Back = 0x08,
        //    Tab = 0x09,
        //    LineFeed = 0x0A,
        //    Clear = 0x0C,
        //    Return = 0x0D,
        //    Enter = 0x0D,
        //    ShiftKey = 0x10,
        //    ControlKey = 0x11,
        //    Menu = 0x12,
        //    Pause = 0x13,
        //    CapsLock = 0x14,
        //    Capital = 0x14,
        //    KanaMode = 0x15,
        //    HanguelMode = 0x15,
        //    HangulMode = 0x15,
        //    JunjaMode = 0x17,
        //    FinalMode = 0x18,
        //    HanjaMode = 0x19,
        //    KanjiMode = 0x19,
        //    Escape = 0x1B,
        //    IMEConvert = 0x1C,
        //    IMENonconvert = 0x1D,
        //    IMEAceept = 0x1E,
        //    IMEModeChange = 0x1F,
        //    Space = 0x20,
        //    PageUp = 0x21,
        //    Prior = 0x21,
        //    PageDown = 0x22,
        //    Next = 0x22,
        //    End = 0x23,
        //    Home = 0x24,
        //    Left = 0x25,
        //    Up = 0x26,
        //    Right = 0x27,
        //    Down = 0x28,
        //    Select = 0x29,
        //    Print = 0x2A,
        //    Execute = 0x2B,
        //    PrintScreen = 0x2C,
        //    Snapshot = 0x2C,
        //    Insert = 0x2D,
        //    Delete = 0x2E,
        //    Help = 0x2F,
        //    D0 = 0x30,
        //    D1 = 0x31,
        //    D2 = 0x32,
        //    D3 = 0x33,
        //    D4 = 0x34,
        //    D5 = 0x35,
        //    D6 = 0x36,
        //    D7 = 0x37,
        //    D8 = 0x38,
        //    D9 = 0x39,
        //    A = 0x41,
        //    B = 0x42,
        //    C = 0x43,
        //    D = 0x44,
        //    E = 0x45,
        //    F = 0x46,
        //    G = 0x47,
        //    H = 0x48,
        //    I = 0x49,
        //    J = 0x4A,
        //    K = 0x4B,
        //    L = 0x4C,
        //    M = 0x4D,
        //    N = 0x4E,
        //    O = 0x4F,
        //    P = 0x50,
        //    Q = 0x51,
        //    R = 0x52,
        //    S = 0x53,
        //    T = 0x54,
        //    U = 0x55,
        //    V = 0x56,
        //    W = 0x57,
        //    X = 0x58,
        //    Y = 0x59,
        //    Z = 0x5A,
        //    LWin = 0x5B,
        //    RWin = 0x5C,
        //    Apps = 0x5D,
        //    NumPad0 = 0x60,
        //    NumPad1 = 0x61,
        //    NumPad2 = 0x62,
        //    NumPad3 = 0x63,
        //    NumPad4 = 0x64,
        //    NumPad5 = 0x65,
        //    NumPad6 = 0x66,
        //    NumPad7 = 0x67,
        //    NumPad8 = 0x68,
        //    NumPad9 = 0x69,
        //    Multiply = 0x6A,
        //    Add = 0x6B,
        //    Separator = 0x6C,
        //    Subtract = 0x6D,
        //    Decimal = 0x6E,
        //    Divide = 0x6F,
        //    F1 = 0x70,
        //    F2 = 0x71,
        //    F3 = 0x72,
        //    F4 = 0x73,
        //    F5 = 0x74,
        //    F6 = 0x75,
        //    F7 = 0x76,
        //    F8 = 0x77,
        //    F9 = 0x78,
        //    F10 = 0x79,
        //    F11 = 0x7A,
        //    F12 = 0x7B,
        //    F13 = 0x7C,
        //    F14 = 0x7D,
        //    F15 = 0x7E,
        //    F16 = 0x7F,
        //    F17 = 0x80,
        //    F18 = 0x81,
        //    F19 = 0x82,
        //    F20 = 0x83,
        //    F21 = 0x84,
        //    F22 = 0x85,
        //    F23 = 0x86,
        //    F24 = 0x87,
        //    NumLock = 0x90,
        //    Scroll = 0x91,
        //    LShift = 0xA0,
        //    RShift = 0xA1,
        //    LControl = 0xA2,
        //    RControl = 0xA3,
        //    LMenu = 0xA4,
        //    RMenu = 0xA5,
        //    BrowserBack = 0xA6,
        //    BrowserForward = 0xA7,
        //    BrowserRefresh = 0xA8,
        //    BrowserStop = 0xA9,
        //    BrowserSearch = 0xAA,
        //    BrowserFavorites = 0xAB,
        //    BrowserHome = 0xAC,
        //    VolumeMute = 0xAD,
        //    VolumeDown = 0xAE,
        //    VolumeUp = 0xAF,
        //    MediaNextTrack = 0xB0,
        //    MediaPreviousTrack = 0xB1,
        //    MediaStop = 0xB2,
        //    MediaPlayPause = 0xB3,
        //    LaunchMail = 0xB4,
        //    SelectMedia = 0xB5,
        //    LaunchApplication1 = 0xB6,
        //    LaunchApplication2 = 0xB7,
        //    OemSemicolon = 0xBA,
        //    Oemplus = 0xBB,
        //    OemComma = 0xBC,
        //    OemMinus = 0xBD,
        //    OemPeriod = 0xBE,
        //    OemQuestion = 0xBF,
        //    Oemtilde = 0xC0,
        //    OemOpenBrackets = 0xDB,
        //    OemPipe = 0xDC,
        //    OemCloseBrackets = 0xDD,
        //    OemQuotes = 0xDE,
        //    Oem8 = 0xDF,
        //    OemBackslash = 0xE2,
        //    ProcessKey = 0xE5,
        //    Attn = 0xF6,
        //    Crsel = 0xF7,
        //    Exsel = 0xF8,
        //    EraseEof = 0xF9,
        //    Play = 0xFA,
        //    Zoom = 0xFB,
        //    NoName = 0xFC,
        //    Pa1 = 0xFD,
        //    OemClear = 0xFE,
        //    //KeyCode = 0xFFFF,
        //    //Shift = 0x10000,
        //    //Modifiers = 0x10000,
        //    //Control = 0x20000,
        //    //Alt = 0x40000,



        //}
        //public static String[] VKeys = new string[256]
        //{
        //"","LButton","RButton","Cancel","MButton","XButton1","XButton2","",
        //"Back","Tab","LineFeed","","Clear","Enter","","",
        //"ShiftKey","ControlKey","Menu","Pause","CapsLock","KanaMode","","JunjaMode",
        //"FinalMode","HanjaMode","","Escape","IMEConvert","IMENonconvert","IMEAceept","IMEModeChange",
        //"Space","PageUp","PageDown","End","Home","Left","Up","Right",
        //"Down","Select","Print","Execute","PrintScreen","Insert","Delete","Help",
        //"D0","D1","D2","D3","D4","D5","D6","D7",
        //"D8","D9","","","","","","",
        //"","A","B","C","D","E","F","G",
        //"H","I","J","K","L","M","N","O",
        //"P","Q","R","S","T","U","V","W",
        //"X","Y","Z","LWin","RWin","Apps","","",
        //"NumPad0","NumPad1","NumPad2","NumPad3","NumPad4","NumPad5","NumPad6","NumPad7",
        //"NumPad8","NumPad9","Multiply","Add","Separator","Subtract","Decimal","Divide",
        //"F1","F2","F3","F4","F5","F6","F7","F8",
        //"F9","F10","F11","F12","F13","F14","F15","F16",
        //"F17","F18","F19","F20","F21","F22","F23","F24",
        //"","","","","","","","",
        //"NumLock","Scroll","","","","","","",
        //"","","","","","","","",
        //"LShift","RShift","LControl","RControl","LMenu","RMenu","BrowserBack","BrowserForward",
        //"BrowserRefresh","BrowserStop","BrowserSearch","BrowserFavorites","BrowserHome","VolumeMute","VolumeDown","VolumeUp",
        //"MediaNextTrack","MediaPreviousTrack","MediaStop","MediaPlayPause","LaunchMail","SelectMedia","LaunchApplication1","LaunchApplication2",
        //"","","OemSemicolon","Oemplus","OemComma","OemMinus","OemPeriod","OemQuestion",
        //"Oemtilde","","","","","","","",
        //"","","","","","","","",
        //"","","","","","","","",
        //"","","","OemOpenBrackets","OemPipe","OemCloseBrackets","OemQuotes","Oem8",
        //"","","OemBackslash","","","ProcessKey","","",
        //"","","","","","","","",
        //"","","","","","","Attn","Crsel",
        //"Exsel","EraseEof","Play","Zoom","NoName","Pa1","OemClear",""
        //};
        //public static string GetKeyName(int value)
        //{
        //    switch (value)
        //    {
        //        case 0x41: return "A";
        //        case 0x6b: return "Add";
        //        case 0x40000: return "Alt";
        //        case 0x5d: return "Apps";
        //        case 0xf6: return "Attn";
        //        case 0x42: return "B";
        //        case 8: return "Back";
        //        case 0xa6: return "BrowserBack";
        //        case 0xab: return "BrowserFavorites";
        //        case 0xa7: return "BrowserForward";
        //        case 0xac: return "BrowserHome";
        //        case 0xa8: return "BrowserRefresh";
        //        case 170: return "BrowserSearch";
        //        case 0xa9: return "BrowserStop";
        //        case 0x43: return "C";
        //        case 3: return "Cancel";
        //        case 20: return "Capital";
        //        //case 20:      return "CapsLock";
        //        case 12: return "Clear";
        //        case 0x20000: return "Control";
        //        case 0x11: return "ControlKey";
        //        case 0xf7: return "Crsel";
        //        case 0x44: return "D";
        //        case 0x30: return "D0";
        //        case 0x31: return "D1";
        //        case 50: return "D2";
        //        case 0x33: return "D3";
        //        case 0x34: return "D4";
        //        case 0x35: return "D5";
        //        case 0x36: return "D6";
        //        case 0x37: return "D7";
        //        case 0x38: return "D8";
        //        case 0x39: return "D9";
        //        case 110: return "Decimal";
        //        case 0x2e: return "Delete";
        //        case 0x6f: return "Divide";
        //        case 40: return "Down";
        //        case 0x45: return "E";
        //        case 0x23: return "End";
        //        case 13: return "Enter";
        //        case 0xf9: return "EraseEof";
        //        case 0x1b: return "Escape";
        //        case 0x2b: return "Execute";
        //        case 0xf8: return "Exsel";
        //        case 70: return "F";
        //        case 0x70: return "F1";
        //        case 0x79: return "F10";
        //        case 0x7a: return "F11";
        //        case 0x7b: return "F12";
        //        case 0x7c: return "F13";
        //        case 0x7d: return "F14";
        //        case 0x7e: return "F15";
        //        case 0x7f: return "F16";
        //        case 0x80: return "F17";
        //        case 0x81: return "F18";
        //        case 130: return "F19";
        //        case 0x71: return "F2";
        //        case 0x83: return "F20";
        //        case 0x84: return "F21";
        //        case 0x85: return "F22";
        //        case 0x86: return "F23";
        //        case 0x87: return "F24";
        //        case 0x72: return "F3";
        //        case 0x73: return "F4";
        //        case 0x74: return "F5";
        //        case 0x75: return "F6";
        //        case 0x76: return "F7";
        //        case 0x77: return "F8";
        //        case 120: return "F9";
        //        case 0x18: return "FinalMode";
        //        case 0x47: return "G";
        //        case 0x48: return "H";
        //        case 0x15: return "HanguelMode";
        //        //case 0x15:    return "HangulMode";
        //        case 0x19: return "HanjaMode";
        //        case 0x2f: return "Help";
        //        case 0x24: return "Home";
        //        case 0x49: return "I";
        //        case 30: return "IMEAceept";
        //        case 0x1c: return "IMEConvert";
        //        case 0x1f: return "IMEModeChange";
        //        case 0x1d: return "IMENonconvert";
        //        case 0x2d: return "Insert";
        //        case 0x4a: return "J";
        //        case 0x17: return "JunjaMode";
        //        case 0x4b: return "K";
        //        //case 0x15:    return "KanaMode";
        //        //case 0x19:    return "KanjiMode";
        //        case 0xffff: return "KeyCode";
        //        case 0x4c: return "L";
        //        case 0xb6: return "LaunchApplication1";
        //        case 0xb7: return "LaunchApplication2";
        //        case 180: return "LaunchMail";
        //        case 1: return "LButton";
        //        case 0xa2: return "LControl";
        //        case 0x25: return "Left";
        //        case 10: return "LineFeed";
        //        case 0xa4: return "LMenu";
        //        case 160: return "LShift";
        //        case 0x5b: return "LWin";
        //        case 0x4d: return "M";
        //        case 4: return "MButton";
        //        case 0xb0: return "MediaNextTrack";
        //        case 0xb3: return "MediaPlayPause";
        //        case 0xb1: return "MediaPreviousTrack";
        //        case 0xb2: return "MediaStop";
        //        case 0x12: return "Menu";
        //        // case 65536:  return "Modifiers";
        //        case 0x6a: return "Multiply";
        //        case 0x4e: return "N";
        //        case 0x22: return "Next";
        //        case 0xfc: return "NoName";
        //        case 0: return "None";
        //        case 0x90: return "NumLock";
        //        case 0x60: return "NumPad0";
        //        case 0x61: return "NumPad1";
        //        case 0x62: return "NumPad2";
        //        case 0x63: return "NumPad3";
        //        case 100: return "NumPad4";
        //        case 0x65: return "NumPad5";
        //        case 0x66: return "NumPad6";
        //        case 0x67: return "NumPad7";
        //        case 0x68: return "NumPad8";
        //        case 0x69: return "NumPad9";
        //        case 0x4f: return "O";
        //        case 0xdf: return "Oem8";
        //        case 0xe2: return "OemBackslash";
        //        case 0xfe: return "OemClear";
        //        case 0xdd: return "OemCloseBrackets";
        //        case 0xbc: return "OemComma";
        //        case 0xbd: return "OemMinus";
        //        case 0xdb: return "OemOpenBrackets";
        //        case 190: return "OemPeriod";
        //        case 220: return "OemPipe";
        //        case 0xbb: return "Oemplus";
        //        case 0xbf: return "OemQuestion";
        //        case 0xde: return "OemQuotes";
        //        case 0xba: return "OemSemicolon";
        //        case 0xc0: return "Oemtilde";
        //        case 80: return "P";
        //        case 0xfd: return "Pa1";
        //        // case 0x22:   return "PageDown";
        //        // case 0x21:   return "PageUp";
        //        case 0x13: return "Pause";
        //        case 250: return "Play";
        //        case 0x2a: return "Print";
        //        case 0x2c: return "PrintScreen";
        //        case 0x21: return "Prior";
        //        case 0xe5: return "ProcessKey";
        //        case 0x51: return "Q";
        //        case 0x52: return "R";
        //        case 2: return "RButton";
        //        case 0xa3: return "RControl";
        //        //case 13:      return "Return";
        //        case 0x27: return "Right";
        //        case 0xa5: return "RMenu";
        //        case 0xa1: return "RShift";
        //        case 0x5c: return "RWin";
        //        case 0x53: return "S";
        //        case 0x91: return "Scroll";
        //        case 0x29: return "Select";
        //        case 0xb5: return "SelectMedia";
        //        case 0x6c: return "Separator";
        //        case 0x10000: return "Shift";
        //        case 0x10: return "ShiftKey";
        //        //case 0x2c:    return "Snapshot";
        //        case 0x20: return "Space";
        //        case 0x6d: return "Subtract";
        //        case 0x54: return "T";
        //        case 0x9: return "Tab";
        //        case 0x55: return "U";
        //        case 0x26: return "Up";
        //        case 0x56: return "V";
        //        case 0xae: return "VolumeDown";
        //        case 0xad: return "VolumeMute";
        //        case 0xaf: return "VolumeUp";
        //        case 0x57: return "W";
        //        case 0x58: return "X";
        //        case 0x05: return "XButton1";
        //        case 0x06: return "XButton2";
        //        case 0x59: return "Y";
        //        case 90: return "Z";
        //        case 0xfb: return "Zoom";
        //    }

        //    return value.ToString(CultureInfo.InvariantCulture).ToUpper();
        //}

        // If you prefer the virtualkey converted into a Microsoft virtualkey code use this
        #endregion
        public static string GetMicrosoftKeyName(int virtualKey)
        {
            return new KeysConverter().ConvertToString(virtualKey);
        }
    }
}
