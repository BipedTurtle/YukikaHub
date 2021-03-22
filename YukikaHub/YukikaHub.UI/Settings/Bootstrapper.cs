using Autofac;
using Prism;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukikaHub.UI.ViewModels;

namespace YukikaHub.UI.Settings
{
    public class Bootstrapper
    {
        public IContainer BootsTrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>();

            return builder.Build();
        }
    }
}