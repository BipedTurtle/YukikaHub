using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YukikaHub.Model;
using YukikaHub.UI.Wrapper;

namespace YukikaHub.UI.ViewModels
{
    public class AddModifyTicketViewModel : BrowseImageViewModel, IDetailViewModel
    {
        public AddModifyTicketViewModel()
        {
            this.TicketWrapper = new TicketWrapper(new Ticket());
            base._imageWrapper = this.TicketWrapper;
        }

        public TicketWrapper TicketWrapper { get; }

        public Task LoadAsync()
        {
            return Task.CompletedTask;
        }
    }
}
