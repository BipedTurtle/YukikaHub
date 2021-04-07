using MaterialDesignThemes.Wpf;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YukikaHub.Model;
using YukikaHub.UI.Data;
using YukikaHub.UI.Wrapper;

namespace YukikaHub.UI.ViewModels
{
    public class AddModifyTicketViewModel : BrowseImageViewModel, IDetailViewModel
    {
        private ITicketRepository _ticketRepository;
        private SnackbarMessageQueue _messageQueue = new SnackbarMessageQueue(TimeSpan.FromSeconds(2));

        public AddModifyTicketViewModel(ITicketRepository ticketRepository)
        {
            this.TicketWrapper = new TicketWrapper(new Ticket());
            this.TicketWrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(this.TicketWrapper.HasErrors))
                    ((DelegateCommand)UpdateCommand).RaiseCanExecuteChanged();
            };

            base._imageWrapper = this.TicketWrapper;
            _ticketRepository = ticketRepository;

            this.ClearCommand = new DelegateCommand(Clear);
            this.UpdateCommand = new DelegateCommand(Update, CanUpdate);

            // Trigger validation upon loading
            this.TicketWrapper.Title = "";
            this.TicketWrapper.Price = -1;
            this.TicketWrapper.Date = DateTime.Today;
        }

        #region Properties
        public TicketWrapper TicketWrapper { get; private set; }
        
        public SnackbarMessageQueue MessageQueue
        {
            get => _messageQueue;
            set
            {
                _messageQueue = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public ICommand ClearCommand { get; }
        public ICommand UpdateCommand { get; }
        #endregion

        #region Command Handlers
        private void Clear()
        {
            this.TicketWrapper = new TicketWrapper(new Ticket());
            base.OnPropertyChanged(nameof(this.TicketWrapper));
            base._browseImage.Source = null;
        }

        public async void Update()
        {
            _ticketRepository.Add(this.TicketWrapper.Model);
            await _ticketRepository.SaveAsync();
            this.MessageQueue.Enqueue($"Ticket '{this.TicketWrapper.Title}' Updated");

            this.Clear();
        }

        public bool CanUpdate()
        {
            return
                !this.TicketWrapper.HasErrors &&
                this.TicketWrapper.Image != null;
        }

        public override void BrowseImage(object ImageControl)
        {
            base.BrowseImage(ImageControl);

            ((DelegateCommand)UpdateCommand).RaiseCanExecuteChanged();
        }
        #endregion

        public Task LoadAsync(object parameter)
        {
            var ticket = parameter as Ticket;
            if (ticket == null)
                return Task.CompletedTask;

            this.TicketWrapper = new TicketWrapper(ticket);
            base.OnPropertyChanged(nameof(this.TicketWrapper));
            return Task.CompletedTask;
        }
    }
}
