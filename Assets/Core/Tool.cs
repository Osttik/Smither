using Assets.Core.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core
{
    public class Tool: Item
    {
        public Material Material { get; set; }
        public override float Price { get => Material.Price * Weight * 2; }
        public virtual float MaxDurability { get => Material.Durability * Weight * 2; }
        public string Type { get; set; }
    }
}
