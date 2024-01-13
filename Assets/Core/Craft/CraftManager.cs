using Assets.Core.Craft.Abstraction;
using Assets.Core.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core.Craft
{
    public class CraftManager
    {
        // Mimic crafting
        public bool Craft(CraftReceipe receipe, Inventory.Inventory inventory, List<IRequireSatisfaction> satisfactions, out Item craftedItem, out List<Item> remains)
        {
            craftedItem = null;
            remains = new List<Item>();
            return true;
        }
    }
}
