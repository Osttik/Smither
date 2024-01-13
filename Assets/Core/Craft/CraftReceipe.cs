using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core.Craft
{
    public class CraftReceipe : CraftItem
    {
        public List<CraftItem> ItemsToCraftFrom { get; set; } = new List<CraftItem>();
    }
}
