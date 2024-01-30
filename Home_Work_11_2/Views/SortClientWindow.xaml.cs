using Home_Work_11_2.Models.Clients;
using Home_Work_11_2.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
