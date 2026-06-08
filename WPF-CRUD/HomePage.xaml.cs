using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.Win32;

namespace WPF_CRUD
{
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();

            // Navigate to home page content by default
            MainFrame.Navigate(new HomePage_Content());
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HomePage_Content());
        }

        private void BtnMediaPlayer_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MediaPlayerPage());
        }

        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AboutPage());
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SettingsPage());
        }

        private void BtnClassify_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ClassifyPage());
        }

        private void btnHindiWord_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HindiWords());
        }

        private void btnAddSub_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddSub());
        }

        private void btnYesNo_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new YesNo());
        }
    }
}