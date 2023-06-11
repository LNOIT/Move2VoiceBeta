using System;
using System.Speech.Synthesis;
using System.Collections.Generic;

public class SpeechQueue
{
    private Queue<string> speechQueue = new Queue<string>();
    private SpeechSynthesizer synthesizer;
    private bool isSpeaking = false;

    public SpeechQueue(int speechRate)
    {
        synthesizer = new SpeechSynthesizer();
        synthesizer.Rate = speechRate;
        synthesizer.SpeakCompleted += OnSpeakCompleted;
    }

    public void EnqueueSpeech(string text)
    {
        speechQueue.Enqueue(text);
        SpeakNext();
    }

    private void SpeakNext()
    {
        if (!isSpeaking && speechQueue.Count > 0)
        {
            string text = speechQueue.Dequeue();
            isSpeaking = true;
            synthesizer.SpeakAsync(text);
        }
    }

    private void OnSpeakCompleted(object sender, SpeakCompletedEventArgs e)
    {
        isSpeaking = false;
        SpeakNext();
    }
}
