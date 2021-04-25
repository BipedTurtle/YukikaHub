using Autofac;
using System;
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
using YukikaHub.UI.Settings;
using YukikaHub.UI.ViewModels;

namespace YukikaHub.UI.UserControls
{
    /// <summary>
    /// Interaction logic for BasicToolbar.xaml
    /// </summary>
    public partial class BasicToolbar : UserControl
    {
        private BasicToolbarViewModel _viewModel;
        public BasicToolbar()
        {
            InitializeComponent();

            _viewModel = (BasicToolbarViewModel)DataContext;
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var settingsButton = sender as FrameworkElement;
        }

        private void devModeMenu_Click(object sender, RoutedEventArgs e)
        {
            var vm = (BasicToolbarViewModel)menuItem.DataContext;

            vm.SwitchDevModeCommand.Execute(null);
        }
    }
}
