using Assets.Core.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Abstraction
{
    public interface IPickable
    {
        public Item Pick();
    }
}
