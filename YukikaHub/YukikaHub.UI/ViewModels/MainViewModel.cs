using Autofac.Features.Indexed;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukikaHub.UI.Events;

namespace YukikaHub.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IDetailViewModel _selectedDetailViewModel;

        private IEventAggregator _eventAggregator;
        private IIndex<string, IDetailViewModel> _detailVmCreator;

        public MainViewModel(IEventAggregator eventAggregator,
            IIndex<string, IDetailViewModel> detailVmCreator,
            IBasicToolBarViewModel basicToolBarViewModel,
            INavigationViewModel navigationViewModel)
        {
            _eventAggregator = eventAggregator;
            _detailVmCreator = detailVmCreator;
            this.BasicToolBarViewModel = basicToolBarViewModel;
            this.NavigationViewModel = navigationViewModel;

            _eventAggregator
                .GetEvent<SelectedDetailViewChangedEvent>()
                .Subscribe(OnSelectedDetailViewChanged);
            var id = _eventAggregator.GetHashCode();
        }

        #region Properties
        public IDetailViewModel SelectedDetailViewModel
        {
            get => _selectedDetailViewModel;
            set
            {
                _selectedDetailViewModel = value;
                OnPropertyChanged();
            }
        }

        public IBasicToolBarViewModel BasicToolBarViewModel { get; private set; }
        public INavigationViewModel NavigationViewModel { get; set; }
        #endregion


        #region Event Handlers
        public async void OnSelectedDetailViewChanged(DetailViewChangedEventArgs e)
        {
            this.SelectedDetailViewModel = _detailVmCreator[e.ViewModelName];
            await this.SelectedDetailViewModel.LoadAsync();
        }
        #endregion
    }
}