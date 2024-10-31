
using System;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using Timer = System.Timers.Timer;
namespace KartRiderKeyViewer
{

    /// <summary>
    /// Interaction logic for MainWindowApp.xaml
    /// </summary>
    public partial class MainWindowApp : Window
    {

        private bool[] keyStatuss;
        private VKey[] Keys;
        private Timer timer ;
        public MainViewModel model;

        [DllImport("User32.dll", SetLastError = true)]
        internal static extern short GetAsyncKeyState(int vkey);
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            for (int i = 0; i < keyStatuss.Length; i++)
            {
                keyStatuss[i] = Convert.ToBoolean(GetAsyncKeyState((int)Keys[i]));
            }
            int j = 0;
            for (int i = 0; i < keyStatuss.Length/2; i++)
            {
                j = 2 * i;
                keyStatuss[i] = keyStatuss[j] | keyStatuss[j+1];
            }
            #region 此处展示的是把副线程的内容转到主线程
            Application.Current.Dispatcher.BeginInvoke(
                     new Action(() =>
                     {
                         //  Key_Up,Key_Right, Key_Left, Key_Down,Key_Shift,Key_Ctrl,Key_Alt,Key_X};
                         model.KeyUp = keyStatuss[0];
                         model.KeyRight = keyStatuss[1];
                         model.KeyLeft = keyStatuss[2];
                         model.KeyDown = keyStatuss[3];
                         model.KeyShift = keyStatuss[4];
                         model.KeyCtrl = keyStatuss[5];
                         model.KeyAlt = keyStatuss[6];
                         model.KeyX = keyStatuss[7];
                     }));
            #endregion

        }

        public MainWindowApp()
        {
            InitializeComponent();
            model = new MainViewModel();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            model.HideButtonChanged += Model_HideButtonChanged;
            model.IsTopMost = Config.TopMost;
            model.HideButton = Config.HideButton;
            this.DataContext = model;

            // 加载窗体
            //this.Topmost =  Config.TopMost;
            //if(Config.HideButton)
            //{
            //    ChangeHideButton(true);
            //}

            Keys = Config.Keys;
            keyStatuss = new bool[Keys.Length];
            // 定时器
            timer = new Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Interval = 10;
            timer.Enabled = true;

            UpdateLastSize();
            AspectRatio = (float)(this.Width / this.Height); // 2.0f;
            if ((int)Config.Loc.Width == 0)
            {
                Config.Loc.Width = this.Width;
                Config.Loc.X = this.Left;
                Config.Loc.Y = this.Top;
            }
            else
            {
                this.Width = Config.Loc.Width;
                this.Height = this.Width/ AspectRatio;
                this.Left = Config.Loc.X;
                this.Top = Config.Loc.Y;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            timer = null;
            if (setform != null)
            {
                setform = null;
            }
            // 保存位置:

            Config.Loc.Width = this.Width;
            Config.Loc.X = this.Left;
            Config.Loc.Y = this.Top;
            Config.SaveLocation();
            e.Cancel = false;// 关闭
        }
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
            this.TitleBar.Visibility = Visibility.Visible;
            this.Setting.Visibility = Visibility.Visible;
            this.UpdateLayout();
            //this.WindowStyle = WindowStyle.ToolWindow;
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.Transparent);
            this.TitleBar.Visibility = Visibility.Hidden;
            this.Setting.Visibility = Visibility.Hidden;
            this.UpdateLayout();
        }
        #endregion
        #region 按钮点击事件拦截
        private void ToggleButton_Click(object sender, MouseButtonEventArgs e)
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
                setform.model = model;
                setform.Show();
            }
            else
            {
                setform.Visibility = Visibility.Visible;
            }
        }
        // 修改窗体模式
        private void Model_HideButtonChanged(bool value)
        {
            // 隐藏
            if (value)
            {
                this.MainLayout.MinWidth -= 80;
            }
            else
            {
                this.MainLayout.MinWidth += 80;
            }
            AspectRatio = (float)(MainLayout.MinWidth / MainLayout.MinHeight); // 2.0f;
            this.Width = this.Height * AspectRatio;
        }
        #endregion
        #region 窗体事件: 拖拉改变窗体大小保持宽高比
        //最后的宽度（Last Width）
        private double LastWidth;

        //最后的高度（Last Height）
        private double LastHeight;

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
            LastWidth = this.Width;
            LastHeight = this.Height;
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

}