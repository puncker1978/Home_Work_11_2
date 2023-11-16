using Home_Work_11_2.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Home_Work_11_2.Views
{
    /// <summary>
    /// Логика взаимодействия для NewClientWindow.xaml
    /// </summary>
    public partial class NewClientWindow : Window
    {
        public NewClientWindow()
        {
            InitializeComponent();
            this.DataContext = new NewClientViewModel();
        }
    }
}
