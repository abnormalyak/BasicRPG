using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace Engine.Models
{
    public class Player : Entity
    {
        private string _class;
        private int _experience;

        public string Class
        {
            get { return _class; }
            set
            {
                _class = value;
                OnPropertyChanged();
            }
        }

        public int Experience { get { return _experience; } 
            private set { 
                _experience = value;

                OnPropertyChanged();

                CheckLevelUp();
            } 
        }

        public ObservableCollection<QuestStatus> Quests { get; }

        public event EventHandler OnLevelUp;

        public Player(string name, string playerClass, int experience,
                int maximumHealth, int health, int gold) :
            base(name, maximumHealth, health, gold)
        {
            Class = playerClass;
            Experience = experience;

            Quests = new ObservableCollection<QuestStatus>();
        }

        public bool HasItems(List<ItemQuantity> items)
        {
            foreach (ItemQuantity item in items)
            {
                if (Inventory.Count(i => i.ItemID == item.ItemID) < item.Quantity)
                {
                    return false;
                }
            }

            return true;
        }

        public void GainExperience(int exp)
        {
            Experience += exp;
        }

        public void CheckLevelUp()
        {
            int originalLevel = Level;

            Level = (Experience / 100) + 1;

            if (Level > originalLevel)
            {
                MaximumHealth = Level * 100;

                OnLevelUp?.Invoke(this, System.EventArgs.Empty);
            }
        }
    }
}
