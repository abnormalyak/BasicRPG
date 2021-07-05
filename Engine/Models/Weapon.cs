using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class Weapon : GameItem
    {
        public int MinAttack { get; set; }
        public int MaxAttack { get; set; }

        public Weapon(int id, string name, int value, 
            int minAttack, int maxAttack) 
            : base(id, name, value)
        {
            MinAttack = minAttack;
            MaxAttack = maxAttack;
        }

        public new Weapon Clone()
        {
            return new Weapon(ItemID, Name, Value, MinAttack, MaxAttack);
        }
    }
}
