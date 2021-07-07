using Engine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Engine.Factories
{
    public static class ItemFactory
    {
        private static readonly List<GameItem> _items = new List<GameItem>();

        // This function is run whenever the class is first called
        static ItemFactory()
        {
            _items.Add(new GameItem(1, "Potion", 15));
            _items.Add(new GameItem(2, "Popcorn", 10));
            _items.Add(new Weapon(1001, "Iron Sword", 50, 5, 7));
            _items.Add(new GameItem(9001, "Stinger", 5));
            _items.Add(new GameItem(9002, "Bee Wings", 3));
        }

        public static GameItem CreateGameItem(int id)
        {
            GameItem item = _items.FirstOrDefault(item => item.ItemID == id);

            if (item != null)
            {
                if (item is Weapon)
                {
                    return (item as Weapon).Clone(); // 'as' is how casting is done in C#
                }
                return item.Clone();
            }

            return null;
        }
    }
}
