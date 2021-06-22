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
                "pack://application:,,,/Engine;component/Images/Locations/BeeField.png");

            newWorld.AddLocation(-1, -1, "Farmhouse",
                "An out-of-the-way farmhouse - is anyone inside?",
                "pack://application:,,,/Engine;component/Images/Locations/Farmhouse.png");

            newWorld.AddLocation(0, -1, "Home", "Your house.",
            "pack://application:,,,/Engine;component/Images/Locations/Home.png");

            return newWorld;
        }
    }
}
