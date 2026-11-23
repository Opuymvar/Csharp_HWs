using System;
using System.Collections.Generic;

public interface IUsableItem
{
    string Name { get; }
    string Description { get; }
    Rarity Rarity { get; }
    void Use(Player player);
}
public enum Rarity
{
    Common,
    Rare,
    Legendary
}
public class Player 
{
    public string Name { get; set; } 
    public int Damage { get; set; }
    public int HP { get; set; }
    public bool isDead => HP <= 0;
    public void Heal(int amount)
    {
        HP += amount;
    }
    public void IncreaseDamage(int amount)
    {
        Damage += amount;
    }
    public void TakeDamage(int amount)
    {
        HP = Math.Max(0, HP - amount);

        if (isDead)
        {
            Console.WriteLine($"{Name} has died.");
        }
    }
}
class HealthPotion : IUsableItem
{
    public string Name => "Health Potion";
    public string Description => "Restores 50 HP.";
    public Rarity Rarity => Rarity.Common;
    public void Use(Player player)
    {
        player.Heal(50);
        Console.WriteLine("Вы выпили зелье и восстановили 50 HP");
    }
}
public class Sword : IUsableItem
{
    public string Name => "Sword";
    public string Description => "Increases damage by 10.";
    public Rarity Rarity => Rarity.Rare;
    public void Use(Player player)
    {
        player.IncreaseDamage(10);
        Console.WriteLine("Вы использовали меч и увеличили урон на 10");
    }
}
public class AncientScroll : IUsableItem
{
    public string Name => "Ancient Scroll";
    public string Description => "Отнимает 20 HP, но увеличивает урон на 30";
    public Rarity Rarity => Rarity.Legendary;
    public void Use(Player player)
    {
        player.TakeDamage(20);
        player.IncreaseDamage(30);
        Console.WriteLine("Вы использовали Древний свиток, потеряли 20 HP, но увеличили урон на 30");
    }
}
public class Program
{
    public static void Main()
    {
        Player player = new Player { Name = "Hero", Damage = 10, HP = 100 };
        List<IUsableItem> items = new List<IUsableItem>
        {
            new HealthPotion(),
            new Sword(),
            new AncientScroll()
        };
        foreach (var item in items)
        {
            Console.WriteLine($"Предмет: {item.Name} ({item.Rarity})");
            Console.WriteLine($"Описание: {item.Description}");
            item.Use(player);
        }
        Console.WriteLine($"Игрок: {player.Name}");
        Console.WriteLine($"HP: {player.HP}");
        Console.WriteLine($"Damage: {player.Damage}");
        if (player.isDead)
        {
            Console.WriteLine("Игрок мёртв");
        }
        else
        {
            Console.WriteLine("Игрок жив");
        }
    }
}
