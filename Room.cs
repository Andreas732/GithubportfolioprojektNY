using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace Githubportfolioprojekt;
class Room
{
    public string Name { get; }
    public string Description { get; }

    public Room(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
