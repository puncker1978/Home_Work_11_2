using Home_Work_11_2.ViewModels;
using System.Windows;

namespace Home_Work_11_2.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(string Position)
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(Position);
        }
    }
}
