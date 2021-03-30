using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using YukikaHub.UI.Events;

namespace YukikaHub.UI.ViewModels
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IEventAggregator _eventAggregator;
        private ListViewItem _selectedNavigationItem;
        public NavigationViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        #region Properties
        public ListViewItem SelectedNavigationItem
        {
            get => _selectedNavigationItem;
            set
            {
                _selectedNavigationItem = value;
                if (value == null)
                    return;

                var relatedVm = (Type)_selectedNavigationItem.Tag;
                _eventAggregator.GetEvent<SelectedDetailViewChangedEvent>().Publish(new DetailViewChangedEventArgs(relatedVm.Name));
            }
        }
        #endregion
    }
}
