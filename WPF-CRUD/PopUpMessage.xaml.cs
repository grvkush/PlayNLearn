using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_CRUD
{
    /// <summary>
    /// Interaction logic for PopUpMessage.xaml
    /// </summary>
    public partial class PopUpMessage : Window
    {
        public PopUpMessage(string message)
        {
            InitializeComponent();
            txtMessage.Text = message;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public static void Show(string message)
        {
            PopUpMessage box = new PopUpMessage(message);
            box.ShowDialog();
        }
    }
}
