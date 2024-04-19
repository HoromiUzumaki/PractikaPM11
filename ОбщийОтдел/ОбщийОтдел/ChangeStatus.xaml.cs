using System.Linq;
using System.Windows;
using System.Data.Entity;

namespace ОбщийОтдел
{
    public partial class ChangeStatus : Window
    {
        private Хранитель_ПРО_КротоваEntities2 _context;

        public ChangeStatus()
        {
            InitializeComponent();
            _context = new Хранитель_ПРО_КротоваEntities2();
            LoadOrderCodes();
            LoadStatuses();
            SetSelectedStatus();
        }

        private void LoadOrderCodes()
        {
            orderComboBox.ItemsSource = _context.Заявка_на_посещение.Select(o => o.Код_заявки).ToList();
        }

        private void LoadStatuses()
        {
            statusComboBox.ItemsSource = new string[] { "Отказано", "Одобрено" };
        }

        private void SetSelectedStatus()
        {
            // Получение текущего статуса заявки 
            string selectedStatusString = "Отказано"; // Пример текущего статуса

            // Установка выбранного статуса в ComboBox
            statusComboBox.SelectedItem = selectedStatusString;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(orderComboBox.SelectedItem.ToString(), out int code))
            {
                var newStatusString = statusComboBox.SelectedItem as string;

                var order = _context.Заявка_на_посещение.Include("Статус_заявки").FirstOrDefault(o => o.Код_заявки == code);
                var newStatus = _context.Статус_заявки.FirstOrDefault(s => s.Статус_заявки1 == newStatusString);

                if (order != null && newStatus != null)
                {
                    order.Статус_заявки = newStatus;
                    _context.SaveChanges();
                    MessageBox.Show("Статус заявки успешно обновлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Заявка с указанным кодом не найдена или выбран некорректный статус.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите корректный код заявки.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
