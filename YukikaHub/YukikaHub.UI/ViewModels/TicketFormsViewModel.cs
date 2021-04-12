using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YukikaHub.UI.ViewModels
{
    public class TicketFormsViewModel : ViewModelBase, IDetailViewModel
    {
        public Task LoadAsync(object parameter)
        {
            return Task.CompletedTask;
        }
    }
}