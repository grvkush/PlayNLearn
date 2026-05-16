using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace WPF_CRUD
{
    public class PlaySoundsHelper
    {
        private List<string> soundFiles;
        private SoundPlayer correctSound;
        private SoundPlayer wrongSound;

        public PlaySoundsHelper()
        {
            InitializeSounds();
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

        public void PlayCorrectSound()
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

        public void PlayWrongSound()
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
