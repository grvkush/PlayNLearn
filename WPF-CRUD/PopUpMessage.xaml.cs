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
using System.Windows.Threading;

namespace WPF_CRUD
{
    /// <summary>
    /// Interaction logic for PopUpMessage.xaml
    /// </summary>
    public partial class PopUpMessage : Window
    {
        private DispatcherTimer autoCloseTimer;

        public PopUpMessage(PopUpData message)
        {
            InitializeComponent();
            txtMessage.Text = message.Message;
            imgIcon.Source = new BitmapImage(new Uri(message.ImgPath, UriKind.RelativeOrAbsolute));
            brdPopUp.Background = message.Background;


            // Make background fade
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            ClosePopup();
        }

        private void StartAutoCloseTimer(int seconds)
        {
            autoCloseTimer = new DispatcherTimer();
            autoCloseTimer.Interval = TimeSpan.FromSeconds(seconds);
            autoCloseTimer.Tick += (s, e) =>
            {
                autoCloseTimer.Stop();
                ClosePopup();
            };
            autoCloseTimer.Start();
        }

        private void ClosePopup()
        {
            // Restore owner opacity
            if (Owner != null)
            {
                Owner.Opacity = 1.0;
                Owner.IsEnabled = true;
            }
            Close();
        }

        private void FadeBackground()
        {
            if (Owner != null)
            {
                Owner.Opacity = 0.5;
                Owner.IsEnabled = false;
            }
        }

        public static void Show(PopUpData message)
        {
            PopUpMessage box = new PopUpMessage(message);
            box.FadeBackground();

            if (message.ShowOkButton)
            {
                box.btnOk.Visibility = Visibility.Visible;
            }
            else
            {
                box.btnOk.Visibility = Visibility.Collapsed;
                box.txtMessage.FontSize = 40; // Increase font size for auto-close messages
                box.imgIcon.Width = 300;
                box.imgIcon.Height = 200;
                box.StartAutoCloseTimer(5); // Auto-close after 5 seconds
            }

            box.ShowDialog();
        }
    }
}
