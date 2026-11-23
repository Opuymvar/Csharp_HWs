using System;
using System.Xml.Linq;

public interface IDamageCalculator
{
    int CalculateDamage(int baseDamage, int targetArmor);
}
public class PhysicalDamageCalculator : IDamageCalculator
{
    public int CalculateDamage(int baseDamage, int targetArmor)
    {
        return Math.Max(1, baseDamage - targetArmor / 2);
    }
}
public class MagicDamageCalculator : IDamageCalculator
{
    public int CalculateDamage(int baseDamage, int targetArmor)
    {
        int damage = Math.Max(1, baseDamage - targetArmor / 4);
        if (targetArmor == 0)
        {
            damage *= 2;
        }
        return damage;
    }
}

public class FireDamageCalculator : IDamageCalculator
{
    public int CalculateDamage(int baseDamage, int targetArmor)
    {
        int damage = Math.Max(1, baseDamage - targetArmor / 10);
        if (baseDamage > 50)
        {
            damage += 10;
        }
        return damage;
    }
}
public class Unit
{
    public string Name { get; set; }
    public int HP { get; set; }
    public int Armor { get; set; }
    public Unit(string name, int hp, int armor)
    {
        Name = name;
        HP = hp;
        Armor = armor;
    }
}
public class DamageSystem
{
    private IDamageCalculator _damageCalculator;
    public DamageSystem(IDamageCalculator damageCalculator)
    {
        _damageCalculator = damageCalculator;
    }
    public void ApplyDamage(Unit target, int baseDamage)
    {
        int damage = _damageCalculator.CalculateDamage(baseDamage, target.Armor);
        target.HP = Math.Max(0, target.HP - damage);
        Console.WriteLine($"Юнит {target.Name} получил {damage} урона. Осталось HP: {target.HP}");
    }
}
public class Program
{
    public static void Main()
    {
        Unit unit = new Unit("Страж", 300, 20);
        int baseDamage = 60;


        Console.WriteLine("Физический урон:");
        DamageSystem physical = new DamageSystem(new PhysicalDamageCalculator());
        physical.ApplyDamage(unit, baseDamage);

        Console.WriteLine("Магический урон:");
        DamageSystem magic = new DamageSystem(new MagicDamageCalculator());
        magic.ApplyDamage(unit, baseDamage);

        Console.WriteLine("Огненный урон:");
        DamageSystem fire = new DamageSystem(new FireDamageCalculator());
        fire.ApplyDamage(unit, baseDamage);

        Console.WriteLine();
        Console.WriteLine("магия против цели без брони:");
        Unit unarmored = new Unit("Без брони", 100, 0);
        magic.ApplyDamage(unarmored, 30);
    }
}

// Чтобы добавить ледяной урон, можно создать класс
// IceDamageCalculator : IDamageCalculator с новым CalculateDamage
// Затем можно написать new DamageSystem(new IceDamageCalculator())

