using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukikaHub.Model;
using YukikaHub.UI.Wrapper;

namespace YukikaHub.UI.ViewModels
{
    public class TicketFormsViewModel : ViewModelBase, IDetailViewModel
    {
        private TicketWrapper _ticket;
        public TicketWrapper Ticket
        {
            get => _ticket;
            set
            {
                _ticket = value;
                base.OnPropertyChanged();
            }
        }

        private double _count;
        public double Count
        {
            get => _count;
            set
            {
                _count = value;
                base.OnPropertyChanged();
            }
        }

        public Task LoadAsync(object parameter)
        {
            var ticket = (Ticket)parameter;
            _ticket = new TicketWrapper(ticket);
            return Task.CompletedTask;
        }
    }
}