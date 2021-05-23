using Engine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.ViewModels
{
    public class GameSession
    {
        public Player CurrentPlayer { get; set; }

        public GameSession()
        {
            CurrentPlayer = new Player();
            CurrentPlayer.Name = "Abnormal";
            CurrentPlayer.Gold = 500;
            CurrentPlayer.Class = "Mage";
            CurrentPlayer.Level = 1;
            CurrentPlayer.Health = 100;
            CurrentPlayer.Experience = 0;
        }
    } 
}
