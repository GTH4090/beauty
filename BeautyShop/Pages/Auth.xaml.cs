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
using static BeautyShop.Classes.Helper;

namespace BeautyShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            if(CodeTbx.Text == "0000")
            {
                IsAdmin = true;
                NavigationService.Navigate(new ServiceList());
            }
        }

        private void ClientBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ServiceList());
        }
    }
}
