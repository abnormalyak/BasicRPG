using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Factories
{
    public static class TraderFactory
    {
        private static readonly List<Trader> _traders =
            new List<Trader>();

        static TraderFactory()
        {
            Trader farmer = new Trader("Farmer");
            farmer.AddItemToInventory(ItemFactory.CreateGameItem(2));

            AddTraderToList(farmer);
        }

        public static Trader GetTraderByName(string name)
        {
            return _traders.FirstOrDefault(t => t.Name == name);
        }

        private static void AddTraderToList(Trader trader)
        {
            if (_traders.Any(t => t.Name == trader.Name))
            {
                throw new ArgumentException($"There is already a trader with the name '{trader.Name}'");
            }

            _traders.Add(trader);
        }
    }
}
