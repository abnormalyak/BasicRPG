using Engine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Engine.Factories;
using System.ComponentModel;
using System.Linq;

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

                GiveQuests();
            }
        }

        public World CurrentWorld { get; set; }
        

        public GameSession()
        {
            CurrentPlayer = new Player 
            { 
                Name = "Abnormal", 
                Class = "Mage", 
                Experience = 0, 
                Gold = 500, 
                Health = 100,
                Level = 1
            };

            CurrentWorld = WorldFactory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(0, -1);
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

        public void GiveQuests()
        {
            foreach(Quest quest in CurrentLocation.QuestsAvailableHere)
            {
                if (!CurrentPlayer.Quests.Any(q => q.Quest.ID == quest.ID))
                {
                    CurrentPlayer.Quests.Add(new QuestStatus(quest));
                }
            }
        }
    } 
}
