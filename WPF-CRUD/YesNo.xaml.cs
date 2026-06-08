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
    /// Interaction logic for YesNo.xaml
    /// </summary>
    public partial class YesNo : Page
    {
        private DragDropHelper dragDropHelper = new DragDropHelper();
        public YesNo()
        {
            InitializeComponent();
            DataContext = new HindiWordsViewModel();
        }
        private void MyScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            dragDropHelper.Preview_MouseWheel((FrameworkElement)sender, e);
        }
    }
}
