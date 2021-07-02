using Engine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Engine.Factories;
using System.ComponentModel;
using System.Linq;
using Engine.EventArgs;

namespace Engine.ViewModels
{
    public class GameSession : Notification
    {
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;

        #region Properties

        private Location _currentLocation;
        private Monster _currentMonster;

        public Player CurrentPlayer { get; set; }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;

                OnPropertyChanged("CurrentLocation");

                GiveQuests();
                FindMonsterAtLocation();
            }
        }

        public World CurrentWorld { get; set; }

        public Monster CurrentMonster
        {
            get { return _currentMonster; }
            set
            {
                _currentMonster = value;
                OnPropertyChanged(nameof(CurrentMonster));
                OnPropertyChanged(nameof(HasMonster));

                if (CurrentMonster != null)
                {
                    RaiseMessage("");
                    RaiseMessage($"A wild {CurrentMonster.Name} appears!");
                }
            }
        }

        public bool HasMonster => CurrentMonster != null;

        #endregion

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

        private void GiveQuests()
        {
            foreach(Quest quest in CurrentLocation.QuestsAvailableHere)
            {
                if (!CurrentPlayer.Quests.Any(q => q.Quest.ID == quest.ID))
                {
                    CurrentPlayer.Quests.Add(new QuestStatus(quest));
                }
            }
        }

        private void FindMonsterAtLocation()
        {
            CurrentMonster = CurrentLocation.FindMonster();
        }

        private void RaiseMessage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }
    } 
}
