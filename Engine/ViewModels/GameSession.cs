using Engine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.ViewModels
{
    public class GameSession
    {
        public Player CurrentPlayer { get; set; }
        public Location CurrentLocation { get; set; }

        public GameSession()
        {
            CurrentPlayer = new Player();
            CurrentPlayer.Name = "Abnormal";
            CurrentPlayer.Gold = 500;
            CurrentPlayer.Class = "Mage";
            CurrentPlayer.Level = 1;
            CurrentPlayer.Health = 100;
            CurrentPlayer.Experience = 0;

            CurrentLocation = new Location();
            CurrentLocation.Name = "Home";
            CurrentLocation.XCoordinate = 0;
            CurrentLocation.YCoordinate = -1;
            CurrentLocation.Description = "Your house.";
            CurrentLocation.ImageName = "pack://application:,,,/Engine;component/Images/Locations/Home.png";
        }
    } 
}
