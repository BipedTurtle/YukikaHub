using Autofac;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using YukikaHub.UI.Events;
using YukikaHub.UI.Settings;

namespace YukikaHub.UI.Global_Commands
{
    public class NavigationCommands 
    {
        public static ICommand BackCommand { get; set; } = new DelegateCommand<object>(Back);
        private static IEventAggregator _eventAggregator;

        static NavigationCommands()
        {
            _eventAggregator = Bootstrapper.Container.Resolve<IEventAggregator>();
        }

        public static void Back(object viewModelToOpen)
        {
            var type = (Type)viewModelToOpen;
            var name = type.Name;

            _eventAggregator
                .GetEvent<SelectedDetailViewChangedEvent>()
                .Publish(new DetailViewChangedEventArgs(name));
        }
    }
}
