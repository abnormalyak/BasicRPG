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
            set
            {
                _health = value;
                OnPropertyChanged(nameof(Health));
            }
        }

        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        public int RewardEXP { get; private set; }
        public int RewardGold { get; private set; }

        public ObservableCollection<ItemQuantity> Inventory { get; set; }

        public Monster(string name, string imageName, int maxHealth, int health, 
            int minimumDamage, int maximumDamage,
            int rewardEXP, int rewardGold)
        {
            Name = name;
            ImageName = $"pack://application:,,,/Engine;component/Images/Monsters/{imageName}";
            MaxHealth = maxHealth;
            Health = (health > maxHealth) ? maxHealth : health;
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
            RewardEXP = rewardEXP;
            RewardGold = rewardGold;
            Inventory = new ObservableCollection<ItemQuantity>();
        }
    }
}
