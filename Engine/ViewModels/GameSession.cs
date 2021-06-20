using Engine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Engine.Factories;
using System.ComponentModel;

namespace Engine.ViewModels
{
    public class GameSession : Notification
    {
        private Location _currentLocation;

        public Player CurrentPlayer { get; set; }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;

                OnPropertyChanged("CurrentLocation");
            }
        }

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

        public void MoveNorth()
        {
            int newX = CurrentLocation.XCoordinate;
            int newY = CurrentLocation.YCoordinate + 1;
            SetLocation(newX, newY);
        }

        public void MoveEast()
        {
            int newX = CurrentLocation.XCoordinate + 1;
            int newY = CurrentLocation.YCoordinate;
            SetLocation(newX, newY);
        }

        public void MoveWest()
        {
            int newX = CurrentLocation.XCoordinate - 1;
            int newY = CurrentLocation.YCoordinate;
            SetLocation(newX, newY);
        }

        public void MoveSouth()
        {
            int newX = CurrentLocation.XCoordinate;
            int newY = CurrentLocation.YCoordinate - 1;
            SetLocation(newX, newY);
        }

        private void SetLocation(int x, int y)
        {
            Location l = CurrentWorld.LocationAt(x, y);
            if (l != null)
            {
                CurrentLocation = l;
            }
        }
    } 
}
