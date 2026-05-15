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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_CRUD
{
    /// <summary>
    /// Interaction logic for AddSub.xaml
    /// </summary>
    public partial class AddSub : Page
    {
        DragDropHelper dragDropHelper;
        public AddSub()
        {
            InitializeComponent();
            dragDropHelper = new DragDropHelper();
        }

        private void MyScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            dragDropHelper.Preview_MouseWheel((FrameworkElement)sender, e);
        }

        private void imgCountingIcon_MouseMove(object sender, MouseEventArgs e)
        {
            dragDropHelper.Control_MouseMove((FrameworkElement)sender, e, "ImageData");
        }

        private void imgCountingIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dragDropHelper.Control_MouseDown(e);
        }
    }
}
