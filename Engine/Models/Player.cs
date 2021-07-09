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
        private int _level;

        public string Class
        {
            get { return _class; }
            set
            {
                _class = value;
                OnPropertyChanged("Class");
            }
        }

        public int Experience { get { return _experience; } 
            set { 
                _experience = value;
                OnPropertyChanged("Experience");
            } 
        }
        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged("Level");
            }
        }

        public ObservableCollection<QuestStatus> Quests { get; set; }

        public Player()
        {
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
    }
}
