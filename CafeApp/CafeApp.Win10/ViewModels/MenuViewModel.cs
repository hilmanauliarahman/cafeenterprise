using System;
using System.Collections.Generic;
using System.Windows;
using System.Collections.ObjectModel;
using System.Data;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CafeApp.Win10.Models;
using CafeApp.Win10.ViewModels;
using CafeApp.Win10;

namespace CafeApp.Win10.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private ICommand simpanCommand;
        public ICommand _SimpanCommand
        {
            get
            {
                if (this.simpanCommand == null)
                {
                    this.simpanCommand = new SimpanCommand(this);
                }
                return this.simpanCommand;
            }
        }
        public MenuViewModel()
        {
            datatransaksi = new ObservableCollection<Transaksi>();
            datamenu = new ObservableCollection<Menu>();
            modelmenu = new Menu();
            modeltransaksi = new Transaksi();
            CreateCommand = new Command(async () => await CreateMenuAsync());
            UpdateCommand = new Command(async () => await UpdateMenuAsync());
            DeleteCommand = new Command(async () => await DeleteMenuAsync());
            DeleteTransaksiCommand = new Command(async () => await DeleteTransaksiAsync());
            CreateTransaksiCommand = new Command(async () => await CreateTransaksiAsync());
            ReadCommand = new Command(async () => await ReadMenuAsync(true));
            ReadTransaksiCommand = new Command(async () => await ReadTransaksiAsync(true));
            ReadCommand.Execute(null);
            ReadTransaksiCommand.Execute(null);
        }
        public ICommand CreateCommand { get; set; }
        public ICommand ReadCommand { get; set; }
        public ICommand CreateTransaksiCommand { get; set; }
        public ICommand ReadTransaksiCommand { get; set; }
        public ICommand DeleteTransaksiCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ObservableCollection<Menu> DataMenu
        {
            get
            {
                return datamenu;
            }
            set
            {
                SetProperty(ref datamenu, value);
            }
        }
        public Menu ModelMenu
        {
            get
            {
                return modelmenu;
            }
            set
            {
                SetProperty(ref modelmenu, value);
            }
        }
        public ObservableCollection<Transaksi> DataTransaksi
        {
            get
            {
                return datatransaksi;
            }
            set
            {
                SetProperty(ref datatransaksi, value);
            }
        }
        public Transaksi ModelTransaksi
        {
            get
            {
                return modeltransaksi;
            }
            set
            {
                SetProperty(ref modeltransaksi, value);
            }
        }

        private ObservableCollection<Menu> datamenu;
        private Menu modelmenu;
        private ObservableCollection<Transaksi> datatransaksi;
        private Transaksi modeltransaksi;
        public event Action OnReload;

        private async Task InitMenuAsync()
        {
            await Task.Run(() => {
                DataMenu = new ObservableCollection<Menu>
                {
                    new Menu { id_menu=1, nama="Teh Botol Sosro", id_jenis=2, komposisi="Teh", harga_pokok=2500, harga_jual=3000, status="Tersedia" },
                    new Menu { id_menu=2, nama="Mie Ayam", id_jenis=1, komposisi="Mie, Ayam, MSG", harga_pokok=6000, harga_jual=12000, status="Tersedia" },
                    new Menu { id_menu=3, nama="Bakso", id_jenis=1, komposisi="Terigu", harga_pokok=10000, harga_jual=18000, status="Tersedia" },
                    new Menu { id_menu=4, nama="Pempek", id_jenis=1, komposisi="Terigu dan Ikan", harga_pokok=15000, harga_jual=18000, status="Tersedia" }
                };
            });
        }
        private async Task InitTransaksiAsync()
        {
            await Task.Run(() => {
                DataTransaksi = new ObservableCollection<Transaksi> {
                    new Transaksi {id_transaksi=1, nama="aaaa", jumlah=3, harga_jual=1000, diskonpersen=0, total= 3000}
                };
            });
        }
        private async Task ReadMenuAsync(bool asnew = false)
        {
            if (asnew)
            {
                await InitMenuAsync();
            }
            else
            {
                OnReload?.Invoke();
            }
        }
        private async Task ReadTransaksiAsync(bool asnew = false)
        {
            if (asnew)
            {
                await InitTransaksiAsync();
            }
            else
            {
                OnReload?.Invoke();
            }
        }
        private async Task<Transaksi> ReadTransaksiAsync(int id_transaksi)
        {
            await Task.Delay(0);
            return DataTransaksi.Where(model => model.id_transaksi.Equals(id_transaksi)).SingleOrDefault();
        }
        private async Task<Menu> ReadMenuAsync(int id_menu)
        {
            await Task.Delay(0);
            return DataMenu.Where(model => model.id_menu.Equals(id_menu)).SingleOrDefault();
        }

        private async Task CreateMenuAsync()
        {
            DataMenu.Add(ModelMenu);
            await ReadMenuAsync();
        }
        private async Task CreateTransaksiAsync()
        {
            DataTransaksi.Add(ModelTransaksi);
            await ReadTransaksiAsync();
        }
        private async Task UpdateMenuAsync()
        {
            var data = ModelMenu;
            DataMenu.Remove(ReadMenuAsync(data.id_menu).Result);
            DataMenu.Add(data);
            await ReadMenuAsync();
        }

        private async Task DeleteMenuAsync()
        {
            DataMenu.Remove(ModelMenu);
            await ReadMenuAsync();
        }
        private async Task DeleteTransaksiAsync()
        {
            DataTransaksi.Remove(ModelTransaksi);
            await ReadTransaksiAsync();
        }
        public class SimpanCommand : ICommand
        {

            private MenuViewModel viewModel;

            public SimpanCommand(MenuViewModel viewModel)
            {
                this.viewModel = viewModel;
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public bool CanExecute(object parameter)
            {
                return viewModel.ModelMenu.id_menu > 0;
            }

            public void Execute(object parameter)
            {
                using (var db = new Dbconfig())
                {
                    db.Database.Log = Console.Write;
                    db.Cafeenterprise.Add(viewModel.ModelMenu);
                    db.SaveChanges();
                    MessageBox.Show("Data berhasil disimpan ke database");
                }
            }

        }
    }
}
