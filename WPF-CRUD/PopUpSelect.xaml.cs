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
    /// Interaction logic for PopUpSelect.xaml
    /// </summary>
    public partial class PopUpSelect : Window
    {
        private DragDropHelper dragDropHelper = new DragDropHelper();
        private bool _isClosing = false;

        public PopUpSelect(PopUpSelectData data)
        {
            InitializeComponent();
            Title = data.Title;
            txtMessage.Text = data.Message;
            brdPopUp.Background = data.Background;

            // Make background fade
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            // Close popup when user clicks outside
            Deactivated += (s, e) => ClosePopup();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            ClosePopup();
        }

        private void ClosePopup()
        {
            if (_isClosing) return;
            _isClosing = true;

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

        public void Show(PopUpSelectData data)
        {
            PopUpSelect box = new PopUpSelect(data);
            box.FadeBackground();

            if (data.ShowOkButton)
            {
                box.btnOk.Visibility = Visibility.Visible;
                
                if (data.OperationType == "Enter")
                {
                    box.MyScrollViewer.Visibility = Visibility.Collapsed;
                    box.txtInput.Visibility = Visibility.Visible;
                }
                else if (data.OperationType == "Select")
                {
                    box.txtInput.Visibility = Visibility.Collapsed;
                    box.MyScrollViewer.Visibility = Visibility.Visible;
                    box.icOptions.ItemsSource = data.Options;
                }
            }
            else
            {
                box.btnOk.Visibility = Visibility.Collapsed;
            }

            box.ShowDialog();
        }

        private void MyScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            dragDropHelper.Preview_MouseWheel((FrameworkElement)sender, e);
        }
    }
}
