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
using CafeApp.Win10.Views.Home;
using System.Threading.Tasks;

namespace CafeApp.Win10.Views
{
    /// <summary>
    /// Interaction logic for JenisControl.xaml
    /// </summary>
    public partial class JenisControl : UserControl
    {
        public JenisControl()
        {
            InitializeComponent();
            vm = new JenisViewModel();
            vm.OnReload += () => {
                ListData.ItemsSource = null;
                ListData.ItemsSource = vm.DataJenis;
                if (form != null)
                {
                    form.Close();
                }
                vm.ModelJenis = null;
                BtnEdit.Visibility = Visibility.Hidden;
                BtnReset.Visibility = Visibility.Hidden;
            };
            BtnEdit.Visibility = Visibility.Hidden;
            BtnReset.Visibility = Visibility.Hidden;
            DataContext = vm;
        }
        private JenisViewModel vm;
        private Jenis form;
        private async Task InitFormAsync()
        {
            await Task.Delay(0);
            form = new Jenis(vm);
            form.ShowDialog();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ((Window)Parent).ResizeMode = ResizeMode.NoResize;
        }
        private async void ListData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await Task.Delay(0);
            if (vm.ModelJenis != null)
            {
                BtnEdit.Visibility = Visibility.Visible;
                BtnReset.Visibility = Visibility.Visible;
            }
        }

        private async void BtnNew_Click_1(object sender, RoutedEventArgs e)
        {
            vm.ModelJenis = null;
            await InitFormAsync();
        }

        private async void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            await InitFormAsync();
        }

        private async void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(0);
            vm.ModelJenis = null;

            BtnEdit.Visibility = Visibility.Hidden;
            BtnReset.Visibility = Visibility.Hidden;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            App.viewRouting(false);
        }
    }
}
