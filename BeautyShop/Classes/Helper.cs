using BeautyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeautyShop.Classes
{
    internal class Helper
    {
        public static BeautyShopContext Db = new BeautyShopContext();

        public static bool IsAdmin = false;

        public static void Error(string err = "Ошибка подключения")
        {
            MessageBox.Show(err, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void Info(string err = "Ошибка подключения")
        {
            MessageBox.Show(err, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
