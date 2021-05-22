using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class Player
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int Health { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
    }
}
