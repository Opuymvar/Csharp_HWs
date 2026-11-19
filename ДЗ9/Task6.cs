using System;
using System.IO;
using System.Text.Json;
using static Program;

class Program
{
    public class GameSettings
    {
        public string PlayerName { get; set; }
        public int Difficulty { get; set; }
        public int MusicVolume { get; set; }
    }

    class Program1
    {
        static void Main()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "settings.json");
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                GameSettings settings = JsonSerializer.Deserialize<GameSettings>(jsonString);

                Console.WriteLine("Текущие настройки");
                Console.WriteLine($"Имя игрока: {settings.PlayerName}");
                Console.WriteLine($"Сложность: {settings.Difficulty}");
                Console.WriteLine($"Громкость музыки: {settings.MusicVolume}");
            }
            else
            {
                Console.WriteLine("Файл настроек не найден. Создаём новые настройки.");
                GameSettings newSettings = new GameSettings();

                Console.WriteLine("Введите имя игрока");
                newSettings.PlayerName = Console.ReadLine();

                Console.WriteLine("Введите сложность: 1 - легко, 2 - нормально, 3 - сложно");
                newSettings.Difficulty = int.Parse(Console.ReadLine());
            
                Console.WriteLine("Введите громкость музыки (0-100)");
                newSettings.MusicVolume = int.Parse(Console.ReadLine());

                string jsonOutput = JsonSerializer.Serialize(newSettings, options);
                File.WriteAllText(filePath, jsonOutput);

                Console.WriteLine("Настройки сохранены");
            }
        }
    }

}
