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
using CafeApp.Win10.Views.Login;

namespace CafeApp.Win10.Views.Home
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        bool _shown;

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            if (_shown)
                return;

            _shown = true;
            Dashboard db = new Dashboard();
            db._shown = false;
            LoginWindow wnd = new LoginWindow();
            wnd.Owner = this;
            wnd.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            wnd.ShowDialog();
        }
        private void MyDashboard_shown(object sender, EventArgs e)
        {
            LoginWindow loginatuh = new LoginWindow();
            loginatuh.ShowDialog();
        }
        private void MnuExit_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginatuh = new LoginWindow();
            loginatuh.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            App.viewRouting(false);
            App.viewRouting(true, new Home.ItemControl());
            //ItemControl showpanel = new ItemControl();
            //showpanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            //showpanel.VerticalAlignment = VerticalAlignment.Stretch;

            //PnlContent.Children.Add(showpanel);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.viewRouting(false);
            App.viewRouting(true, new JenisControl());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.viewRouting(false);
            App.viewRouting(true, new Home.TransaksiControl());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            App.viewRouting(false);
            App.viewRouting(true, new Home.ReportControl());
        }
    }
}
