using Engine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Engine.Factories
{
    internal static class QuestFactory
    {
        private static readonly List<Quest> _quests = new List<Quest>();

        static QuestFactory()
        {
            List<ItemQuantity> requiredItems = new List<ItemQuantity>();
            List<ItemQuantity> rewardItems = new List<ItemQuantity>();

            requiredItems.Add(new ItemQuantity(9001, 2));
            requiredItems.Add(new ItemQuantity(9002, 4));
            rewardItems.Add(new ItemQuantity(1, 3));

            _quests.Add(new Quest(1,
                "BEES!",
                "Collect 2 stingers and 4 wings by killing bees in the field.",
                requiredItems,
                50,
                15,
                rewardItems));
        }

        internal static Quest GetQuestByID(int id)
        {
            return _quests.FirstOrDefault(quest => quest.ID == id);
        }
    }
}
