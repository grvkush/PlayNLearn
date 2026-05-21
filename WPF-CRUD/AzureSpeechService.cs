using Microsoft.CognitiveServices.Speech;
using System.Threading.Tasks;
using System.Configuration;

namespace WPF_CRUD
{
    public class AzureSpeechService
    {
        private readonly SpeechSynthesizer synthesizer;

        public AzureSpeechService()
        {
            // Replace with your key and region
            string key = ConfigurationManager.AppSettings["Speech_Key"];
            string region = ConfigurationManager.AppSettings["Speech_Region"];
            var config = SpeechConfig.FromSubscription(key, region);
            config.SpeechSynthesisVoiceName = "hi-IN-SwaraNeural"; // Hindi female voice
            // Other Hindi voices: "hi-IN-MadhurNeural" (male)
            synthesizer = new SpeechSynthesizer(config);
        }

        public async Task SpeakAsync(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                await synthesizer.SpeakTextAsync(text);
            }
        }
    }
}