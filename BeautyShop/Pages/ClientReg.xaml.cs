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
    /// Логика взаимодействия для ClientReg.xaml
    /// </summary>
    public partial class ClientReg : Page
    {
        int _id;
        public ClientReg(int id)
        {
            _id = id;
            InitializeComponent();
            try
            {
                ClientCbx.ItemsSource = Db.Clients.ToList();
                ClientServSp.DataContext = new ClientService();
                (ClientServSp.DataContext as ClientService).Service = Db.Services.FirstOrDefault(el => el.Id == _id);
                

            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                TimeOnly res = new TimeOnly();
                
                if(TimeOnly.TryParse(TimeTbx.Text, out res))
                {
                    
                   
                    

                    (ClientServSp.DataContext as ClientService).StartTime = (ClientServSp.DataContext as ClientService).StartTime.AddHours(res.Hour).AddMinutes(res.Minute);

                    Db.ClientServices.Add(ClientServSp.DataContext as ClientService);
                    Db.SaveChanges();
                    
                    NavigationService.GoBack();
                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ClientCbx.SelectedIndex = 0;
            DateDp.SelectedDate = DateTime.Now.Date;

        }

        private void TimeTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TimeOnly res = new TimeOnly();

                if (TimeOnly.TryParse(TimeTbx.Text, out res))
                {

                    FinalTime.Content = res.AddMinutes((ClientServSp.DataContext as ClientService).Service.DurationInSeconds / 60);


                }
                else
                {
                    FinalTime.Content = "";
                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }
    }
}
