using Engine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Engine.Factories;

namespace Engine.ViewModels
{
    public class GameSession
    {
        public Player CurrentPlayer { get; set; }
        public Location CurrentLocation { get; set; }
        public World CurrentWorld { get; set; }

        public GameSession()
        {
            CurrentPlayer = new Player();
            CurrentPlayer.Name = "Abnormal";
            CurrentPlayer.Gold = 500;
            CurrentPlayer.Class = "Mage";
            CurrentPlayer.Level = 1;
            CurrentPlayer.Health = 100;
            CurrentPlayer.Experience = 0;

            WorldFactory factory = new WorldFactory();
            CurrentWorld = factory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(-2, -1);
        }
    } 
}
