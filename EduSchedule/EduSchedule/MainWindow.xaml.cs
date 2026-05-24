using System.Windows;

namespace EduSchedule
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSchedule_Click(object sender, RoutedEventArgs e)
        {
            new ScheduleWindow().ShowDialog();
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            new ViewWindow().ShowDialog();
        }

        private void BtnReplace_Click(object sender, RoutedEventArgs e)
        {
            new ReplacementWindow().ShowDialog();
        }

        private void BtnDict_Click(object sender, RoutedEventArgs e)
        {
            new DictionaryWindow().ShowDialog();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}