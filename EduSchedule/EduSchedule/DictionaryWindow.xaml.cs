using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace EduSchedule
{
    public partial class DictionaryWindow : Window
    {
        private ObservableCollection<Group> _groups;
        private ObservableCollection<Teacher> _teachers;
        private ObservableCollection<Discipline> _disciplines;
        private ObservableCollection<Room> _rooms;

        public DictionaryWindow()
        {
            InitializeComponent();
            LoadDictionaries();
        }

        private void LoadDictionaries()
        {
            _groups = new ObservableCollection<Group>
            {
                new Group { Id = 1, Name = "ИСП-401" },
                new Group { Id = 2, Name = "ИСП-402" },
                new Group { Id = 3, Name = "ЭК-201" }
            };
            dgGroups.ItemsSource = _groups;

            _teachers = new ObservableCollection<Teacher>
            {
                new Teacher { Id = 1, Name = "Иванов А.А." },
                new Teacher { Id = 2, Name = "Петрова М.И." }
            };
            dgTeachers.ItemsSource = _teachers;

            _disciplines = new ObservableCollection<Discipline>
            {
                new Discipline { Id = 1, Name = "Базы данных" },
                new Discipline { Id = 2, Name = "C# Программирование" }
            };
            dgDisciplines.ItemsSource = _disciplines;

            _rooms = new ObservableCollection<Room>
            {
                new Room { Id = 1, Number = "201", Type = "Лекционная" },
                new Room { Id = 2, Number = "202", Type = "Компьютерная" }
            };
            dgRooms.ItemsSource = _rooms;
        }

        // --- Группы ---
        private void BtnAddGroup_Click(object sender, RoutedEventArgs e)
        {
            string newName = ShowInputDialog("Введите название группы:", "Добавление группы");
            if (!string.IsNullOrWhiteSpace(newName))
            {
                _groups.Add(new Group { Id = _groups.Count + 1, Name = newName });
            }
        }
        private void BtnDeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            if (dgGroups.SelectedItem != null)
                _groups.Remove((Group)dgGroups.SelectedItem);
            else
                MessageBox.Show("Выберите группу для удаления!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        // --- Преподаватели ---
        private void BtnAddTeacher_Click(object sender, RoutedEventArgs e)
        {
            string newName = ShowInputDialog("Введите ФИО преподавателя:", "Добавление преподавателя");
            if (!string.IsNullOrWhiteSpace(newName))
            {
                _teachers.Add(new Teacher { Id = _teachers.Count + 1, Name = newName });
            }
        }
        private void BtnDeleteTeacher_Click(object sender, RoutedEventArgs e)
        {
            if (dgTeachers.SelectedItem != null)
                _teachers.Remove((Teacher)dgTeachers.SelectedItem);
            else
                MessageBox.Show("Выберите преподавателя для удаления!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        // --- Дисциплины ---
        private void BtnAddDisc_Click(object sender, RoutedEventArgs e)
        {
            string newName = ShowInputDialog("Введите название дисциплины:", "Добавление дисциплины");
            if (!string.IsNullOrWhiteSpace(newName))
            {
                _disciplines.Add(new Discipline { Id = _disciplines.Count + 1, Name = newName });
            }
        }
        private void BtnDeleteDisc_Click(object sender, RoutedEventArgs e)
        {
            if (dgDisciplines.SelectedItem != null)
                _disciplines.Remove((Discipline)dgDisciplines.SelectedItem);
            else
                MessageBox.Show("Выберите дисциплину для удаления!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        // --- Аудитории ---
        private void BtnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            string newNumber = ShowInputDialog("Введите номер аудитории:", "Добавление аудитории");
            if (!string.IsNullOrWhiteSpace(newNumber))
            {
                _rooms.Add(new Room { Id = _rooms.Count + 1, Number = newNumber, Type = "Лекционная" });
            }
        }
        private void BtnDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            if (dgRooms.SelectedItem != null)
                _rooms.Remove((Room)dgRooms.SelectedItem);
            else
                MessageBox.Show("Выберите аудиторию для удаления!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        // Простое диалоговое окно для ввода текста
        private string ShowInputDialog(string prompt, string title)
        {
            var window = new Window
            {
                Title = title,
                Width = 300,
                Height = 150,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this,
                ResizeMode = ResizeMode.NoResize
            };

            var grid = new Grid { Margin = new Thickness(10) };
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            var textBlock = new TextBlock { Text = prompt, Margin = new Thickness(0, 0, 0, 10), TextWrapping = TextWrapping.Wrap };
            var textBox = new TextBox { Margin = new Thickness(0, 0, 0, 10) };

            var stackPanel = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Right };
            var btnOk = new Button { Content = "OK", Width = 60, Margin = new Thickness(0, 0, 5, 0) };
            var btnCancel = new Button { Content = "Отмена", Width = 60 };

            btnOk.Click += (s, e) => { window.DialogResult = true; window.Close(); };
            btnCancel.Click += (s, e) => { window.DialogResult = false; window.Close(); };

            stackPanel.Children.Add(btnOk);
            stackPanel.Children.Add(btnCancel);
            grid.Children.Add(textBlock);
            grid.Children.Add(textBox);
            Grid.SetRow(textBox, 1);
            Grid.SetRow(stackPanel, 2);
            grid.Children.Add(stackPanel);

            window.Content = grid;

            if (window.ShowDialog() == true)
                return textBox.Text;

            return "";
        }
    }
}