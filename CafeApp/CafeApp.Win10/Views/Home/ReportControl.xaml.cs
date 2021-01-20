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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CafeApp.Win10.ViewModels;

namespace CafeApp.Win10.Views.Home
{
    /// <summary>
    /// Interaction logic for ReportControl.xaml
    /// </summary>
    public partial class ReportControl : UserControl
    {
        public ReportControl()
        {
            InitializeComponent();
            vm = new TransaksiViewModel();
            vm.OnReload += () => {
                ListData.ItemsSource = null;
                ListData.ItemsSource = vm.DataTransaksi;
                vm.ModelTransaksi = null;
            };
            DataContext = vm;

        }
        private TransaksiViewModel vm;

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            App.viewRouting(false);
        }
    }
}
