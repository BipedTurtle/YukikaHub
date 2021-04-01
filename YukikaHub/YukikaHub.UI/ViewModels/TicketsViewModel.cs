using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YukikaHub.UI.Events;
using YukikaHub.UI.Settings;

namespace YukikaHub.UI.ViewModels
{
    public class TicketsViewModel : ViewModelBase, IDetailViewModel
    {
        private IEventAggregator _eventAggregator;
        private Visibility _buttonVisibility = Visibility.Hidden;

        public TicketsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            // TODO: this is a dangling event. Make sure you unsubscribe it
            ApplicationSettings.ModeChanged += this.OnModeChanged;
        }

        public Visibility AddButtonVisibility
        {
            get => _buttonVisibility;
            set
            {
                _buttonVisibility = value;
                OnPropertyChanged();
            }
        }

        #region Event Handlers
        private void OnModeChanged(ApplicationMode newMode)
        {
            switch (newMode)
            {
                case ApplicationMode.Developer:
                    this.AddButtonVisibility = Visibility.Visible;
                    break;
                case ApplicationMode.User:
                    this.AddButtonVisibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }
        #endregion

        public Task LoadAsync()
        {
            return Task.CompletedTask;
        }
    }
}
