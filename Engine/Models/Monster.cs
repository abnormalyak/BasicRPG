using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Engine.Models
{
    public class Monster : Notification
    {
        private int _health;

        public string Name { get; private set; }
        public string ImageName { get; set; }
        public int MaxHealth { get; private set; }
        public int Health
        {
            get { return _health; }
            private set
            {
                _health = value;
                OnPropertyChanged(nameof(Health));
            }
        }

        public int RewardEXP { get; private set; }
        public int RewardGold { get; private set; }

        public ObservableCollection<ItemQuantity> Inventory { get; set; }

        public Monster(string name, string imageName, int maxHealth,
            int health, int rewardEXP, int rewardGold)
        {
            Name = name;
            ImageName = string.Format(
                "pack://application:,,,/Engine;component/Images/Monsters/{0}", 
                imageName);
            MaxHealth = maxHealth;
            Health = (health > maxHealth) ? maxHealth : health;
            RewardEXP = rewardEXP;
            RewardGold = rewardGold;
            Inventory = new ObservableCollection<ItemQuantity>();
        }
    }
}
