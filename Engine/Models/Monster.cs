using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Engine.Models
{
    public class Monster : Entity
    {
        public string ImageName { get; set; }

        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        public int RewardEXP { get; private set; }

        public Monster(string name, string imageName, int maxHealth, int health, 
            int minimumDamage, int maximumDamage,
            int rewardEXP, int rewardGold)
        {
            Name = name;
            ImageName = $"pack://application:,,,/Engine;component/Images/Monsters/{imageName}";
            MaximumHealth = maxHealth;
            Health = (health > maxHealth) ? maxHealth : health;
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
            RewardEXP = rewardEXP;
            Gold = rewardGold;
        }
    }
}
