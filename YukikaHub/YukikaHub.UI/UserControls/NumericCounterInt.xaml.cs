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
using YukikaHub.UI.ViewModels;

namespace YukikaHub.UI.UserControls
{
    /// <summary>
    /// Interaction logic for NumericCounterInt.xaml
    /// </summary>
    public partial class NumericCounterInt : UserControl
    {
        public static readonly DependencyProperty CountProperty =
            DependencyProperty.Register(
                "Count",
                typeof(double),
                typeof(NumericCounterInt),
                new PropertyMetadata(0d));

        public double Count
        {
            get => (double)GetValue(CountProperty);
            set
            {
                double newVal = value < this.Minimum ?
                                this.Minimum :
                                value;

                SetValue(CountProperty, newVal);
            }
        }
        public double Minimum { get; set; }

        public NumericCounterInt()
        {
            InitializeComponent();
        }

        private void Increment_Click(object sender, RoutedEventArgs e)
        {
            Count++;
        }

        private void Decrement_Click(object sender, RoutedEventArgs e)
        {
            Count--;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var overallContext = DataContext;
            var context = textbox.DataContext;
        }
    }
}
