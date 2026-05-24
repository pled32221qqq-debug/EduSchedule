using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace EduSchedule
{
    public class ScheduleItem
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public string Discipline { get; set; }
        public string Teacher { get; set; }
        public string Room { get; set; }
        public int Day { get; set; }
        public int Period { get; set; }
    }

    public partial class ScheduleWindow : Window
    {
        private ObservableCollection<ScheduleItem> _data;
        private int _nextId = 1;

        public ScheduleWindow()
        {
            InitializeComponent();
            _data = new ObservableCollection<ScheduleItem>();
            dgSchedule.ItemsSource = _data;

            cbGroup.Items.Add("ИСП-401");
            cbGroup.Items.Add("ИСП-402");
            cbGroup.Items.Add("ЭК-201");
            cbGroup.SelectedIndex = 0;

            LoadMockData();
        }

        private void LoadMockData()
        {
            _data.Clear();
            _data.Add(new ScheduleItem { Id = _nextId++, Group = "ИСП-401", Discipline = "Базы данных", Teacher = "Иванов А.А.", Room = "201", Day = 1, Period = 1 });
            _data.Add(new ScheduleItem { Id = _nextId++, Group = "ИСП-401", Discipline = "C# Программирование", Teacher = "Петрова М.И.", Room = "202", Day = 2, Period = 2 });
        }

        private void CbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e) => FilterData();
        private void BtnRefresh_Click(object sender, RoutedEventArgs e) => LoadMockData();

        private void FilterData()
        {
            string selectedGroup = cbGroup.SelectedItem?.ToString();
            // Простая фильтрация (в реальном проекте — LINQ)
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbDiscipline.Text) || string.IsNullOrWhiteSpace(tbTeacher.Text))
            {
                MessageBox.Show("Заполните поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _data.Add(new ScheduleItem
            {
                Id = _nextId++,
                Group = cbGroup.SelectedItem?.ToString(),
                Discipline = tbDiscipline.Text,
                Teacher = tbTeacher.Text,
                Room = tbRoom.Text,
                Day = int.Parse(tbDay.Text),
                Period = int.Parse(tbPeriod.Text)
            });

            MessageBox.Show("✅ Пара добавлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}