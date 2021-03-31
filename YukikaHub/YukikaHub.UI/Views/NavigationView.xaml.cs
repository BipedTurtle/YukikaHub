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

namespace YukikaHub.UI.Views
{
    /// <summary>
    /// Interaction logic for NavigationV.xaml
    /// </summary>
    public partial class NavigationView : UserControl
    {
        private double _selectorOffset;
        private double _lvItemHeight;
        public NavigationView()
        {
            InitializeComponent();

            _selectorOffset = selector.Margin.Top;

            var HeightSetter = lv.ItemContainerStyle.Setters
                    .FirstOrDefault(s => ((Setter)s).Property.Name == "Height") as Setter;
            _lvItemHeight = (double)HeightSetter.Value;

            this.Lv = lv;
        }

        public ListView Lv { get; }

        private void OnNavigation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //move selector UI
            selector_transition.OnApplyTemplate();
            var newMarginTop = _selectorOffset + lv.SelectedIndex * _lvItemHeight;
            selector.Margin = new Thickness(0, newMarginTop, 0, 0);
        }
    }
}
