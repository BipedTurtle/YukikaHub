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
using YukikaHub.UI.UserControls;

namespace YukikaHub.UI.Views
{
    /// <summary>
    /// Interaction logic for AlbumView.xaml
    /// </summary>
    public partial class AlbumsView : UserControl
    {
        public AlbumsView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var root = (UserControl)sender;

            var width = root.ActualWidth;
            double marginTotal = 100;
            int columnsCount = int.Parse((string)ItemsControl.Tag);
            double marginValue = 100 / (columnsCount + 1);
            double verticalMarginValue = 20;
            var margin = new Thickness(marginValue, verticalMarginValue, marginValue, verticalMarginValue);
            double childSize = (width - marginTotal) / columnsCount;

            foreach (var item in ItemsControl.Items) {
                var lookup = (AlbumLookup)item;
                (lookup.Width, lookup.Height) = (childSize, childSize);
                lookup.Margin = margin;
            }
        }
    }
}
