using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace YukikaHub.UI.Settings
{
    public class ApplicationSettings : DependencyObject
    {
        public static readonly DependencyProperty IsDevModeProperty =
            DependencyProperty.Register(
                "IsDevMode",
                typeof(bool),
                typeof(ApplicationSettings),
                new PropertyMetadata(defaultValue: false));

        public bool IsDevMode
        {
            get { return (bool)GetValue(IsDevModeProperty); }
            set { SetValue(IsDevModeProperty, value); }
        }

        public static ApplicationSettings Instance { get; }
        static ApplicationSettings()
        {
            if (Instance == null)
                Instance = new ApplicationSettings();
        }
    } 

    public enum ApplicationMode
    {
        Developer,
        User
    }
}

