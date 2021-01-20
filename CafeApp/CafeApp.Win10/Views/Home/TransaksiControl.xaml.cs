using System;
using System.Collections;
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
using CafeApp.Win10.Models;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CafeApp.Win10.Views.Home
{
    /// <summary>
    /// Interaction logic for TransaksiControl.xaml
    /// </summary>
    public partial class TransaksiControl : UserControl
    {
        ArrayList mylist;
        string currentitem = string.Empty;
        int index = 0;
        int total;
        public TransaksiControl()
        {
            InitializeComponent();
            vm2 = new MenuViewModel();
            DataContext = new {
                extendedInfo = vm2
            };
            mylist = loadlistbox();
            ListMenu.ItemsSource = mylist;
            ListMenu.FontSize = 20;
            ListTransaksi.FontSize = 20;
            //int totalitempesanan = ListTransaksi.Items.Count;

            
            int totalitempesanan2 = ListTransaksi.Items.Count;

            for (int i = 0; i < totalitempesanan2; i++)
                {
                    //Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                    var str = Regex.Replace(mylist[i].ToString(), "[^0-9]", "");
                    var subtotal = int.Parse(str);
                    total += subtotal;
                    ListTransaksi.Items.Refresh();
            }
                totalpesanan.Content = total;
                
        }
        private ArrayList loadlistbox()
        {
            ArrayList list = new ArrayList();
            list.Add(string.Format("{0}  {1}", "Teh Botol Sosro", 3000));
            list.Add(string.Format("{0}  {1}", "Mie Ayam", 12000));
            list.Add(string.Format("{0}  {1}", "Bakso", 18000));
            list.Add(string.Format("{0}  {1}", "Pempek", 18000));
            ListTransaksi.Items.Refresh();
            return list;
        }

        private MenuViewModel vm2;
        private ListMenu form;
        private async void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(0);
            vm2.ModelTransaksi = null;
            BtnReset.Visibility = Visibility.Hidden;
        }
        private async Task InitFormAsync()
        {
            await Task.Delay(0);
            form = new ListMenu(vm2);
            form.ShowDialog();
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            App.viewRouting(false);
        }


        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            vm2.ModelMenu = null;
            await InitFormAsync();
        }

        private void BtnNew_Click_1(object sender, RoutedEventArgs e)
        {
            currentitem = ListMenu.SelectedValue.ToString();
            index = ListMenu.SelectedIndex;
            //MessageBox.Show(total.ToString());
            ListTransaksi.Items.Add(currentitem);
            ListTransaksi.Items.Refresh();
            bindlewlist();
        }

        private void bindlewlist()
        {
            ListMenu.ItemsSource = null;
            ListMenu.ItemsSource = mylist;
            ListTransaksi.Items.Refresh();
        }
    }
}
