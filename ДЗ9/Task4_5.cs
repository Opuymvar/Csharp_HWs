using System;
using System.IO;
using System.Text.Json;
class Program
{
    static void Main()
    {
        GameCharacter Viva1441 = new GameCharacter
        {
            Name = "vi",
            Level = 25,
            Health = 1333,
            Inventory = new string[] { "Sword", "Gold", "Golem" }
        };
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        string json = JsonSerializer.Serialize(Viva1441, options);
        Console.WriteLine(json);

        string filePath = Path.Combine(AppContext.BaseDirectory, "save.json");
        File.WriteAllText(filePath, json);
        string vi = File.ReadAllText(filePath);
        GameCharacter viva1442 = JsonSerializer.Deserialize<GameCharacter>(vi);

        Console.WriteLine("=== Загруженный персонаж ===");
        Console.WriteLine($"Имя: {viva1442.Name}");
        Console.WriteLine($"Уровень: {viva1442.Level}");
        Console.WriteLine($"Здоровье: {viva1442.Health}");
        Console.WriteLine($"Инвентарь: {string.Join(", ", viva1442.Inventory)}");


        Console.WriteLine($"Имя = {viva1442.Name}, инвентарь = {viva1442.Inventory.Length}");
    }
    public class GameCharacter
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public double Health { get; set; }
        public string[] Inventory { get; set; }
    }
}
