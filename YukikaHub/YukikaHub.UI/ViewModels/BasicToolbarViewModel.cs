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

            this.SwitchDevModeCommand = new DelegateCommand<object>(this.SwitchDevMode_Execute);
        }


        #region Event Handlers
        #endregion

        #region Commands
        public ICommand SwitchDevModeCommand { get; set; }
        #endregion

        #region Command Handlers
        public void SwitchDevMode_Execute(object turnDevModeOn)
        {
            var stringFormat = (string)turnDevModeOn;
            bool parseSucceeded = bool.TryParse(stringFormat, out bool result);

            if (!parseSucceeded)
                throw new ArgumentException($"the string '{stringFormat}' cannot be converted to a boolean value. Check for typo");

            ApplicationSettings.Instance.IsDevMode = result;
        }
        #endregion
    }
}