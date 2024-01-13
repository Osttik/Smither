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
        public List<Item> Items { get; protected set; } = new List<Item>();

        public bool TryAdd(Item item)
        {
            if (MaxWeight != float.NaN && Weight + item.Weight > MaxWeight) return false;
            Items.Add(item);

            return true;
        }

        public bool TryRemove(Item item)
        {
            return Items.Remove(item);
        }
    }
}
