using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core.Inventory
{
    public class Inventory
    {
        public float MaxWeight { get; protected set; } = float.NaN;
        public float Weight { get => Items.Sum(i => i.Weight); }
        public bool IsInfinity => float.IsNaN(MaxWeight);
        public List<Item> Items { get; protected set; } = new List<Item>();

        public bool TryAdd(Item item)
        {
            if (IsFull(item)) return false;
            Items.Add(item);

            return true;
        }

        public bool TryRemove(Item item)
        {
            return Items.Remove(item);
        }


        private bool IsFull(Item item)
        {
            return !IsInfinity && Weight + item.Weight > MaxWeight;
        }
    }
}
