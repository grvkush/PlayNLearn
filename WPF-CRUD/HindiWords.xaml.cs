using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for HindiWords.xaml
    /// </summary>
    public partial class HindiWords : Page
    {
        private Point _startPoint;
        public string draggedText;
        private bool _isDragging = false;
        private Stack<string> wordHistory = new Stack<string>();
        private DragDropHelper dragDropHelper = new DragDropHelper();

        public HindiWords()
        {
            InitializeComponent();
            DataContext = new HindiWordsViewModel();
        }
        private void btnLetter_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dragDropHelper.Control_MouseDown(e);            
        }

        private void btnLetter_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            dragDropHelper.Control_MouseMove((FrameworkElement)sender, e, "HindiLetter");
        }
        private void btnWord_Drop(object sender, DragEventArgs e)
        {             
            DragData item = dragDropHelper.Control_Drop((FrameworkElement)sender, e);
            if (item != null && item.dataType == "HindiLetter" && DataContext is HindiWordsViewModel vm)
            {
                vm.Append(((HindiLetter)(item.data)).Letter);
            }
            e.Handled = true;
        }    

        private void imgSelection_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dragDropHelper.Control_MouseDown(e);
        }
        private void imgSelection_MouseMove(object sender, MouseEventArgs e)
        {
            dragDropHelper.Control_MouseMove((FrameworkElement)sender, e, "ImageData");
        }

        private void imgMain_Drop(object sender, DragEventArgs e)
        {
            DragData imageData = dragDropHelper.Control_Drop((FrameworkElement)sender, e);
            if (imageData != null && imageData.dataType == "ImageData" && DataContext is HindiWordsViewModel vm)
            {
                vm.UpdateMainImage((ImageData)imageData.data);
                //imgMain.Source = new BitmapImage(new Uri(vm.MainImageData.ImagePath, UriKind.Relative)); 
            }
        }

        private void MyScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            dragDropHelper.Preview_MouseWheel((FrameworkElement)sender, e);
        }

        private void MatraScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            dragDropHelper.Preview_MouseWheel((FrameworkElement)sender, e);

        }
    }
}
