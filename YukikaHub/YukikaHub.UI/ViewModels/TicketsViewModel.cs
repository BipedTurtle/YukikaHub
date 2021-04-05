using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using YukikaHub.Model;
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
            _ticketRepository = ticketRepository;
            ApplicationSettings.ModeChanged += this.OnModeChanged;

            this.AddMotifyTicketCommand = new DelegateCommand(AddMotifyTicket_Execute);

            _eventAggregator
                .GetEvent<SelectedDetailViewChangedEvent>()
                .Subscribe(OnSelectedDetailViewChanged);
        }

        #region Properties
        public Visibility AddButtonVisibility
        {
            get => _buttonVisibility;
            set
            {
                _buttonVisibility = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Ticket> Tickets { get; set; } = new ObservableCollection<Ticket>();
        #endregion

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

        public async Task LoadAsync()
        {
            this.Tickets.Clear();

            var tickets = await _ticketRepository.GetAllNoTrackingAsync();
            foreach (var ticket in tickets)
                this.Tickets.Add(ticket);
        }
    }
}