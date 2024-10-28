using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;

namespace KartRiderKeyViewer
{
    public enum KeyStatueButton { Up, Right, Left, Down, Shift, Ctrl, Alt, X }
    /// <summary>
    /// 属性改变通知器
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    /// <summary>
    /// 主视图模型
    /// </summary>
    public class MainViewModel : ObservableObject
    {
        private bool keyLeft;
        public bool KeyLeft
        {
            get { return keyLeft; }
            set
            {
                if (keyLeft != value)
                {
                    keyLeft = value;
                    RaisePropertyChanged();
                }
            }
        }
        private bool keyUp;
        public bool KeyUp
        {
            get => keyUp;
            set
            {
                if (keyUp != value)
                {
                    keyUp = value;
                    RaisePropertyChanged();
                }
            }
        }
        private bool keyRight;
        public bool KeyRight
        {
            get { return keyRight; }
            set
            {
                if (keyRight != value)
                {
                    keyRight = value;
                    RaisePropertyChanged();
                }
            }
        }
        private bool keyDown;
        public bool KeyDown
        {
            get { return keyDown; }
            set
            {
                if (keyDown != value)
                {
                    keyDown = value;
                    RaisePropertyChanged();
                }
            }
        }
        private bool keyX;
        public bool KeyX
        {
            get { return keyX; }
            set
            {
                if (keyX != value)
                {
                    keyX = value;
                    RaisePropertyChanged();
                }
            }
        }
        private bool keyShift;
        public bool KeyShift
        {
            get { return keyShift; }
            set
            {
                if (keyShift != value)
                {
                    keyShift = value;
                    RaisePropertyChanged();
                }
            }
        }
        private bool keyCtrl;
        public bool KeyCtrl
        {
            get { return keyCtrl; }
            set
            {
                if (keyCtrl != value)
                {
                    keyCtrl = value;
                    RaisePropertyChanged();
                }
            }
        }
        private bool keyAlt;
        public bool KeyAlt
        {
            get { return keyAlt; }
            set
            {
                if (keyAlt != value)
                {
                    keyAlt = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool isTopMost;
        public bool IsTopMost
        {
            get { return isTopMost; }
            set
            {
                if (isTopMost != value)
                {
                    isTopMost = value;
                    RaisePropertyChanged();
                }
            }
        }
        private bool hideButton;
        public bool HideButton
        {
            get { return hideButton; }
            set
            {
                if (hideButton != value)
                {
                    hideButton = value;
                    RaisePropertyChanged();
                    HideButtonChanged?.Invoke(value);
                }
            }
        }

        public event Action<bool> HideButtonChanged;
        public MainViewModel()
        {

        }
    }


    public class HideByttonToStatueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && Boolean.TryParse(value.ToString(), out Boolean bret))
            {
                return bret ? Visibility.Collapsed : Visibility.Visible;
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
