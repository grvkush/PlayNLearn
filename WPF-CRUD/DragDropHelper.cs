using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF_CRUD
{
    public class DragDropHelper
    {
        private Point startPoint;
        private bool isDragging = false;
        public DragDropHelper() 
        {            
        }
        public DragDropHelper(string path) { }
        public void Control_MouseDown(MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        public void Control_MouseMove(FrameworkElement source, MouseEventArgs e, string typeOFData)
        {
            if (isDragging)
                return;

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point currentPosition = e.GetPosition(null);

                if (Math.Abs(currentPosition.X - startPoint.X) > SystemParameters.MinimumHorizontalDragDistance
                    || Math.Abs(currentPosition.Y - startPoint.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    isDragging = true;

                    DragData dragData = new DragData
                    {
                        data = source.DataContext,
                        dataType = typeOFData
                    };
                    
                    if (dragData != null)
                    {
                        DragDrop.DoDragDrop(source, dragData, DragDropEffects.Copy);
                    }
                    isDragging = false;
                }
            }
        }
        public DragData Control_Drop(FrameworkElement target,DragEventArgs e)
        {
            DragData droppedData = e.Data.GetData(typeof(DragData)) as DragData;            
            return droppedData;
        }

        public void Preview_MouseWheel(FrameworkElement sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = sender as ScrollViewer;

            scrollViewer.ScrollToHorizontalOffset(
                scrollViewer.HorizontalOffset - (e.Delta / 3));

            e.Handled = true;
        }


    }

    public class DragData
    {
        public object data { get; set; }

        public string dataType { get; set; }
    }
}
