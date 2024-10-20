using RawInput;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;

namespace KeyBoardViewer
{
    /// <summary>
    /// Interaction logic for MainWindowApp.xaml
    /// </summary>
    public partial class MainWindowApp : Window
    {

        private Dictionary<VKey, KeyStatueButton> KeyMapper = new Dictionary<VKey, KeyStatueButton>();
        private ToggleButton[] KeyStatueButtons ;


        #region 加载键盘hook
        private RawInputManager hook;

        public MainWindowApp()
        {
            InitializeComponent();
        }
        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            System.Windows.MessageBox.Show(e.ToString());
        }
        private void Window_Initialized(object sender, EventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //hook.Start();
            IntPtr handle = new WindowInteropHelper(this).Handle;
            //VKey[] hotkey = { VKey.LWIN, VKey.LMENU, VKey.C };
            hook = new RawInputManager(handle, false);
            //hook.HotKeys = hotkey;
            hook.AddMessageFilter();
            hook.OnKeyPressed += Hook_OnKeyPressed;

            UpdateLastSize();
            AspectRatio = (float)(this.Width / this.Height); // 2.0f;

            // 加载窗体
            this.Topmost =  Config.Topmost;

            KeyStatueButtons = new ToggleButton[8]{Key_Up,Key_Right, Key_Left, Key_Down,Key_Shift,Key_Ctrl,Key_Alt,Key_X};
            for (int i = 0;i<16;i++)
            {
                KeyMapper.Add(Config.Keys[i], (KeyStatueButton)(i/2));
            }
            //KeyMapper.Add(VKey.UP, KeyStatueButton.Up);
            //KeyMapper.Add(VKey.RIGHT, KeyStatueButton.Right);
            //KeyMapper.Add(VKey.DOWN, KeyStatueButton.Down);
            //KeyMapper.Add(VKey.NUMPAD4, KeyStatueButton.Left);
            //KeyMapper.Add(VKey.NUMPAD8, KeyStatueButton.Up);
            //KeyMapper.Add(VKey.NUMPAD6, KeyStatueButton.Right);
            //KeyMapper.Add(VKey.NUMPAD2, KeyStatueButton.Down);
            //KeyMapper.Add(VKey.LSHIFT, KeyStatueButton.Shift);
            //KeyMapper.Add(VKey.RSHIFT, KeyStatueButton.Shift);
            //KeyMapper.Add(VKey.LCONTROL, KeyStatueButton.Ctrl);
            //KeyMapper.Add(VKey.RCONTROL, KeyStatueButton.Ctrl);
            //KeyMapper.Add(VKey.LMENU, KeyStatueButton.Alt);
            //KeyMapper.Add(VKey.RMENU, KeyStatueButton.Alt);
            //KeyMapper.Add(VKey.X, KeyStatueButton.X);
            //KeyMapper.Add(VKey.SPACE, KeyStatueButton.X);

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            hook.OnKeyPressed -= Hook_OnKeyPressed;
            if (setform != null)
            {
                setform = null;
            }
            e.Cancel = false;
        }
        #endregion
        #region 按键拦截

        void Hook_OnKeyPressed(object sender, RawKeyEventArg e)
        {
            VKey vkCode = (VKey)e.KeyPressEvent.VKey;
            VKey key1;
            VKey key2;
            bool pressed = !e.KeyPressEvent.KeyPressState;
            if (KeyMapper.TryGetValue(vkCode, out KeyStatueButton button))
            {
                if(pressed)
                {
                    KeyStatueButtons[(int)button].IsChecked = pressed;
                }
                else
                {
                    key1 = Config.Keys[2*(int)button];
                    key2 = Config.Keys[2 *(int)button + 1];
                    if(key1 == vkCode)
                    {
                        if(!e.KeyPressEvent.isPressed((int)key2))
                        {
                            KeyStatueButtons[(int)button].IsChecked = pressed;
                        }
                    }
                    if (key2 == vkCode)
                    {
                        if (!e.KeyPressEvent.isPressed((int)key1))
                        {
                            KeyStatueButtons[(int)button].IsChecked = pressed;
                        }
                    }
                }
            }
        }
        private void Hook_Key(int vkCode,bool pressed)
        {
            // 转换为C#定义的按键码
            //Key key = KeyInterop.KeyFromVirtualKey((int)vkCode);
            //bool used = true;
            //VKey key = (VKey)vkCode;
            //switch (key)
            //{
            //    case VKey.LEFT:
            //    case VKey.NUMPAD4:
            //        Key_Left.IsChecked = pressed;
            //        break;
            //    case VKey.RIGHT:
            //    case VKey.NUMPAD6:
            //        Key_Right.IsChecked = pressed;
            //        break;
            //    case VKey.Up:
            //    case VKey.NUMPAD8:
            //        Key_Up.IsChecked = pressed;
            //        break;
            //    case VKey.DOWN:
            //    case VKey.NUMPAD2:
            //        Key_Down.IsChecked = pressed;
            //        break;
            //    case VKey.LSHIFT:
            //    case VKey.RSHIFT:
            //        Key_Shift.IsChecked = pressed;
            //        break;
            //    case VKey.LCONTROL:
            //    case VKey.RCONTROL:
            //        Key_Ctrl.IsChecked = pressed;
            //        break;
            //    case VKey.LMENU:
            //    case VKey.RMENU:
            //        Key_Alt.IsChecked = pressed;
            //        break;
            //    case VKey.X:
            //    case VKey.SPACE:
            //        Key_X.IsChecked = pressed;
            //        break;
            //    default:
            //        break;
            //}
            //Console.WriteLine("KeyUp:{0}", key);
        }
        #endregion
        #region 窗体事件: 关闭 拖动 进入 离开
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Normal;
            this.DragMove();
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Background = Brushes.FloralWhite;
            TitleBar.Visibility = Visibility.Visible;
            Setting.Visibility = Visibility.Visible;
            this.UpdateLayout();
            //this.WindowStyle = WindowStyle.ToolWindow;
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.Transparent);
            TitleBar.Visibility = Visibility.Hidden;
            Setting.Visibility = Visibility.Hidden;
            this.UpdateLayout();
        }
        #endregion
        #region 按钮点击事件拦截
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }
        private SettingForm setform = null;
        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            //Setting.IsChecked = !Setting.IsChecked;
            //UserForm userForm = new UserForm();
            //userForm.Owner = this;
            //userForm.ShowDialog();
            if (setform == null)
            {
                setform = new SettingForm();
                setform.Owner = this;
                setform.ChangeTopMode += ChangeTopMode;
                setform.KeySet = KeyMapper;
                setform.Show();
            }
            else
            {
                setform.Visibility = Visibility.Visible;
            }
        }
        // 修改窗体模式
        private void ChangeTopMode(bool topmode)
        {
            this.Topmost = topmode;
        }
        #endregion
        #region 窗体事件: 拖拉改变窗体大小保持宽高比
        //最后的宽度（Last Width）
        private uint LastWidth;

        //最后的高度（Last Height）
        private uint LastHeight;

        //这个属性是指 窗口的宽度和高度的比例（宽度/高度）(4:3)
        //This property refers to the aspect ratio (width / height) of the window (4: 3)
        private float AspectRatio = 2.0f;
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
    }
    public enum KeyStatueButton { Up, Right, Left, Down, Shift, Ctrl, Alt, X }
}