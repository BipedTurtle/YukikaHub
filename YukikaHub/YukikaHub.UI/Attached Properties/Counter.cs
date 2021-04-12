using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace YukikaHub.UI.Attached_Properties
{
    public class Counter
    {
        public static string GetLabel(DependencyObject obj)
        {
            return (string)obj.GetValue(LabelProperty);
        }

        public static void SetLabel(DependencyObject obj, string val)
        {
            obj.SetValue(LabelProperty, val);
        }

        public static DependencyProperty LabelProperty =
            DependencyProperty.RegisterAttached(
                "Label",
                typeof(string),
                typeof(Counter));
    }
}
