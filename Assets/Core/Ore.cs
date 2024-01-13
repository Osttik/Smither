using Assets.Core.Craft;
using Assets.Core.Craft.Abstraction;
using Assets.Core.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core
{
    public class Ore: Item, IRequireSatisfaction
    {
        public Material Material { get; set; }
        public int Rarity { get; set; }
        public override float Price { get => Weight * Material.Price; }
        public override float Durability { get => Weight * Material.Durability; }

        public string Type { get; set; } = "Ore";

        public bool CanSatisfy(CraftRequirement requirement)
        {
            return requirement.Type == Type && Weight > requirement.Value;
        }

        public bool TrySatisfy(CraftRequirement requirement)
        {
            if (!CanSatisfy(requirement)) return false;

            Weight -= requirement.Value;

            return true;
        }
    }
}
