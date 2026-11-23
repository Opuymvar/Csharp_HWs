using System;

public interface ICombatant
{
    public string Name { get; }
    public int HP { get; set; }
    public bool IsDead { get; }
    public int Damage { get; }
    public void Attack(ICombatant target);
    public void TakeDamage(int amount);
}

class Knight : ICombatant
{
    public string Name { get; }
    public int HP { get; set; } = 150;
    public int Damage { get; } = 25;
    public bool IsDead => HP <= 0;
    public Knight(string name)
    {
        Name = name;
    }

    public void Attack(ICombatant target)
    {
        if (IsDead)
        {
            Console.WriteLine($"Рыцарь {Name} мёртв");
            return;
        }
        if (target.IsDead)
        {
            Console.WriteLine($"Рыцарь {Name} не может атаковать мёртвую цель");
            return;
        }
        Console.WriteLine($"Рыцарь {Name} атакует");
        target.TakeDamage(Damage);
    }
    public void TakeDamage(int amount)
    {
        HP = Math.Max(0, HP - amount);
        Console.WriteLine($"Рыцарь {Name} получил {amount} урона. Осталось HP: {HP}");
    }
}

class Mage : ICombatant
{
    public string Name { get; }
    public int HP { get; set; } = 80;
    public int Damage { get; } = 40;
    public bool IsDead => HP <= 0;
    public Mage(string name)
    {
        Name = name;
    }

    public void Attack(ICombatant target)
    {
        if (IsDead)
        {
            Console.WriteLine($"Маг {Name} мёртв");
            return;
        }
        if (target.IsDead)
        {
            Console.WriteLine($"Маг {Name} не может атаковать мёртвую цель");
            return;
        }
        for (int i = 0; i < 2 && !target.IsDead; i++)
        {
            target.TakeDamage(Damage);
        }
    }
    public void TakeDamage(int amount)
    {
        HP = Math.Max(0, HP - amount);
        Console.WriteLine($"Маг {Name} получил {amount} урона. Осталось HP: {HP}");
    }

}
public class Program
{
    public static void Main()
    {
        ICombatant knight = new Knight("Артур");
        ICombatant mage = new Mage("Гендальф");
        while (!knight.IsDead && !mage.IsDead)
        {
            knight.Attack(mage);
            if (mage.IsDead)
            {
                Console.WriteLine($"Рыцарь {knight.Name} победил!");
                break;
            }
            mage.Attack(knight);
            if (knight.IsDead)
            {
                Console.WriteLine($"Маг {mage.Name} победил!");
                break;
            }

        }
    }
}
