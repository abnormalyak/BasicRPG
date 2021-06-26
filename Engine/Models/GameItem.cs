using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class GameItem
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public GameItem(int id, string name, int value)
        {
            ItemID = id;
            Name = name;
            Value = value;
        }

        public GameItem Clone()
        {
            return new GameItem(ItemID, Name, Value);
        }
    }
}
