using RawInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

using System.Windows.Input;
using System.Windows.Interop;
using static KeyBoardViewer.MainWindowApp;

namespace KeyBoardViewer
{
    public partial class SettingForm : Window
    {
        // 定义按钮名称
        public Action<bool> ChangeTopMode;
        public Action<bool> ChangeHideButton;

        public Dictionary<VKey, KeyStatueButton> KeySet;
        public KeyItem[] KeyList;
        public KeyItem KItem;

        #region 初始化 加载数据
        /// <summary>
        /// SF.xaml 的交互逻辑
        /// </summary>
        public SettingForm()
        {
            InitializeComponent();

            // 绑定数据。
            KeyList = new KeyItem[8];
            for (int i = 0; i < KeyList.Length; i++)
            {
                KeyList[i] = new KeyItem(i); ;
            }
            LoadKeyItemData();
            this.KeyItemList.ItemsSource = KeyList;
            this.KeyItemList.AlternationCount = KeyList.Count();

        }
        public void LoadKeyItemData()
        {
            // 绑定数据。
            VKey[] keys = Config.Keys;
            KeyItem tmp;
            int j = 0;
            for (int i = 0; i < KeyList.Length; i++, j += 2)
            {
                tmp = KeyList[i];
                tmp.Key0 = (int)keys[j];
                tmp.Key1 = (int)keys[j+1];
                //KeySet.Add(keys[i], (KeyStatueButton)(i / 2));
                //KeySet.Add(keys[i], (KeyStatueButton)(i / 2));
            }
        }
        #endregion

        //public void UpdateKeys(Action<int> action)
        //{
        //    if (HasNewKey)
        //    {
        //        KeyItem item;
        //        for (int i = 0; i < NewKeys.Length; i++)
        //        {
        //            if (NewKeys[i] != 0)
        //            {
        //                item = this.KeyList[i / 2];
        //                if (i % 2 == 0)
        //                {
        //                    item.NewKey1 = KeyNames[(int)NewKeys[i]];
        //                }
        //                else
        //                {
        //                    item.NewKey2 = KeyNames[(int)NewKeys[i]];
        //                }
        //            }
        //        }
        //        HasNewKey = false;
        //    }
        //}
        public void SaveKeys(Action<int> action)
        {

        }
        #region 窗体事件 加载卸载。
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.TopMost.IsChecked = Config.TopMost;
            this.HideButton.IsChecked = Config.HideButton;
            UpdateLastSize();
            AspectRatio = (float)(this.Width / this.Height);
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
        #endregion
        #region 窗体事件: 拖拉改变窗体大小保持宽高比
        //最后的宽度（Last Width）
        private uint LastWidth;

        //最后的高度（Last Height）
        private uint LastHeight;

        //这个属性是指 窗口的宽度和高度的比例（宽度/高度）(4:3)
        //This property refers to the aspect ratio (width / height) of the window (4: 3)
        private float AspectRatio;
        /// <summary>
        /// 捕获窗口拖拉消息
        /// (Capturing window drag messages)
        /// </summary>
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource source = HwndSource.FromVisual(this) as HwndSource;
            if (source != null)
            {
                source.AddHook(new HwndSourceHook(WinProc));
            }
        }

        public void UpdateLastSize()
        {
            LastWidth = (uint)this.Width;
            LastHeight = (uint)this.Height;
        }

        public const Int32 WM_EXITSIZEMOVE = 0x0232;
        /// <summary>
        /// 重载窗口消息处理函数
        /// (Overload window message processing function)
        /// </summary>
        private IntPtr WinProc(IntPtr hwnd, Int32 msg, IntPtr wParam, IntPtr lParam, ref Boolean handled)
        {
            IntPtr result = IntPtr.Zero;
            switch (msg)
            {
                //处理窗口消息 (Handle window messages)
                case WM_EXITSIZEMOVE:
                    {
                        //上下拖拉窗口 (Drag window vertically)
                        if (this.Height != LastHeight)
                        {
                            this.Width = this.Height * AspectRatio;
                        }
                        // 左右拖拉窗口 (Drag window horizontally)
                        else if (this.Width != LastWidth)
                        {
                            this.Height = this.Width / AspectRatio;
                        }

                        UpdateLastSize();
                        break;
                    }
            }
            return result;
        }


        #endregion

        #region 其他控件事件

        // 保存 关闭。
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Config.SaveConfig();
            this.Close();
        }
        // 置顶选项
        private void TopMost_Click(object sender, RoutedEventArgs e)
        {
            Config.TopMost = Convert.ToBoolean(this.TopMost.IsChecked);
            this.ChangeTopMode.Invoke(Config.TopMost);
        }
        /// <summary>
        /// 隐藏按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HideButton_Click(object sender, RoutedEventArgs e)
        {
            bool value = Convert.ToBoolean(this.HideButton.IsChecked);
            Config.HideButton = value;
            // 更新显示//
            ChangeHideButton(value);
        }

        //  恢复默认值
        private void RebackDefault_Click(object sender, RoutedEventArgs e)
        {
            Config.RebackDefault();
            LoadKeyItemData();

            KeySet.Clear();
            for (int i = 0; i < 16; i++)
            {
                KeySet.Add(Config.Keys[i], (KeyStatueButton)(i / 2));
            }
            //this.KeyItemList.UpdateLayout();
        }
        //TextBox_GotFocus

        public void UpdateCuror(TextBox textBox)
        {
            if (textBox.IsFocused)
            {
                textBox.Select(textBox.Text.Length, 0);
            }
        }
        public void TextBox_PreviewMouseLeftButtonUp(Object sender, MouseButtonEventArgs e)
        {
            UpdateCuror((TextBox)sender);
        }
        public void TextBox_KeyUp(Object sender, KeyEventArgs e)
        {
            UpdateCuror((TextBox)sender);
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // 符合要救的值
            TextBox textBox = (TextBox)sender;
            textBox.UpdateLayout();
        }
        //TextBox_LostFocus
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            int vkey = KeyInterop.VirtualKeyFromKey(e.Key);

            // 符合要救的值
            TextBox textBox = (TextBox)sender;
            int ktag = Convert.ToInt32(textBox.Tag);
            int curkey = (int)Config.Keys[ktag];

            if (vkey == curkey)
                { return; }

            // 存在性判断
            if (KeySet.ContainsKey((VKey)vkey))
            {
                MessageBox.Show( "\""+KeyItem.GetKeyName(vkey) + "\" 已设定按键","按键设置",MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            
            if(KeyItem.TryGetKeyName(vkey,out String keyName))
            {
                KItem = KeyList[ktag / 2];
                if (ktag % 2 == 0)
                {
                   KItem.Key0 = vkey;
                }
                else
                {
                    KItem.Key1 = vkey;
                }
                KeySet.Remove((VKey)curkey);
                KeySet.Add((VKey)vkey, (KeyStatueButton)(ktag / 2));
                Config.Keys[ktag] = (VKey)vkey;

                //Keyboard.ClearFocus();
                //FocusManager.SetFocusedElement(FreeText, FreeText);
                //FreeText.Focus();
            }
            else
            {
                MessageBox.Show("ESC,F1~F12,0~9键以及系统键无法设定为操作按钮", "按键设置", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
        }
        #endregion

        private void Window_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            e.Handled = true;
        }


    }

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

        public static bool TryGetKeyName(int vk,out String KeyName )
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
            Tag1 = Tag0+1;
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
