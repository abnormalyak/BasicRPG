using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class Weapon : GameItem
    {
        public int MinAttack { get; }
        public int MaxAttack { get; }

        public Weapon(int id, string name, int value, 
            int minAttack, int maxAttack) 
            : base(id, name, value, true)
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
