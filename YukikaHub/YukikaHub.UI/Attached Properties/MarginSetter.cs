using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace YukikaHub.UI.Attached_Properties
{
    public class MarginSetter
    {
        public static Thickness GetChildMargin(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(ChildMarginProperty);
        }

        public static void SetChildMargin(DependencyObject obj, Thickness value)
        {
            obj.SetValue(ChildMarginProperty, value);
        }

        public static readonly DependencyProperty ChildMarginProperty =
            DependencyProperty.RegisterAttached(
                "ChildMargin",
                typeof(Thickness),
                typeof(MarginSetter),
                new PropertyMetadata(new Thickness(), OnMarginChangedCallback));

        private static void OnMarginChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
        {
            var panel = sender as Panel;
            if (panel == null)
                return;

            panel.Loaded -= SetChildrenMargin;
            panel.Loaded += SetChildrenMargin;
        }

        private static void SetChildrenMargin(object sender, RoutedEventArgs e)
        {
            var panel = sender as Panel;

            foreach (var child in panel.Children)
            {
                var fe = child as FrameworkElement;
                if (fe == null)
                    continue;

                fe.Margin = MarginSetter.GetChildMargin(panel);
            }
        }
    }
}
