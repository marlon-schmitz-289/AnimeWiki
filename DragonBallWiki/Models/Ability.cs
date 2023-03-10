using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBallWiki.Models
{
    public class Ability
    {
        public string Name { get; set; } = "unbekannt";
        public string Description { get; set; } = "leer";


        public override string ToString () => $"{Name}: {Description}";
    }
}
