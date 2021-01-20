using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CafeApp.Win10.Models;
using CafeApp.Win10.ViewModels;

namespace CafeApp.Win10.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            dataadmin = new ObservableCollection<Admin>();
            modeladmin = new Admin();

            CreateCommand = new Command(async () => await CreateAdminAsync());
            UpdateCommand = new Command(async () => await UpdateAdminAsync());
            DeleteCommand = new Command(async () => await DeleteAdminAsync());
            ReadCommand = new Command(async () => await ReadAdminAsync(true));
            ReadCommand.Execute(null);
        }

        public ICommand CreateCommand { get; set; }
        public ICommand ReadCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ObservableCollection<Admin> DataAdmin
        {
            get
            {
                return dataadmin;
            }
            set
            {
                SetProperty(ref dataadmin, value);
            }
        }

        public Admin ModelAdmin
        {
            get
            {
                return modeladmin;
            }
            set
            {
                SetProperty(ref modeladmin, value);
            }
        }

        private ObservableCollection<Admin> dataadmin;
        private Admin modeladmin;

        public event Action OnReload;

        private async Task InitAdminAsync()
        {
            await Task.Run(()=> {
                DataAdmin = new ObservableCollection<Admin>
                {
                    new Admin {id_admin = 1, username = "admin", password = "admin"}
                };
            });
        }
        private async Task ReadAdminAsync(bool asnew = false)
        {
            if (asnew)
            {
                await InitAdminAsync();
            }
            else
            {
                OnReload?.Invoke();
            }
        }

        private async Task<Admin> ReadAdminAsync(string username)
        {
            await Task.Delay(0);
            return DataAdmin.Where(model => model.username.Equals(username)).SingleOrDefault();
        }

        private async Task CreateAdminAsync()
        {
            DataAdmin.Add(ModelAdmin);
            await ReadAdminAsync();
        }

        private async Task UpdateAdminAsync()
        {
            var data = ModelAdmin;
            DataAdmin.Remove(ReadAdminAsync(data.username).Result);
            DataAdmin.Add(ModelAdmin);
            await ReadAdminAsync();
        }

        private async Task DeleteAdminAsync()
        {
            DataAdmin.Remove(ModelAdmin);
            await ReadAdminAsync();
        }
    }
}
