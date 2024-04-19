﻿using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
    /// Логика взаимодействия для Групповое_посещение.xaml
    /// </summary>
    public partial class Групповое_посещение : Window
    {
        public Групповое_посещение()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var bd = new Хранитель_ПРО_КротоваEntities())
                {
                    var propusk = new Пропуск();
                    propusk.Код_заявки = Convert.ToInt32(zayavka.Text);
                    propusk.Цель_посещения = Цель.Text;
                    propusk.Принимающий_сотрудник = Convert.ToInt32(Номер_сотрудника.Text);
                    bd.Пропуск.Add(propusk);

                    // Проверяем существование пользователя по серии и номеру паспорта
                    var existingUser = bd.Пользователи.FirstOrDefault(user => user.Серия_паспорта == paspseria.Text && user.Номер_паспорта == paspnomer.Text);
                    if (existingUser == null)
                    {
                        // Если пользователя с такими паспортными данными нет, добавляем нового пользователя
                        var posetitel = new Пользователи();
                        posetitel.Фамилия = LastName.Text;
                        posetitel.Имя = Namee.Text;
                        posetitel.Отчество = Otchestvo.Text;
                        posetitel.Дата_рождения = datebirth.SelectedDate.Value.Date;
                        posetitel.Номер_телефона = tel.Text;
                        posetitel.Серия_паспорта = paspseria.Text;
                        posetitel.Номер_паспорта = paspnomer.Text;
                        posetitel.Email = email.Text;
                        bd.Пользователи.Add(posetitel);
                    }

                    var Zayavka = new Заявка_на_посещение();
                    Zayavka.Код_заявки = Convert.ToInt32(zayavka.Text);
                    Zayavka.Начало_срока_действия = dat1.SelectedDate.Value.Date;
                    Zayavka.Конец_срока_действия = dat2.SelectedDate.Value.Date;
                    bd.Заявка_на_посещение.Add(Zayavka);

                    var Grupp = new Группы_посещения();
                    Grupp.Код_группы = Convert.ToInt32(Код_группы1.Text);
                    Grupp.Название_группы = Название_группы1.Text;
                    Grupp.Код_пользователя = Пользователи1.Text;
                    bd.Группы_посещения.Add(Grupp);

                    // Вызываем SaveChanges 
                    bd.SaveChanges();

                    MessageBox.Show("Данные успешно сохранены!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при сохранении данных: {ex.Message}\n\nДополнительные сведения: {ex.InnerException?.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dat1.SelectedDate = null;
            dat2.SelectedDate = null;
            Цель.Clear();
            LastName.Clear();
            Номер_сотрудника.Clear();
            Namee.Clear();
            Otchestvo.Clear();
            tel.Clear();
            email.Clear();
            datebirth.SelectedDate = null;
            paspseria.Clear();
            paspnomer.Clear();
            zayavka.Clear();
            Код_группы1.Clear();
            Название_группы1.Clear();
            Пользователи1.Clear();
        }
    }
}
