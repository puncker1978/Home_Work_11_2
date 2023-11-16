using Home_Work_11_2.Models.Clients;
using Home_Work_11_2.ViewModels;
using System.Windows;

namespace Home_Work_11_2.Views
{
    /// <summary>
    /// Логика взаимодействия для EditClientWindow.xaml
    /// </summary>
    public partial class EditClientWindow : Window
    {
        public EditClientWindow(Client client)
        {
            InitializeComponent();
            this.DataContext = new EditClientViewModel(client);
        }
    }
}
