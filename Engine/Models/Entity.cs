using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Engine.Models
{
    public abstract class Entity : Notification
    {
        private string _name;
        private int _health;
        private int _maximumHealth;
        private int _gold;
        private int _level;

        public string Name
        {
            get { return _name; }
            private set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public int Health
        {
            get { return _health; }
            private set
            {
                _health = value;
                OnPropertyChanged();
            }
        }

        public int MaximumHealth
        {
            get { return _maximumHealth; }
            protected set
            {
                _maximumHealth = value;
                OnPropertyChanged();
            }
        }

        public int Gold
        {
            get { return _gold; }
            private set
            {
                _gold = value;
                OnPropertyChanged();
            }
        }

        public int Level
        {
            get { return _level; }
            protected set
            {
                _level = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<GameItem> Inventory { get; }

        public ObservableCollection<GroupedInventoryItem> GroupedInventory { get; }

        public List<GameItem> Weapons => Inventory.Where(i => i is Weapon).ToList();

        public bool IsDead => Health <= 0;

        public event EventHandler OnKilled;

        protected Entity(string name, int maximumHealth, int health, int gold,
            int level = 1)
        {
            Name = name;
            MaximumHealth = maximumHealth;
            Health = health;
            Gold = gold;
            Level = level;

            Inventory = new ObservableCollection<GameItem>();
            GroupedInventory = new ObservableCollection<GroupedInventoryItem>();
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;

            if (IsDead)
            {
                Health = 0;
                RaiseOnKilledEvent();
            }
        }

        public void Heal(int health)
        {
            Health += health;

            if (Health > MaximumHealth)
            {
                Health = MaximumHealth;
            }
        }

        public void FullHeal()
        {
            Health = MaximumHealth;
        }

        public void ReceiveGold(int amount)
        {
            Gold += amount;
        }

        public void SpendGold(int amount)
        {
            if (amount > Gold)
            {
                throw new ArgumentOutOfRangeException($"Not enough gold available.");
            }

            Gold -= amount;
        }

        public void AddItemToInventory(GameItem item)
        {
            Inventory.Add(item);

            if (item.IsUnique)
            {
                GroupedInventory.Add(new GroupedInventoryItem(item, 1));
            }
            else
            {
                if (!GroupedInventory.Any(i => i.Item.ItemID == item.ItemID))
                {
                    GroupedInventory.Add(new GroupedInventoryItem(item, 1));
                }
                else
                {
                    GroupedInventory.First(i => i.Item.ItemID == item.ItemID).Quantity++;
                }
            }

            OnPropertyChanged(nameof(Weapons));
        }

        public void RemoveItemFromInventory(GameItem item) 
        {
            Inventory.Remove(item);

            GroupedInventoryItem toRemove = item.IsUnique ?
                GroupedInventory.FirstOrDefault(i => i.Item == item) :
                GroupedInventory.FirstOrDefault(i => i.Item.ItemID == item.ItemID);
            
            if (toRemove != null)
            {
                if (toRemove.Quantity == 1)
                {
                    GroupedInventory.Remove(toRemove);
                }
                else
                {
                    toRemove.Quantity--;
                }
            }

            OnPropertyChanged(nameof(Weapons));
        }

        private void RaiseOnKilledEvent()
        {
            OnKilled?.Invoke(this, new System.EventArgs());
        }
    }
}
