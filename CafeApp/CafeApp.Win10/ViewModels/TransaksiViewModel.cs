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
    public class TransaksiViewModel : BaseViewModel
    {
        public TransaksiViewModel()
        {
            datatransaksi = new ObservableCollection<Transaksi>();
            modeltransaksi = new Transaksi();
            CreateCommand = new Command(async () => await CreateTransaksiAsync());
            DeleteCommand = new Command(async () => await DeleteTransaksiAsync());
            ReadCommand = new Command(async () => await ReadTransaksiAsync(true));
            ReadCommand.Execute(null);
        }
        public ICommand CreateCommand { get; set; }
        public ICommand ReadCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
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
        private ObservableCollection<Transaksi> datatransaksi;
        private Transaksi modeltransaksi;

        public event Action OnReload;

        private async Task InitTransaksiAsync()
        {
            await Task.Run(() => {
                DataTransaksi = new ObservableCollection<Transaksi> {
                    new Transaksi {}
                };
            });
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

        private async Task CreateTransaksiAsync()
        {
            DataTransaksi.Add(ModelTransaksi);
            await ReadTransaksiAsync();
        }

        private async Task DeleteTransaksiAsync()
        {
            DataTransaksi.Remove(ModelTransaksi);
            await ReadTransaksiAsync();
        }


    }
}
