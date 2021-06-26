using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class Weapon : GameItem
    {
        public int Attack { get; set; }

        public Weapon(int id, string name, int value, int attack) 
            : base(id, name, value)
        {
            Attack = attack;
        }

        public new Weapon Clone()
        {
            return new Weapon(ItemID, Name, Value, Attack);
        }
    }
}
