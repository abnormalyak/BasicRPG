using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;

namespace Engine.Factories
{
    internal static class WorldFactory
    {
        internal static World CreateWorld()
        {
            World newWorld = new World();

            newWorld.AddLocation(-2, -1, "Overgrown Field",
                "A dazingly beige field of corn, overrun with bees.",
                "BeeField.png");

            // Bee
            newWorld.LocationAt(-2, -1).AddMonster(1, 100);

            newWorld.AddLocation(-1, -1, "Farmhouse",
                "An out-of-the-way farmhouse - is anyone inside?",
                "Farmhouse.png");

            // Kill the bees quest
            newWorld.LocationAt(-1, -1).QuestsAvailableHere.Add(QuestFactory.GetQuestByID(1));

            newWorld.AddLocation(0, -1, "Home", "Your house.",
            "Home.png");

            return newWorld;
        }
    }
}
