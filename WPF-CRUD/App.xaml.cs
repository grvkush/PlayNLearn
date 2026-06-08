using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_CRUD
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            HomePage wnd = new HomePage();
            YesNo page = new YesNo();
            
            wnd.Show();
            wnd.MainFrame.Navigate(page);
        }
    }
}
