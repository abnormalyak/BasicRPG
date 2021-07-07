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
        private Trader _currentTrader;

        public Player CurrentPlayer { get; set; }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;

                OnPropertyChanged("CurrentLocation");

                CompleteQuests();
                GiveQuests();
                FindMonsterAtLocation();

                CurrentTrader = CurrentLocation.TraderHere;
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

        public bool HasTrader => CurrentTrader != null;

        public Weapon CurrentWeapon { get; set; }

        public Trader CurrentTrader
        {
            get { return _currentTrader; }
            set
            {
                _currentTrader = value;

                OnPropertyChanged(nameof(CurrentTrader));
                OnPropertyChanged(nameof(HasTrader));
            }
        }
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

            if (!CurrentPlayer.Weapons.Any())
            {
                CurrentPlayer.AddItemToInventory(ItemFactory.CreateGameItem(1001));
            }

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

                    RaiseMessage($"\nYou receive the {quest.Name} quest.");
                    RaiseMessage(quest.Description);

                    RaiseMessage("Return with:");
                    foreach (ItemQuantity item in quest.RequiredItems)
                    {
                        RaiseMessage($"* {item.Quantity} " +
                            $"{ItemFactory.CreateGameItem(item.ItemID).Name}");
                    }
                }
            }
        }
        
        private void CompleteQuests()
        {
            foreach (Quest quest in CurrentLocation.QuestsAvailableHere)
            {
                QuestStatus questToComplete =
                    CurrentPlayer.Quests.FirstOrDefault(q => q.Quest.ID == quest.ID
                    && !q.IsComplete);

                if (questToComplete != null)
                {
                    if (CurrentPlayer.HasItems(quest.RequiredItems))
                    {
                        // Remove the items required for quest completion
                        // from the player's inventory.
                        foreach (ItemQuantity itemQuantity in quest.RequiredItems)
                        {
                            for (int i = 0; i < itemQuantity.Quantity; i++)
                            {
                                CurrentPlayer.RemoveItemFromInventory(
                                    CurrentPlayer.Inventory.First(
                                        item => item.ItemID == itemQuantity.ItemID));
                            }
                        }

                        RaiseMessage($"\nYou completed the {quest.Name} quest.");

                        CurrentPlayer.Experience += quest.RewardEXP;
                        RaiseMessage($"You receive {quest.RewardEXP} experience.");

                        CurrentPlayer.Gold += quest.RewardGold;
                        RaiseMessage($"You receive {quest.RewardGold} gold.");

                        // Add reward items to the player's inventory.
                        foreach (ItemQuantity itemQuantity in quest.RewardItems)
                        {
                            GameItem rewardItem = ItemFactory
                                    .CreateGameItem(itemQuantity.ItemID);

                            for (int i = 0; i < itemQuantity.Quantity; i++)
                            {
                                CurrentPlayer.AddItemToInventory(rewardItem);
                            }


                            RaiseMessage(
                                $"You receive {itemQuantity.Quantity} {rewardItem.Name}.");
                        }
                    }

                    questToComplete.IsComplete = true;
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
        
        public void Attack()
        {
            // Checks if a monster is actually present
            // (shouldn't be possible for function to be called if a monster isn't present)
            if (CurrentMonster == null)
            {
                RaiseMessage("There's nothing to attack!");
            }
            // Checks player has weapon equipped
            if (CurrentWeapon == null)
            {
                RaiseMessage("Equip a weapon first!");
                return;
            }

            // Calculates damage dealt to the monster
            int damageDealt = RandomNumberGenerator.NumberBetween
                (CurrentWeapon.MinAttack, CurrentWeapon.MaxAttack);

            if (damageDealt == 0)
            {
                RaiseMessage("You missed!");
            }
            else
            {
                CurrentMonster.Health -= damageDealt;
                RaiseMessage($"You hit the {CurrentMonster.Name} for {damageDealt} damage!");
            }


            // If the monster is killed, award EXP, gold and items
            if (CurrentMonster.Health <= 0)
            {
                RaiseMessage($"\nYou defeated the {CurrentMonster.Name}.");

                CurrentPlayer.Experience += CurrentMonster.RewardEXP;
                RaiseMessage($"\nYou receive {CurrentMonster.RewardEXP} EXP.");

                CurrentPlayer.Gold += CurrentMonster.RewardGold;
                RaiseMessage($"You receive {CurrentMonster.RewardGold} gold.");

                foreach (ItemQuantity itemQuantity in CurrentMonster.Inventory)
                {
                    GameItem item = ItemFactory.CreateGameItem(itemQuantity.ItemID);
                    CurrentPlayer.AddItemToInventory(item);
                    RaiseMessage($"The {CurrentMonster.Name} dropped a {item.Name}");
                }

                FindMonsterAtLocation();
            }
            else
            {
                // If monster is still alive, monster attacks player
                int damageReceived = RandomNumberGenerator.NumberBetween
                    (CurrentMonster.MinimumDamage, CurrentMonster.MaximumDamage);

                if (damageReceived == 0)
                {
                    RaiseMessage($"You dodge the {CurrentMonster.Name}'s attack!");
                }
                else
                {
                    CurrentPlayer.Health -= damageReceived;
                    RaiseMessage($"The {CurrentMonster.Name} attacks, " +
                        $"dealing {damageReceived} damage.");
                }

                if (CurrentPlayer.Health <= 0)
                {
                    RaiseMessage($"\nYou are slain by the {CurrentMonster.Name}");

                    CurrentLocation = CurrentWorld.LocationAt(0, -1);
                    CurrentPlayer.Health = CurrentPlayer.Level * 100;
                }
            }
        }
    } 
}
