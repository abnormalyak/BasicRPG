using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class ItemQuantity
    {
        public int ItemID { get; }
        public int Quantity { get; }

        public ItemQuantity(int id, int quantity)
        {
            ItemID = id;
            Quantity = quantity;
        }
    }
}
