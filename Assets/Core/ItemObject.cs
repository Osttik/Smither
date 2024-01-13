using Assets.Core.Craft;
using Assets.Core.Craft.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core
{
    public class ItemObject
    {
        public virtual string NameTag { get; set; }
        public virtual float Price { get; set; }
        public virtual float Durability { get; set; }
    }
}
