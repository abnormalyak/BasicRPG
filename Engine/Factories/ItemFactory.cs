﻿using Engine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Engine.Factories
{
    public static class ItemFactory
    {
        private static List<GameItem> _items;

        // This function is run whenever the class is first called
        static ItemFactory()
        {
            _items = new List<GameItem>();
            _items.Add(new GameItem(1, "Potion", 15));
            _items.Add(new Weapon(1001, "Iron Sword", 50, 7));
            _items.Add(new GameItem(9001, "Stinger", 5));
            _items.Add(new GameItem(9002, "Bee Wings", 3));
        }

        public static GameItem CreateGameItem(int id)
        {
            GameItem item = _items.FirstOrDefault(item => item.ItemID == id);

            if (item != null)
            {
                return item.Clone();
            }

            return null;
        }
    }
}
