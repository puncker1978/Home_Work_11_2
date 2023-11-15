using Home_Work_11_2.Infra;
using Home_Work_11_2.Models.Employees;
using Home_Work_11_2.Views;
using System.Windows.Input;
using System.Windows;

namespace Home_Work_11_2.ViewModels
{
    internal class LoginWindowViewModel : PropertyChangedBase
    {
        private string[] positions = { "Консультант", "Менеджер" };
        public string[] Positions { get => positions; }

        private Employee employee;

        public LoginWindowViewModel()
        {
            ShowMainWindowCommand = new RelayCommand(ShowMainWindow, CanShowMainWindow);
        }

        public Employee Employee
        {
            get => employee;
            set
            {
                employee = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand ShowMainWindowCommand { get; set; }

        private bool CanShowMainWindow(object obj)
        {
            return true;
        }

        private void ShowMainWindow(object obj)
        {
            MainWindow mainWindow = new();
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mainWindow.Show();

            //Получить ссылку на текущее окно
            Window loginWindow = Application.Current.Windows.OfType<NewClientWindow>().SingleOrDefault(x => x.IsActive);

            // Закрыть текущее окно
            loginWindow?.Close();
        }


    }
}
