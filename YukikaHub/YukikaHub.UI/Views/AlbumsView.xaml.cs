using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YukikaHub.Model;
using YukikaHub.UI.UserControls;    
using YukikaHub.UI.ViewModels;

namespace YukikaHub.UI.Views
{
    /// <summary>
    /// Interaction logic for AlbumView.xaml
    /// </summary>
    public partial class AlbumsView : UserControl
    {
        private AlbumsViewModel _albumsViewModel;
        private double _lookupSize;
        public AlbumsView()
        {
            InitializeComponent();
        }

        private void OnAlbumsLoaded_AlignLookups(object sender, EventArgs e)
        {
            int columnsCount = int.Parse((string)ItemsControl.Tag);
            double childSize = (_lookupSize) / columnsCount;

            for (int i = 0; i < ItemsControl.Items.Count; i++){
                // the problem is that since you're now using DataTemplate, your Itemcontrol's Items are Album Poco's
                // not AlbumLookup User Control. To get the UIElement for the POCO you provided, use the ItemContainerGenerator class below
                var contentPresenter = (ContentPresenter)ItemsControl.ItemContainerGenerator.ContainerFromIndex(i);
                (contentPresenter.Width, contentPresenter.Height) = (childSize, childSize);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _albumsViewModel = (AlbumsViewModel)DataContext;
            _albumsViewModel.AlbumsLoaded += this.OnAlbumsLoaded_AlignLookups;

            var root = (UserControl)sender;
            _lookupSize = root.ActualWidth;
        }
    }
}
