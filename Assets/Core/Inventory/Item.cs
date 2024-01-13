using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core.Inventory
{
    public class Item: ItemObject
    {
        public virtual float Weight { get; set; }
    }
}
