using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EduSchedule
{
    public partial class ReplacementWindow : Window
    {
        private ObservableCollection<ScheduleItem> _scheduleData;
        private ScheduleItem _selectedPair;

        public ReplacementWindow()
        {
            InitializeComponent();
            LoadMockData();
        }

        private void LoadMockData()
        {
            _scheduleData = new ObservableCollection<ScheduleItem>
            {
                new ScheduleItem { Id = 1, Day = 1, Period = 1, Group = "ИСП-401", Discipline = "Базы данных", Teacher = "Иванов А.А.", Room = "201" },
                new ScheduleItem { Id = 2, Day = 2, Period = 2, Group = "ИСП-402", Discipline = "C# Программирование", Teacher = "Петрова М.И.", Room = "203" },
                new ScheduleItem { Id = 3, Day = 3, Period = 3, Group = "ЭК-201", Discipline = "Экономика", Teacher = "Сидоров П.С.", Room = "105" }
            };
            dgSchedule.ItemsSource = _scheduleData;

            cbCurrentPair.ItemsSource = _scheduleData;
            cbNewTeacher.ItemsSource = new ObservableCollection<Teacher>
            {
                new Teacher { Id = 101, Name = "Козлов Д.В." },
                new Teacher { Id = 102, Name = "Николаева Е.М." }
            };
            cbNewRoom.ItemsSource = new ObservableCollection<Room>
            {
                new Room { Id = 201, Number = "201", Type = "Лекционная" },
                new Room { Id = 202, Number = "202", Type = "Компьютерная" }
            };
        }

        private void CbPair_Changed(object sender, SelectionChangedEventArgs e)
        {
            _selectedPair = cbCurrentPair.SelectedItem as ScheduleItem;
            lblStatus.Text = "Пара выбрана. Нажмите «Проверить».";
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedPair == null)
            {
                lblStatus.Text = "⚠ Сначала выберите пару из списка!";
                lblStatus.Foreground = System.Windows.Media.Brushes.Red;
                return;
            }

            // Имитация проверки доступности
            lblStatus.Text = "✅ Преподаватель свободен. Аудитория доступна.";
            lblStatus.Foreground = System.Windows.Media.Brushes.Green;
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedPair == null) return;

            string newTeacher = (cbNewTeacher.SelectedItem as Teacher)?.Name ?? "Не выбран";
            string newRoom = (cbNewRoom.SelectedItem as Room)?.Number ?? "Не выбрана";

            // Обновляем данные в памяти
            _selectedPair.Teacher = newTeacher;
            _selectedPair.Room = newRoom;
            dgSchedule.Items.Refresh();

            MessageBox.Show($"Замена подтверждена!\nНовый преподаватель: {newTeacher}\nНовая аудитория: {newRoom}",
                            "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}