using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using CafeApp.Win10.Views.Home;
using CafeApp.Win10.Views.Login;
using CafeApp.Win10.Models;

namespace CafeApp.Win10
{
    public partial class App : Application
    {
        public static Dashboard View { get; set; }
            
            public static void viewRouting(bool flag, Control content = null)
            {
                if(flag == true)
                {
                    View.PnlContent.Children.Add(content);
                }else
                {
                View.PnlContent.Children.Clear();
                }
            }
            private void Application_Startup(object sender, StartupEventArgs e)
            {
                View = new Dashboard();
                View.Show();
            }
    }
}
