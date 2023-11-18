using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WorkWithDateTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            calendar.BlackoutDates.Add(new CalendarDateRange(new System.DateTime(2022, 5, 20), new System.DateTime(2022, 5, 23)));
            calendar.SelectedDate = new System.DateTime(2022, 5, 18);
        }
        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            txt.Text = $"{calendar.SelectedDate:dd.MM.yyyy}";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            up.IsOpen = true;
        }
    }
}