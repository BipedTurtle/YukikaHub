using Prism.Commands;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using YukikaHub.UI.Data;
using YukikaHub.UI.Events;

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

            this.AddMotifyTicketCommand = new DelegateCommand(AddMotifyTicket_Execute);
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
        public ObservableCollection<TicketControlViewModel> TicketControlViewModels { get; set; } = new ObservableCollection<TicketControlViewModel>();
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

        #endregion

        public async Task LoadAsync(object parameter)
        {
            this.TicketControlViewModels.Clear();

            var tickets = await _ticketRepository.GetAllAsync();
            var ticketControlViewModels = tickets.Select(t => new TicketControlViewModel(_eventAggregator, t));
            foreach (var ticketVm in ticketControlViewModels)
                this.TicketControlViewModels.Add(ticketVm);
        }
    }
}