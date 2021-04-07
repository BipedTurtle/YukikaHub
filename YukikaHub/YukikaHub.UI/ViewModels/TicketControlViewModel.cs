using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YukikaHub.Model;
using YukikaHub.UI.Events;

namespace YukikaHub.UI.ViewModels
{
    public class TicketControlViewModel : ViewModelBase
    {
        private Ticket _ticket;
        private IEventAggregator _eventAggregator;

        public TicketControlViewModel(IEventAggregator eventAggregator, Ticket ticket)
        {
            _ticket = ticket;
            _eventAggregator = eventAggregator;

            this.ModifyTicketCommand = new DelegateCommand(this.ModifyTicket);
        }

        #region Properties
        public Ticket Ticket
        {
            get => _ticket;
            set
            {
                _ticket = value;
                base.OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public ICommand ModifyTicketCommand { get; set; }
        #endregion

        #region Command Handlers
        public void ModifyTicket()
        {
            _eventAggregator
                .GetEvent<SelectedDetailViewChangedEvent>()
                .Publish(new DetailViewChangedEventArgs(nameof(AddModifyTicketViewModel), this.Ticket));
        }
        #endregion
    }
}