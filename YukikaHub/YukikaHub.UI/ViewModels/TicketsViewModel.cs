﻿using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using YukikaHub.UI.Data;
using YukikaHub.UI.Events;
using YukikaHub.UI.Settings;

namespace YukikaHub.UI.ViewModels
{
    public class TicketsViewModel : ViewModelBase, IDetailViewModel
    {
        private IEventAggregator _eventAggregator;
        private Visibility _buttonVisibility = Visibility.Hidden;
        private ITicketRepository _ticketRepository;

        public TicketsViewModel(IEventAggregator eventAggregator,
            ITicketRepository ticketRepository)
        {
            _eventAggregator = eventAggregator;
            // TODO: this is a dangling event. Make sure you unsubscribe it
            ApplicationSettings.ModeChanged += this.OnModeChanged;

            this.AddMotifyTicketCommand = new DelegateCommand(AddMotifyTicket_Execute);

            _eventAggregator
                .GetEvent<SelectedDetailViewChangedEvent>()
                .Subscribe(OnSelectedDetailViewChanged);
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

        #region Commands
        public ICommand AddMotifyTicketCommand { get; set; }
        #endregion

        #region Command Handlers
        public void AddMotifyTicket_Execute()
        {
            _eventAggregator
                .GetEvent<SelectedDetailViewChangedEvent>()
                .Publish(new DetailViewChangedEventArgs(typeof(AddModifyTicketViewModel).Name));
        }
        #endregion

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
        private void OnSelectedDetailViewChanged(DetailViewChangedEventArgs e)
        {
            if (e.ViewModelName != nameof(TicketsViewModel))
                ApplicationSettings.ModeChanged -= this.OnModeChanged;
        }
        #endregion

        public Task LoadAsync()
        {
            return Task.CompletedTask;
        }
    }
}
