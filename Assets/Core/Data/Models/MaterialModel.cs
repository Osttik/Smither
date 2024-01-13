using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core.Data.Models
{
    public class MaterialModel : Material, IModel<Material>
    {
        public Guid Id { get; set; }

        public Material ToValue()
        {
            return new Material()
            {
                NameTag = NameTag,
                Price = Price,
                Durability = Durability
            };
        }
    }
}
