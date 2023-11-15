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
        public Employee Employee
        {
            get => employee;
            set
            {
                employee = value;
                NotifyPropertyChanged();
            }
        }


        private string position;
        public string Position
        {
            get => position;
            set
            {
                position = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand ShowMainWindowCommand { get; set; }

        private bool CanShowMainWindow(object obj)
        {
            return !string.IsNullOrEmpty(Position);
        }

        private void ShowMainWindow(object obj)
        {
            MainWindow mainWindow = new(Position);
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //Получить ссылку на текущее окно
            LoginWindow? loginWindow = Application.Current.Windows.OfType<LoginWindow>().SingleOrDefault(x => x.IsActive);

            // Закрыть текущее окно
            loginWindow?.Close();


            mainWindow.Show();
        }

        public LoginWindowViewModel()
        {
            ShowMainWindowCommand = new RelayCommand(ShowMainWindow, CanShowMainWindow);
        }
    }
}
