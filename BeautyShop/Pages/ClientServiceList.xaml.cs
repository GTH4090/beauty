using Microsoft.EntityFrameworkCore;
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
using System.Windows.Threading;
using static BeautyShop.Classes.Helper;


namespace BeautyShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientServiceList.xaml
    /// </summary>
    public partial class ClientServiceList : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        public ClientServiceList()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 30);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {

            try
            {
                ClientDg.ItemsSource = Db.ClientServices.Include(el => el.Service).Include(el => el.Client).
                    Where(el => (el.StartTime.Date == DateTime.Now.Date && el.StartTime.TimeOfDay > DateTime.Now.TimeOfDay) || el.StartTime.Date == DateTime.Now.AddDays(1).Date).ToList();
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            loadData();
            timer.Start();
        }
    }
}
