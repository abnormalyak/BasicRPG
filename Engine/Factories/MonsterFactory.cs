using Engine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Factories
{
    public static class MonsterFactory
    {
        public static Monster GetMonster(int id)
        {
            switch (id)
            {
                case 1:
                    Monster bee = new Monster("Bee", "Bee.png", 10, 10, 15, 30, 20, 3);

                    AddLootItem(bee, 9001, 40);
                    AddLootItem(bee, 9002, 60);

                    return bee;
                default:
                    throw new ArgumentException(
                        string.Format("Monster with ID '{0}' does not exist.", id));
            }
        }  
        private static void AddLootItem(Monster monster, int itemID, int dropChance)
        {
            if (RandomNumberGenerator.NumberBetween(1, 100) <= dropChance)
            {
                monster.Inventory.Add(new ItemQuantity(itemID, 1));
            }
        }
    }

  
}
