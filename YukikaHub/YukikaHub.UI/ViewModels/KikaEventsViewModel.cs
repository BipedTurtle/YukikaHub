using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YukikaHub.UI.ViewModels
{
    public class KikaEventsViewModel :ViewModelBase, IDetailViewModel
    {
        private IEventAggregator _eventAggregator;

        public KikaEventsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public Task LoadAsync(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}