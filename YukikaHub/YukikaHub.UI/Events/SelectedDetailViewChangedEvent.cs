using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YukikaHub.UI.Events
{
    public class SelectedDetailViewChangedEvent : PubSubEvent<DetailViewChangedEventArgs>
    {
    }

    public class DetailViewChangedEventArgs
    {
        public DetailViewChangedEventArgs(string viewModel)
        {
            this.ViewModelName = viewModel;
        }

        public string ViewModelName { get; set; }
    }
}
