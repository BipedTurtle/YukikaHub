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

namespace YukikaHub.UI.UserControls.Dialogs
{
    /// <summary>
    /// Interaction logic for OkCancelDialog.xaml
    /// </summary>
    public partial class OkCancelDialog : UserControl
    {
        public OkCancelDialog(string text)
        {
            InitializeComponent();

            TextBlock_DialogText.Text = text;
        }
    }
}
