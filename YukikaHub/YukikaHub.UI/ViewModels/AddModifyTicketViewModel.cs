using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YukikaHub.UI.ViewModels
{
    public class AddModifyTicketViewModel : ViewModelBase, IDetailViewModel
    {
        public ICommand MyCommand { get; set; }
        public AddModifyTicketViewModel()
        {
            MyCommand = new DelegateCommand(MyCommand_Execute);
        }

        private void MyCommand_Execute()
        {


        }

        public Task LoadAsync()
        {
            return Task.CompletedTask;
        }
    }
}
