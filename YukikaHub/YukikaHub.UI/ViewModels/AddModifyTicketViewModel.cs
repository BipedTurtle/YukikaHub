using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using YukikaHub.DataAccess;
using YukikaHub.Model;
using YukikaHub.UI.Data;
using YukikaHub.UI.Wrapper;


namespace YukikaHub.UI.ViewModels
{
    public class AddModifyTicketViewModel : BrowseImageViewModel, IDetailViewModel
    {
        private ITicketRepository _ticketRepository;
        private SnackbarMessageQueue _messageQueue = new SnackbarMessageQueue(TimeSpan.FromSeconds(2));
        private TicketWrapper _ticketWrapper;

        public AddModifyTicketViewModel(ITicketRepository ticketRepository
            ,YukikaHubDbContext context)
        {
            _ticketRepository = ticketRepository;
            this.TicketWrapper = new TicketWrapper(new Ticket());
            this.EnableTicketWrapperChangeDetection();

            this.ClearCommand = new DelegateCommand(Clear);
            this.UpdateCommand = new DelegateCommand(Update, CanUpdate);
            base.StateChangingCommands.Add(this.UpdateCommand);

            // Trigger validation upon loading
            this.TicketWrapper.Title = "";
            this.TicketWrapper.Price = -1;
            this.TicketWrapper.Date = DateTime.Today;
        }

        #region Properties
        public TicketWrapper TicketWrapper
        {
            get => _ticketWrapper;
            set
            {
                _ticketWrapper = value;
                base._imageWrapper = TicketWrapper;
            }
        }
        
        public SnackbarMessageQueue MessageQueue
        {
            get => _messageQueue;
            set
            {
                _messageQueue = value;
                OnPropertyChanged();
            }
        }
        
        public bool HasChanges() => _ticketRepository.HasChanges();
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
            var ticket = this.TicketWrapper.Model;
            var entityState = ticket.Id == 0 ? EntityState.Added : EntityState.Modified;
            _ticketRepository.SetState(this.TicketWrapper.Model, entityState);

            await _ticketRepository.SaveAsync();
            this.MessageQueue.Enqueue($"Ticket '{this.TicketWrapper.Title}' {entityState.ToString()}");

            if (entityState == EntityState.Added)
                this.Clear();
            ((DelegateCommand)UpdateCommand).RaiseCanExecuteChanged();
        }

        public bool CanUpdate()
        {
            bool ticketIsNew = this.TicketWrapper.Model.Id == 0;
            bool @bool = this.HasChanges();
            return
                !this.TicketWrapper.HasErrors &&
                this.TicketWrapper.Image != null &&
                (this.HasChanges() || ticketIsNew);
        }

        public override void BrowseImage(object ImageControl)
        {
            base.BrowseImage(ImageControl);

            ((DelegateCommand)UpdateCommand).RaiseCanExecuteChanged();
        }

        #endregion
        public static byte[] imageFirstLoaded;
        public async Task LoadAsync(object parameter)
        {
            if (parameter == null)
                return;

            var ticket = parameter as Ticket;
            if (ticket.Id != 0)
                ticket = await _ticketRepository.GetByIdAsync(ticket.Id);

            imageFirstLoaded = ticket.Image;

            this.TicketWrapper = new TicketWrapper(ticket);
            this._imageWrapper = this.TicketWrapper;
            this.EnableTicketWrapperChangeDetection();
            base.OnPropertyChanged(nameof(this.TicketWrapper));
            base.ImageErrorText = "";
            ((DelegateCommand)UpdateCommand).RaiseCanExecuteChanged();
        }

        private void EnableTicketWrapperChangeDetection()
        {
            if (this.TicketWrapper == null)
                return;

            this.TicketWrapper.PropertyChanged += (s, e) =>
            {
                ((DelegateCommand)UpdateCommand).RaiseCanExecuteChanged();
            };
        }
    }
}
