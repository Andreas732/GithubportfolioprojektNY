using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Spectre.Console;
using ConsoleColor = Spectre.Console.Color;

namespace Githubportfolioprojekt;

    class Game
    {
        private Player _player;
        private List<Room> _world;
        private int _currentRoomIndex;

        public void Start()
        {
            DisplayTitle();
            CreatePlayer();
            CreateWorld();
            Play();
        }

        private void DisplayTitle()
        {
        AnsiConsole.Write(new FigletText(".NET test spel"));
        }

        private void CreatePlayer()
        {
            AnsiConsole.Markup("[green]Välj din karaktär:[/]");
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[cyan]Välj en klass:[/]")
                    .AddChoices("Rogue", "Warrior", "Mage"));

            switch (choice)
            {
                case "Rogue":
                    _player = new Rogue();
                    break;
                case "Warrior":
                    _player = new Warrior();
                    break;
                case "Mage":
                    _player = new Mage();
                    break;
            }
            AnsiConsole.Markup($"[yellow]Du valde {_player.Name}![/]");
        }

        private void CreateWorld()
        {
            _world = new List<Room>
            {
                new Room("En mörk skog", "Du hör mystiska ljud runt dig."),
                new Room("En övergiven by", "En känsla av sorg fyller luften."),
                new Room("Ett högt berg", "Du ser en fiende på avstånd!"),
            };
            _currentRoomIndex = 0;
        }

        private void Play()
        {
            while (true)
            {
                Room currentRoom = _world[_currentRoomIndex];
                AnsiConsole.Markup($"[blue]{currentRoom.Name}[/]");
                AnsiConsole.Markup($"[italic]{currentRoom.Description}[/]");

                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[green]Vad vill du göra?[/]")
                        .AddChoices("Utforska", "Strid", "Gå vidare"));

                switch (choice)
                {
                    case "Utforska":
                        ExploreRoom(currentRoom);
                        break;
                    case "Strid":
                        Battle();
                        break;
                    case "Gå vidare":
                        MoveToNextRoom();
                        break;
                }
            }
        }

        private void ExploreRoom(Room room)
        {
            AnsiConsole.Markup("[cyan]Du utforskar rummet och hittar inget av intresse.[/]");
        }

        private void Battle()
        {
            Enemy enemy = new Enemy("Goblin", 20);
            AnsiConsole.Markup($"[red]En {enemy.Name} attackerar![/]");
            while (enemy.Health > 0 && _player.Health > 0)
            {
                var action = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[green]Vad vill du göra?[/]")
                        .AddChoices("Attack", "Försvara"));

                switch (action)
                {
                    case "Attack":
                        _player.Attack(enemy);
                        break;
                    case "Försvara":
                        AnsiConsole.Markup("[yellow]Du försvarar dig![/]");
                        break;
                }

                if (enemy.Health > 0)
                {
                    enemy.Attack(_player);
                }
            }

            if (_player.Health <= 0)
            {
                AnsiConsole.Markup("[red]Du förlorade striden![/]");
                Environment.Exit(0);
            }

            AnsiConsole.Markup("[green]Du besegrade fienden![/]");
        }

        private void MoveToNextRoom()
        {
            if (_currentRoomIndex < _world.Count - 1)
            {
                _currentRoomIndex++;
                AnsiConsole.Markup("[yellow]Du går vidare till nästa rum.[/]");
            }
            else
            {
                AnsiConsole.Markup("[green]Du har nått slutet på ditt äventyr![/]");
                Environment.Exit(0);
            }
        }
    }
