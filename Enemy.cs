using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace Githubportfolioprojekt;
class Enemy
{
    public string Name { get; }
    public int Health { get; private set; }

    public Enemy(string name, int health)
    {
        Name = name;
        Health = health;
    }

    public void Attack(Player player)
    {
        int damage = 8;
        player.Health -= damage;
        AnsiConsole.Markup($"[red]{Name} attackerar och gör {damage} skada![/]");
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        AnsiConsole.Markup($"[yellow]{Name} tar {damage} skada![/]");
    }
}