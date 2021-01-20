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
    public class JenisViewModel : BaseViewModel
    {
        public JenisViewModel()
        {
            datajenis = new ObservableCollection<Jenis>();
            modeljenis = new Jenis();
            CreateCommand = new Command(async () => await CreateJenisAsync());
            UpdateCommand = new Command(async () => await UpdateJenisAsync());
            DeleteCommand = new Command(async () => await DeleteJenisAsync());
            ReadCommand = new Command(async () => await ReadJenisAsync(true));
            ReadCommand.Execute(null);
        }
        public ICommand CreateCommand { get; set; }
        public ICommand ReadCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ObservableCollection<Jenis> DataJenis
        {
            get
            {
                return datajenis;
            }
            set
            {
                SetProperty(ref datajenis, value);
            }
        }
        public Jenis ModelJenis
        {
            get
            {
                return modeljenis;
            }
            set
            {
                SetProperty(ref modeljenis, value);
            }
        }

        private ObservableCollection<Jenis> datajenis;
        private Jenis modeljenis;

        public event Action OnReload;

        private async Task InitJenisAsync()
        {
            await Task.Run(() => {
                DataJenis = new ObservableCollection<Jenis>
                {
                    new Jenis { id_jenis=1, nama_jenis="Makanan" },
                    new Jenis { id_jenis=2, nama_jenis="Minuman" }
                };
            });
        }
        private async Task ReadJenisAsync(bool asnew = false)
        {
            if (asnew)
            {
                await InitJenisAsync();
            }
            else
            {
                OnReload?.Invoke();
            }
        }

        private async Task<Jenis> ReadJenisAsync(int id_jenis)
        {
            await Task.Delay(0);
            return DataJenis.Where(model => model.id_jenis.Equals(id_jenis)).SingleOrDefault();
        }

        private async Task CreateJenisAsync()
        {
            DataJenis.Add(ModelJenis);
            await ReadJenisAsync();
        }

        private async Task UpdateJenisAsync()
        {
            var data = ModelJenis;
            DataJenis.Remove(ReadJenisAsync(data.id_jenis).Result);
            DataJenis.Add(data);
            await ReadJenisAsync();
        }

        private async Task DeleteJenisAsync()
        {
            DataJenis.Remove(ModelJenis);
            await ReadJenisAsync();
        }
    }
}
