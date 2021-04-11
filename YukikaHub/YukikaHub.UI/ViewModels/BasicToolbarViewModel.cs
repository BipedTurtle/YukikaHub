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

namespace YukikaHub.UI.ViewModels
{
    public class BasicToolbarViewModel : ViewModelBase, IBasicToolBarViewModel
    {
        private IEventAggregator _eventAggregator;
        public BasicToolbarViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            this.SwitchToDevModeCommand = new DelegateCommand(this.SwitchToDevMode_Execute);
        }

        #region Event Handlers
        #endregion

        #region Commands
        public ICommand SwitchToDevModeCommand { get; set; }
        #endregion

        #region Command Handlers
        public void SwitchToDevMode_Execute()
        {
            ApplicationSettings.Instance.IsDevMode = true;
        }
        #endregion
    }
}