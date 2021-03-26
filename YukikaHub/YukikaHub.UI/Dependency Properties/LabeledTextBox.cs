﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace YukikaHub.UI.Dependency_Properties
{
    public class LabeledTextBox : DependencyObject
    {
        #region Label Property
        public static string GetLabel(DependencyObject obj)
        {
            return (string)obj.GetValue(LabelProperty);
        }

        public static void SetLabel(DependencyObject obj, string value)
        {
            obj.SetValue(LabelProperty, value);
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(
                "Label",
                typeof(string),
                typeof(LabeledTextBox),
                new PropertyMetadata(""));
        #endregion

        #region Style Property
        public static Style GetStyle(DependencyObject obj)
        {
            return (Style)obj.GetValue(StyleProperty);
        }

        public static void SetStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(StyleProperty, value);
        }

        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.Register(
                "Style",
                typeof(Style),
                typeof(LabeledTextBox));
        #endregion

        #region Text Property
        public static string GetText(DependencyObject obj)
        {
            return (string)obj.GetValue(TextProperty);
        }

        public static void SetText(DependencyObject obj, string value)
        {
            obj.SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(LabeledTextBox),
                new PropertyMetadata(""));
        #endregion

        #region Bakcground Property
        public static SolidColorBrush GetBackground(DependencyObject obj)
        {
            return (SolidColorBrush)obj.GetValue(BackgroundProperty);
        }

        public static void SetBackground(DependencyObject obj, SolidColorBrush value)
        {
            obj.SetValue(BackgroundProperty, value);
        }

        public static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register(
                "Background",
                typeof(SolidColorBrush),
                typeof(LabeledTextBox),
                new PropertyMetadata(new SolidColorBrush()));
        #endregion
    }
}
