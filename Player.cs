using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace Githubportfolioprojekt;
abstract class Player
{
    public string Name { get; protected set; }
    public int Health { get; set; } = 100;

    public virtual void Attack(Enemy enemy)
    {
        int damage = 10;
        enemy.TakeDamage(damage);
        AnsiConsole.Markup($"[green]Du attackerar och gör {damage} skada.[/]");
    }
}

class Rogue : Player
{
    public Rogue()
    {
        Name = "Rogue";
    }
}

class Warrior : Player
{
    public Warrior()
    {
        Name = "Warrior";
    }

    public override void Attack(Enemy enemy)
    {
        int damage = 15;
        enemy.TakeDamage(damage);
        AnsiConsole.Markup($"[green]Du attackerar kraftfullt och gör {damage} skada.[/]");
    }
}

class Mage : Player
{
    public Mage()
    {
        Name = "Mage";
    }

    public override void Attack(Enemy enemy)
    {
        int damage = 12;
        enemy.TakeDamage(damage);
        AnsiConsole.Markup($"[green]Du kastar en eldklot och gör {damage} skada.[/]");
    }
}
