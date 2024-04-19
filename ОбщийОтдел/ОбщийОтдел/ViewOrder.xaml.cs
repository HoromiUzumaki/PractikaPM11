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

namespace ОбщийОтдел
{
    /// <summary>
    /// Логика взаимодействия для ViewOrder.xaml
    /// </summary>
    public partial class ViewOrder : Window
    {
        public ViewOrder()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //просмотр записей
            using (var bd = new Хранитель_ПРО_КротоваEntities2())
            {
                var zayavka = from z in bd.Заявка_на_посещение
                              join sz in bd.Статус_заявки on z.Код_заявки equals sz.Код_заявки
                              join ps in bd.Пропуск on z.Код_заявки equals ps.Код_заявки
                              join sotrud in bd.Сотрудники on ps.Принимающий_сотрудник equals sotrud.Код_сотрудника
                              join podrazd in bd.Подразделение on sotrud.Код_подразделения equals podrazd.Код_подразделения
                              select new
                              {
                                  Код_заявки = z.Код_заявки,
                                  Статус_заявки = sz.Статус_заявки1,
                                  Начало_срока_действия = z.Начало_срока_действия,
                                  Конец_срока_действия = z.Конец_срока_действия,
                                  Цель_посещения = ps.Цель_посещения,
                                  Код_сотрудника_одобрившего_заявку = sz.Код_сотрудника_одобрившего_заявку,
                                  Фамилия_сотрудника = sotrud.Фамилия,
                                  Имя_сотрудника = sotrud.Имя,
                                  Отчество_сотрудника = sotrud.Отчество,
                                  Подразделение = podrazd.Название_подразделения
                              };
                data.ItemsSource = zayavka.ToList();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var bd = new Хранитель_ПРО_КротоваEntities2())
            {
                string departmentName = "Администрация";

                var zayavka1 = from z in bd.Заявка_на_посещение
                              join sz in bd.Статус_заявки on z.Код_заявки equals sz.Код_заявки
                               join ps in bd.Пропуск on z.Код_заявки equals ps.Код_заявки
                               join sotrud in bd.Сотрудники on sz.Код_сотрудника_одобрившего_заявку equals sotrud.Код_сотрудника
                              join podrazd in bd.Подразделение on sotrud.Код_подразделения equals podrazd.Код_подразделения
                              where podrazd.Название_подразделения == departmentName
                              select new
                              {
                                  Код_заявки = z.Код_заявки,
                                  Статус_заявки = sz.Статус_заявки1,
                                  Начало_срока_действия = z.Начало_срока_действия,
                                  Конец_срока_действия = z.Конец_срока_действия,
                                  Цель_посещения = ps.Цель_посещения,
                                  Код_сотрудника_одобрившего_заявку = sz.Код_сотрудника_одобрившего_заявку,
                                  Фамилия_сотрудника = sotrud.Фамилия,
                                  Имя_сотрудника = sotrud.Имя,
                                  Отчество_сотрудника = sotrud.Отчество,
                                  Подразделение = podrazd.Название_подразделения
                              };
                data.ItemsSource = zayavka1.ToList();
            }



        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //фильтрация по статусу заявки
            using (var bd = new Хранитель_ПРО_КротоваEntities2())
            {
                
                var status = "Одобрено"; 

                var zayavka2 = from z in bd.Заявка_на_посещение
                              join sz in bd.Статус_заявки on z.Код_заявки equals sz.Код_заявки
                              join ps in bd.Пропуск on z.Код_заявки equals ps.Код_заявки
                              join sotrud in bd.Сотрудники on ps.Принимающий_сотрудник equals sotrud.Код_сотрудника
                              join podrazd in bd.Подразделение on sotrud.Код_подразделения equals podrazd.Код_подразделения
                              where sz.Статус_заявки1 == status
                              select new
                              {
                                  Код_заявки = z.Код_заявки,
                                  Статус_заявки = sz.Статус_заявки1,
                                  Начало_срока_действия = z.Начало_срока_действия,
                                  Конец_срока_действия = z.Конец_срока_действия,
                                  Цель_посещения = ps.Цель_посещения,
                                  Код_сотрудника_одобрившего_заявку = sz.Код_сотрудника_одобрившего_заявку,
                                  Фамилия_сотрудника = sotrud.Фамилия,
                                  Имя_сотрудника = sotrud.Имя,
                                  Отчество_сотрудника = sotrud.Отчество,
                                  Подразделение = podrazd.Название_подразделения
                              };

                data.ItemsSource = zayavka2.ToList();
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //открыть окно изменения статуса заявки
            ChangeStatus vo = new ChangeStatus();
            vo.Show();
            this.Close();
        }
    }
}
