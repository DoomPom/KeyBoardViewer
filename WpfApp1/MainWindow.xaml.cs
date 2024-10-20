using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void TextBox_TextChanged(Object arg0, TextChangedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_SelectionChanged(Object arg0, RoutedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewMouseDoubleClick(Object arg0, MouseButtonEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_MouseDoubleClick(Object arg0, MouseButtonEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_TargetUpdated(Object arg0, DataTransferEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_SourceUpdated(Object arg0, DataTransferEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_DataContextChanged(Object arg0, DependencyPropertyChangedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_RequestBringIntoView(Object arg0, RequestBringIntoViewEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_SizeChanged(Object arg0, SizeChangedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_Initialized(Object arg0, EventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_Loaded(Object arg0, RoutedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_Unloaded(Object arg0, RoutedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_ToolTipOpening(Object arg0, ToolTipEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_ToolTipClosing(Object arg0, ToolTipEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_ContextMenuOpening(Object arg0, ContextMenuEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_ContextMenuClosing(Object arg0, ContextMenuEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewMouseDown(Object arg0, MouseButtonEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_MouseDown(Object arg0, MouseButtonEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewMouseUp(Object arg0, MouseButtonEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_MouseUp(Object arg0, MouseButtonEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewMouseLeftButtonDown(Object arg0, MouseButtonEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_MouseLeftButtonDown(Object arg0, MouseButtonEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewMouseLeftButtonUp(Object arg0, MouseButtonEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_MouseLeftButtonUp(Object arg0, MouseButtonEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewMouseRightButtonDown(Object arg0, MouseButtonEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_MouseRightButtonDown(Object arg0, MouseButtonEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewMouseRightButtonUp(Object arg0, MouseButtonEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_MouseRightButtonUp(Object arg0, MouseButtonEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewMouseMove(Object arg0, MouseEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_MouseMove(Object arg0, MouseEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewMouseWheel(Object arg0, MouseWheelEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_MouseWheel(Object arg0, MouseWheelEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_MouseEnter(Object arg0, MouseEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_MouseLeave(Object arg0, MouseEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_GotMouseCapture(Object arg0, MouseEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_LostMouseCapture(Object arg0, MouseEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_QueryCursor(Object arg0, QueryCursorEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewStylusDown(Object arg0, StylusDownEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_StylusDown(Object arg0, StylusDownEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewStylusUp(Object arg0, StylusEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_StylusUp(Object arg0, StylusEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewStylusMove(Object arg0, StylusEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_StylusMove(Object arg0, StylusEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewStylusInAirMove(Object arg0, StylusEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_StylusInAirMove(Object arg0, StylusEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_StylusEnter(Object arg0, StylusEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_StylusLeave(Object arg0, StylusEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewStylusInRange(Object arg0, StylusEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_StylusInRange(Object arg0, StylusEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewStylusOutOfRange(Object arg0, StylusEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_StylusOutOfRange(Object arg0, StylusEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewStylusSystemGesture(Object arg0, StylusSystemGestureEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_StylusSystemGesture(Object arg0, StylusSystemGestureEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_GotStylusCapture(Object arg0, StylusEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_LostStylusCapture(Object arg0, StylusEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_StylusButtonDown(Object arg0, StylusButtonEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_StylusButtonUp(Object arg0, StylusButtonEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewStylusButtonDown(Object arg0, StylusButtonEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewStylusButtonUp(Object arg0, StylusButtonEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewKeyDown(Object arg0, KeyEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_KeyDown(Object arg0, KeyEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewKeyUp(Object arg0, KeyEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_KeyUp(Object arg0, KeyEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewGotKeyboardFocus(Object arg0, KeyboardFocusChangedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_GotKeyboardFocus(Object arg0, KeyboardFocusChangedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewLostKeyboardFocus(Object arg0, KeyboardFocusChangedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_LostKeyboardFocus(Object arg0, KeyboardFocusChangedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewTextInput(Object arg0, TextCompositionEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_TextInput(Object arg0, TextCompositionEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewQueryContinueDrag(Object arg0, QueryContinueDragEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_QueryContinueDrag(Object arg0, QueryContinueDragEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewGiveFeedback(Object arg0, GiveFeedbackEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_GiveFeedback(Object arg0, GiveFeedbackEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewDragEnter(Object arg0, DragEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_DragEnter(Object arg0, DragEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewDragOver(Object arg0, DragEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_DragOver(Object arg0, DragEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewDragLeave(Object arg0, DragEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_DragLeave(Object arg0, DragEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewDrop(Object arg0, DragEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_Drop(Object arg0, DragEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewTouchDown(Object arg0, TouchEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_TouchDown(Object arg0, TouchEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewTouchMove(Object arg0, TouchEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_TouchMove(Object arg0, TouchEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_PreviewTouchUp(Object arg0, TouchEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_TouchUp(Object arg0, TouchEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_GotTouchCapture(Object arg0, TouchEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_LostTouchCapture(Object arg0, TouchEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_TouchEnter(Object arg0, TouchEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_TouchLeave(Object arg0, TouchEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_IsMouseDirectlyOverChanged(Object arg0, DependencyPropertyChangedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_IsKeyboardFocusWithinChanged(Object arg0, DependencyPropertyChangedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_IsMouseCapturedChanged(Object arg0, DependencyPropertyChangedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_IsMouseCaptureWithinChanged(Object arg0, DependencyPropertyChangedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_IsStylusDirectlyOverChanged(Object arg0, DependencyPropertyChangedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_IsStylusCapturedChanged(Object arg0, DependencyPropertyChangedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_IsStylusCaptureWithinChanged(Object arg0, DependencyPropertyChangedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_IsKeyboardFocusedChanged(Object arg0, DependencyPropertyChangedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_LayoutUpdated(Object arg0, EventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_GotFocus(Object arg0, RoutedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_LostFocus(Object arg0, RoutedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_IsEnabledChanged(Object arg0, DependencyPropertyChangedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_IsHitTestVisibleChanged(Object arg0, DependencyPropertyChangedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_IsVisibleChanged(Object arg0, DependencyPropertyChangedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_FocusableChanged(Object arg0, DependencyPropertyChangedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_ManipulationStarting(Object arg0, ManipulationStartingEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_ManipulationStarted(Object arg0, ManipulationStartedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_ManipulationDelta(Object arg0, ManipulationDeltaEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_ManipulationInertiaStarting(Object arg0, ManipulationInertiaStartingEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_ManipulationBoundaryFeedback(Object arg0, ManipulationBoundaryFeedbackEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }


        public void TextBox_ManipulationCompleted(Object arg0, ManipulationCompletedEventArgs arg1)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void Text_PreviewMouseLeftButtonUp(Object arg0, MouseButtonEventArgs arg1)
        {
            TextBox textBox = (TextBox)arg0;

            if(textBox.IsFocused)
            {
                textBox.Select(textBox.Text.Length, 0);
            }
        }
        
    }
}
