using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core.Data.Models
{
    public class OreModel: Ore, IModel<Ore>
    {
        public Guid Id { get; set; }
        public Guid MaterialId { get; set; }
        [JsonIgnore]
        public override float Price { get; set; }
        [JsonIgnore]
        public override float Durability { get; set; }

        public Ore ToValue()
        {
            return new Ore()
            {
                NameTag = NameTag,
                Price = Price,
                Durability = Durability,
                Material = Material,
                Rarity = Rarity,
                Weight = Weight
            };
        }
    }
}
