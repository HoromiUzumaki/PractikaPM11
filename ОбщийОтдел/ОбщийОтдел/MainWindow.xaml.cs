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

namespace ОбщийОтдел
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Вход_Click(object sender, RoutedEventArgs e)
        {
            int kode = Convert.ToInt32(Кодсотр.Text);
            using (var bd = new Хранитель_ПРО_КротоваEntities2())
            {
                var otdel = bd.Отдел.FirstOrDefault(s => s.Название_отдела == "Общий отдел");
                var sotrudnik = bd.Сотрудники.Where(s => s.Код_отдела == otdel.Код_отдела).FirstOrDefault(s => s.Код_сотрудника == kode);
                if (sotrudnik != null)
                {
                    ViewOrder vo = new ViewOrder();
                    vo.Show();
                    this.Close();
                }
            }
        }
    }
}
