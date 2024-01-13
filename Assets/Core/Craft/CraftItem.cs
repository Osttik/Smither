using Assets.Core.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core.Craft
{
    public class CraftItem
    {
        public Item Item { get; set; }
        public List<CraftRequirement> Requirements { get; set; }
    }
}
