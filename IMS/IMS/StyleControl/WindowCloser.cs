using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace IMS.StyleControl
{
    /// <summary>
    /// 窗体最大化 最小化 关闭  以及拖动
    /// </summary>
    public class WindowCloser
    {


        public static bool GetEnableWindowClosing(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnableWindowClosingProperty);
        }

        public static void SetEnableWindowClosing(DependencyObject obj, bool value)
        {
            obj.SetValue(EnableWindowClosingProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnableWindowClosingProperty =
            DependencyProperty.RegisterAttached("EnableWindowClosing", typeof(bool), typeof(WindowCloser), new PropertyMetadata(false, OnEnableWindowClosingCHanged));
        private static readonly object _syncRoot = new object();
        private static void OnEnableWindowClosingCHanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            if (d is Window window)
            {
                window.Loaded += (s, e) =>
                {
                    if (!(window.DataContext is ICloseWindows vm)) return;
                    vm.Close += () =>
                    {
                        window.Close();
                    };
                    window.Closing += (s, e) =>
                    {
                        e.Cancel = !vm.CanClose();
                    };
                    vm.MaxWindow += () =>
                    {
                        window.WindowState = WindowState.Maximized;
                    };
                    vm.MinWindow += () =>
                    {
                        window.WindowState = WindowState.Minimized;
                    };
                    vm.NolWindow += () =>
                    {
                        window.WindowState = WindowState.Normal;
                    };
                    window.MouseLeftButtonDown += (s, e) =>
                    {
                        if (e.LeftButton == MouseButtonState.Pressed)
                            window.DragMove();

                    };
                };
            }
        }
    }
}
