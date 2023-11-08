using Home_Work_11_2.ViewModels;
using Home_Work_11_2.Models;
using System.Windows;

namespace Home_Work_11_2.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel mainWindowViewModel = new();
            this.DataContext = mainWindowViewModel;
        }
    }
}
