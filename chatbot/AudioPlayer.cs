using System.Media;

public static class AudioService
{
    public static void PlayWelcome()
    {
        try 
        {
            // Note: Place "welcome.wav" in Resources folder
            using var player = new SoundPlayer("Resources/welcome.wav");
            player.PlaySync(); // Blocks until playback finishes
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Audio Error] {ex.Message}");
        }
    }
}