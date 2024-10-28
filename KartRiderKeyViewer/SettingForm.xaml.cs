using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Input;
using System.Windows.Interop;

namespace KartRiderKeyViewer
{
    public partial class SettingForm : Window
    {
        // 定义按钮名称
        public MainViewModel model;

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
            bool value = Convert.ToBoolean(this.TopMost.IsChecked);
            Config.TopMost = value;
            model.IsTopMost = value;
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
            model.HideButton = value;
        }

        //  恢复默认值
        private void RebackDefault_Click(object sender, RoutedEventArgs e)
        {
            Config.RebackDefault();
            LoadKeyItemData();
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
            if (Config.Keys.Contains((VKey)vkey))
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
               Config.Keys[ktag] = (VKey)vkey;
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

  
}
