using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Engine.Models
{
    public class Trader : Entity
    {
        public Trader(string name)
        {
            Name = name;
            Inventory = new ObservableCollection<GameItem>();
        }
    }
}
