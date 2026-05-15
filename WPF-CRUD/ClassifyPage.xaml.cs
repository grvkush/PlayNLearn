using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace WPF_CRUD
{
    /// <summary>
    /// Interaction logic for ClassifyPage.xaml
    /// </summary>
    public partial class ClassifyPage : Page
    {
        bool isCorrect = false;
        private SoundPlayer correctSound;
        private SoundPlayer wrongSound;
        private DispatcherTimer timer;
        private List<string> soundFiles;
        private string clsfText;

        public ClassifyPage()
        {
            InitializeComponent();            
            cbCategory.Items.Add("an Animal");

            // Initialize sound players
            InitializeSounds();
            InitializeTimer();            
        }
        
        private void InitializeSounds()
        {
            soundFiles = new List<string>();
            try
            {
                string soundsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds");

                if (Directory.Exists(soundsPath))
                {
                    // Load all .wav files from the Sounds folder
                    string[] wavFiles = Directory.GetFiles(soundsPath, "*.wav");
                    soundFiles.AddRange(wavFiles);

                    Console.WriteLine($"Found {soundFiles.Count} sound files in Sounds folder");
                }
                else
                {
                    Console.WriteLine("Sounds folder not found at: " + soundsPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading sound files: {ex.Message}");
            }
        }
        public void InitializeTimer()
        {
            // Create a timer to reset the check image after 1 second
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += Timer_Tick; 
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            imgCheck.Source = new BitmapImage(new Uri("/Images/Buttons/question_button_ico.png", UriKind.Relative));
            timer.Stop(); // Stop the timer after resetting the image
        }
        private void txtClassify_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtClassify.Text))
            {
                TextBox txtBox = sender as TextBox;
                tbClassify.Text = ToSentenceCase(txtBox.Text) + " is";
                if (txtBox.Text.ToLower() == "a rhinoceros")
                {
                    isCorrect = true;
                }
                else
                {
                    isCorrect = false;
                }
            }
        }
        
        private string ToSentenceCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(input.ToLower());
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            if (isCorrect)
            {
                imgCheck.Source = new BitmapImage(new Uri("/Images/Buttons/correct_button_ico.png", UriKind.Relative));
                PlayCorrectSound();                
            }
            else
            {
                imgCheck.Source = new BitmapImage(new Uri("/Images/Buttons/wrong_button_ico.png", UriKind.Relative));
                PlayWrongSound();
                timer.Start(); // Wait for 1 second 
            }
        }

        private void PlayCorrectSound()
        {
            try
            {
                if (soundFiles != null && soundFiles.Count > 0)
                {
                    // Play a random sound from the Sounds folder
                    string correctSoundFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds\\correct.wav");

                    correctSound = new SoundPlayer(correctSoundFile);
                    correctSound.Play();

                    Console.WriteLine($"Playing: {Path.GetFileName(correctSoundFile)}");
                }
                else
                {
                    // Fallback to system sound if no custom sounds are available
                    SystemSounds.Beep.Play();
                    Console.WriteLine("No sound files found, playing system beep");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing correct sound: {ex.Message}");
            }
        }

        private void PlayWrongSound()
        {
            try
            {
                if (soundFiles != null && soundFiles.Count > 0)
                {
                    // Play a random sound from the Sounds folder
                    string wrongSoundFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds\\wrong.wav");

                    wrongSound = new SoundPlayer(wrongSoundFile);
                    wrongSound.Play();

                    Console.WriteLine($"Playing: {Path.GetFileName(wrongSoundFile)}");
                }
                else
                {
                    // Fallback to system sound if no custom sounds are available
                    SystemSounds.Beep.Play();
                    Console.WriteLine("No sound files found, playing system beep");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing wrong sound: {ex.Message}");
            }
        }

        
    }
}
