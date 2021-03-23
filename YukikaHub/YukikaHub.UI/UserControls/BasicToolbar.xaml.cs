﻿using System;
using System.Collections.Generic;
using System.Linq;
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

namespace YukikaHub.UI.UserControls
{
    /// <summary>
    /// Interaction logic for BasicToolbar.xaml
    /// </summary>
    public partial class BasicToolbar : UserControl
    {
        public BasicToolbar()
        {
            InitializeComponent();
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var settingsButton = sender as FrameworkElement;
            settingsButton.ContextMenu.IsOpen = true;
        }
    }
}
