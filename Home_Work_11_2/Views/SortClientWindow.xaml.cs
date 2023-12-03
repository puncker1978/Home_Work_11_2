using Home_Work_11_2.ViewModels;
using System.Windows;

namespace Home_Work_11_2.Views
{
    /// <summary>
    /// Логика взаимодействия для SortClientWindow.xaml
    /// </summary>
    public partial class SortClientWindow : Window
    {
        public SortClientWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }
    }
}
