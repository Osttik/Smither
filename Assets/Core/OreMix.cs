using Assets.Core.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core
{
    public class OreMix: Item
    {
        public override float Weight { get => MixedOres.Sum(x => x.Weight); }
        public List<Ore> MixedOres { get; set; }
        public override float Price { get => MixedOres.Sum(x => x.Price) / 2; }
        public override float Durability { get => MixedOres.Sum(x => x.Durability) / 2; }
        public string RequiredToolType { get; set; }
    }
}
