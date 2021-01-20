using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CafeApp.Win10.ViewModels;
using CafeApp.Win10.Models;

namespace CafeApp.Win10.Views.Home
{
    /// <summary>
    /// Interaction logic for ListMenu.xaml
    /// </summary>
    public partial class ListMenu : Window
    {
        public ListMenu(MenuViewModel vm2)
        {
            InitializeComponent();
            DataContext = new {
                extendedInfo = vm2
            };
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ListData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
