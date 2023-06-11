using System;
using System.Speech.Synthesis;

namespace Move2VoiceBeta
{
    public class Speech
    {
        private SpeechSynthesizer synthesizer;
        private int speechRate = -3;


        public Speech(int rate)
        {
    
            this.speechRate = rate;  // Store the rate
            synthesizer = new SpeechSynthesizer();
            synthesizer.Rate = this.speechRate;  // Use the stored rate
            synthesizer.Volume = 50;
            synthesizer.SetOutputToDefaultAudioDevice();
        }

        public Action<object, SpeakCompletedEventArgs> SpeakCompleted { get; internal set; }

        public void SpeakAsync(string text)
        {
            try
            {
                synthesizer.SpeakAsync(text);
            }
            catch 
            { 

            }
        }
    }
}
