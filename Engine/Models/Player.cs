using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace Engine.Models
{
    public class Player : Notification
    {
        private string _name;
        private string _class;
        private int _health;
        private int _experience;
        private int _level;
        private int _gold;

        public string Name { get { return _name; } set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Class
        {
            get { return _class; }
            set
            {
                _class = value;
                OnPropertyChanged("Class");
            }
        }
        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;
                OnPropertyChanged("Health");
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
        public int Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;
                OnPropertyChanged("Gold");
            }
        }

        public ObservableCollection<GameItem> Inventory { get; set; }

        public List<GameItem> Weapons => 
            Inventory.Where(i => i is Weapon).ToList();

        public ObservableCollection<QuestStatus> Quests { get; set; }

        public Player()
        {
            Inventory = new ObservableCollection<GameItem>();
            Quests = new ObservableCollection<QuestStatus>();
        }

        public void AddItemToInventory(GameItem item)
        {
            Inventory.Add(item);

            OnPropertyChanged(nameof(Weapons));
        }
    }
}
