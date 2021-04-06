using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using YukikaHub.UI.Settings;

namespace YukikaHub.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var container = Bootstrapper.Container;
            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }
}
