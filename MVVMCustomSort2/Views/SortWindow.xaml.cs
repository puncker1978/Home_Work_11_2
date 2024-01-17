using MVVMCustomSort2.ViewModels;
using System.Windows;

namespace MVVMCustomSort2.Views
{
    /// <summary>
    /// Логика взаимодействия для SortWindow.xaml
    /// </summary>
    public partial class SortWindow : Window
    {
        public SortWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
