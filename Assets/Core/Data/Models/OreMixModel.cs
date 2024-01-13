using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core.Data.Models
{
    public class OreMixModel: OreMix, IModel<OreMix>
    {
        public Guid Id { get; set; }
        public List<Guid> OresIds { get; set; }
        [JsonIgnore]
        public override float Price { get; set; }
        [JsonIgnore]
        public override float Durability { get; set; }
        [JsonIgnore]
        public override float Weight { get; set; }

        public OreMix ToValue()
        {
            return new OreMix()
            {
                NameTag = NameTag,
                Price = Price,
                Durability = Durability,
                MixedOres = MixedOres,
                RequiredToolType = RequiredToolType
            };
        }
    }
}
