
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace WPF_CRUD
{
    public partial class SettingsPage : Page
    {
        //public string currentWord;
        public SettingsPage()
        {
            InitializeComponent();            
        }

        private void SourceImage_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Image image = sender as Image;

                if (image != null)
                {
                    DragDrop.DoDragDrop(
                        image,
                        image.Source,
                        DragDropEffects.Copy);
                }
            }
        }

        private void TargetImage_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(BitmapSource)))
            {
                BitmapSource droppedImage =
                    e.Data.GetData(typeof(BitmapSource)) as BitmapSource;

                TargetImage.Source = droppedImage;
            }
        }
    }
}