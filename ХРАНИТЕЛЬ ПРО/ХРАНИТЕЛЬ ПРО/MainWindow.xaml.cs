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

namespace ХРАНИТЕЛЬ_ПРО
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Хранитель_ПРО_КротоваEntities()) //подключение к бд
            {
                // Поиск пользователя по введенному логину и паролю в таблице "Личное посещение"
                var personalVisitUser = db.Личное_посещение.FirstOrDefault(user => user.Логин == log.Text && user.Пароль == par.Text);

                // Поиск пользователя по введенному логину и паролю в таблице "Групповое посещение"
                var groupVisitUser = db.Групповое_посещение.FirstOrDefault(user => user.Логин == log.Text && user.Пароль == par.Text);

                // Проверка, существует ли пользователь с такими данными хотя бы в одной из таблиц
                if (personalVisitUser == null && groupVisitUser == null)
                {
                    MessageBox.Show("Неверно введен логин или пароль");
                }
                else
                {
                    MessageBox.Show("Вы успешно авторизованы");
                }
                // Открытие нового окна после успешной аутентификации
                Главное_окно newWindow = new Главное_окно();
                newWindow.Show();
                Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Открытие окна просмотра заявок
            Prosmotr_zayavok newWindow = new Prosmotr_zayavok();
            newWindow.Show();
            Close();
        }
    }
}
