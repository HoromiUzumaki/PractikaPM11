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
using System.Windows.Shapes;

namespace ХРАНИТЕЛЬ_ПРО
{
    /// <summary>
    /// Логика взаимодействия для Главное_окно.xaml
    /// </summary>
    public partial class Главное_окно : Window
    {
        public Главное_окно()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Групповое_посещение newWindow = new Групповое_посещение();
            newWindow.Show();
            Close();
        }
      

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SinglePos   newWindow = new SinglePos();
            newWindow.Show();
            Close();
        }
    }
}
