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
using BeautyShop.Models;

namespace BeautyShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServiceList.xaml
    /// </summary>
    public partial class ServiceList : Page
    {
        public ServiceList()
        {
            InitializeComponent();
        }
        private void loadData()
        {

            try
            {
                List<Service> services = Db.Services.ToList();
                BeforeLb.Content = services.Count();
                if(SortCbx.SelectedIndex == 0)
                {
                    services = services.OrderBy(el => el.Cost).ToList();
                }
                else
                {
                    services = services.OrderByDescending(el => el.Cost).ToList();
                }
                if(DiscCbx.SelectedIndex == 1)
                {
                    services = services.Where(el => el.Discount < 5).ToList();
                }
                if (DiscCbx.SelectedIndex == 2)
                {
                    services = services.Where(el => el.Discount >= 5 && el.Discount < 15).ToList();
                }
                if (DiscCbx.SelectedIndex == 3)
                {
                    services = services.Where(el => el.Discount >= 15 && el.Discount < 30).ToList();
                }
                if (DiscCbx.SelectedIndex == 4)
                {
                    services = services.Where(el => el.Discount >= 30 && el.Discount < 70).ToList();
                }
                if (DiscCbx.SelectedIndex == 5)
                {
                    services = services.Where(el => el.Discount >= 70 && el.Discount < 100).ToList();
                }

                if(SearchTbx.Text != "")
                {
                    services = services.Where(el => el.Title.Contains(SearchTbx.Text) || el.Description.Contains(SearchTbx.Text)).ToList();
                }
                AfterLb.Content = services.Count();
                ServicesLv.ItemsSource = services;
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SortCbx.SelectedIndex = 0;
            DiscCbx.SelectedIndex = 0;
            loadData();

            
            if(!IsAdmin)
            {
                ServicesLv.Tag = Visibility.Collapsed;
                AddBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                ServicesLv.Tag = Visibility.Visible;
            }
        }

        private void SortCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadData();
        }

        private void DiscCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadData();
        }

        private void SearchTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            loadData();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            if(ServicesLv.SelectedItem != null)
            {
                var item = ServicesLv.SelectedItem as Service;
                if(MessageBox.Show("Точто-точно?", "Вы уверены??", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Db.Services.Remove(item);
                    Db.SaveChanges();
                    loadData();
                }
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            
                var item = ((sender as Button).Parent as Grid).DataContext as Service;
                NavigationService.Navigate(new ServiceEdit(item.Id));
           
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ServiceEdit(-1));
        }

        private void ClientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ServicesLv.SelectedItem != null)
            {
                var item = ServicesLv.SelectedItem as Service;
                NavigationService.Navigate(new ClientReg(item.Id));
            }
        }

        private void ClientListBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientServiceList());
        }
    }
}
