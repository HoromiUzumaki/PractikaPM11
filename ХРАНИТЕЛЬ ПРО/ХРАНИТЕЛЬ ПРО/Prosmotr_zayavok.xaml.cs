using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Prosmotr_zayavok.xaml
    /// </summary>
    public partial class Prosmotr_zayavok : Window
    {
        public Prosmotr_zayavok()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var bd = new Хранитель_ПРО_КротоваEntities())
            {
                var zayavka = from z in bd.Заявка_на_посещение
                              join sz in bd.Статус_заявки on z.Код_заявки equals sz.Код_заявки
                              join ps in bd.Пропуск on z.Код_заявки equals ps.Код_заявки
                              select new
                              {
                                  Код_заявки = z.Код_заявки,
                                  Статус_заявки = sz.Статус_заявки1,
                                  Начало_срока_действия = z.Начало_срока_действия,
                                  Конец_срока_действия = z.Конец_срока_действия,
                                  Цель_посещения = ps.Цель_посещения,                                 
                                  Код_сотрудника_одобрившего_заявку = sz.Код_сотрудника_одобрившего_заявку
                              };
                data.ItemsSource = zayavka.ToList();
            }

        }
    }
}
