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

namespace BeautyShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BeautyWin : Window
    {
        public BeautyWin()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.GoBack();
        }

        private void Mainframe_Navigated(object sender, NavigationEventArgs e)
        {
            TitleLb.Content = (e.Content as Page).Title;
            if (Mainframe.CanGoBack)
            {
                BackBtn.Visibility = Visibility.Visible;
            }
            else
            {
                BackBtn.Visibility = Visibility.Collapsed;
            }
        }
    }
}
