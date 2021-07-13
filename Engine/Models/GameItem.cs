using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class GameItem
    {
        public int ItemID { get; }
        public string Name { get; }
        public int Value { get; }
        public bool IsUnique { get; }

        public GameItem(int id, string name, int value, bool isUnique = false)
        {
            ItemID = id;
            Name = name;
            Value = value;
            IsUnique = isUnique;
        }

        public GameItem Clone()
        {
            return new GameItem(ItemID, Name, Value, IsUnique);
        }
    }
}
