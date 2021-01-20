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
using System.Threading.Tasks;
namespace CafeApp.Win10.Views.Home
{
    /// <summary>
    /// Interaction logic for ItemControl.xaml
    /// </summary>
    public partial class ItemControl : UserControl
    {
        public ItemControl()
        {
            InitializeComponent();
            vm = new MenuViewModel();
            vm.OnReload += () => {
                ListData.ItemsSource = null;
                ListData.ItemsSource = vm.DataMenu;
                if(form != null)
                {
                    form.Close();
                }
                vm.ModelMenu = null;
                BtnEdit.Visibility = Visibility.Hidden;
                BtnReset.Visibility = Visibility.Hidden;
            };
            BtnEdit.Visibility = Visibility.Hidden;
            BtnReset.Visibility = Visibility.Hidden;
            DataContext = vm;
        }

        private MenuViewModel vm;
        private Item form;

        private async Task InitFormAsync()
        {
            await Task.Delay(0);
            form = new Item(vm);
            form.ShowDialog();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ((Window)Parent).ResizeMode = ResizeMode.NoResize;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            App.viewRouting(false);
        }

        private async void BtnNew_Click_1(object sender, RoutedEventArgs e)
        {
            vm.ModelMenu = null;
            await InitFormAsync();
            //Item item = new Item();
            //item.ShowDialog();
        }
        private async void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            await InitFormAsync();
        }
        private async void ListData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await Task.Delay(0);
            if(vm.ModelMenu != null)
            {
                BtnEdit.Visibility = Visibility.Visible;
                BtnReset.Visibility = Visibility.Visible;
            }
        }

        private async void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(0);
            vm.ModelMenu = null;
            
                BtnEdit.Visibility = Visibility.Hidden;
                BtnReset.Visibility = Visibility.Hidden;
            
        }
    }
}
