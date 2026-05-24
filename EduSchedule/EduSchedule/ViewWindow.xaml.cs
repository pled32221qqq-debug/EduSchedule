using System.Collections.ObjectModel;
using System.Windows;

namespace EduSchedule
{
    public partial class ViewWindow : Window
    {
        public ViewWindow()
        {
            InitializeComponent();

            var data = new ObservableCollection<ScheduleItem>
            {
                new ScheduleItem { Id = 1, Group = "ИСП-401", Discipline = "Базы данных", Teacher = "Иванов А.А.", Room = "201", Day = 1, Period = 1 },
                new ScheduleItem { Id = 2, Group = "ИСП-402", Discipline = "Web-программирование", Teacher = "Иванов А.А.", Room = "203", Day = 3, Period = 3 }
            };

            dgView.ItemsSource = data;
        }
    }
}