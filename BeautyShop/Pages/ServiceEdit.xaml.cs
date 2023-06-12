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
using Microsoft.Win32;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace BeautyShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServiceEdit.xaml
    /// </summary>
    public partial class ServiceEdit : Page
    {
        int _id = 0;
        public ServiceEdit(int id)
        {
            _id = id;
            InitializeComponent();
        }

        private void ImgBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                if(dlg.ShowDialog() == true)
                {
                    (ServiceSp.DataContext as Service).MainImagePath = "Photos\\" + dlg.SafeFileName;
                    var item = File.ReadAllBytes(dlg.FileName);
                    File.WriteAllBytes("Photos\\" + dlg.SafeFileName, item);
                    ServiceImg.Source = new ImageSourceConverter().ConvertFromString(dlg.FileName) as ImageSource;
                }
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
                if(_id == -1)
                {
                    Db.Services.Add(ServiceSp.DataContext as Service);
                }
                Db.SaveChanges();
                NavigationService.GoBack();
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

            try
            {
                if(_id == -1)
                {
                    ServiceSp.DataContext = new Service();
                    AddBtn.Visibility = Visibility.Collapsed;
                    ImagesLv.Visibility = Visibility.Collapsed;
                }
                else
                {
                    ServiceSp.DataContext = Db.Services.Include(el => el.ServicePhotos).FirstOrDefault(el => el.Id == _id);
                    ImagesLv.ItemsSource = (ServiceSp.DataContext as Service).ServicePhotos.ToList();
                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                if (dlg.ShowDialog() == true)
                {
                    ServicePhoto servicePhoto = new ServicePhoto();
                    
                    servicePhoto.PhotoPath = "Photos\\" + dlg.SafeFileName;
                    servicePhoto.Service = (ServiceSp.DataContext as Service);
                    var item = File.ReadAllBytes(dlg.FileName);
                    File.WriteAllBytes("Photos\\" + dlg.SafeFileName, item);
                    Db.ServicePhotos.Add(servicePhoto);
                    Db.SaveChanges();
                    ImagesLv.ItemsSource = (ServiceSp.DataContext as Service).ServicePhotos.ToList();
                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }
    }
}
