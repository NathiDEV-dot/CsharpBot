using System;
using NAudio.Wave;

namespace CyberSecurityChatBot
{
    public static class AudioService
    {
        public static void PlayWelcome()
        {
            try 
            {
                using var audioFile = new AudioFileReader("Resources/welcome.wav");
                using var outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
                outputDevice.Play();
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    System.Threading.Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Audio Error] {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}