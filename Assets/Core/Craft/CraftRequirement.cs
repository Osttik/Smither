using Assets.Core.Craft.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core.Craft
{
    public class CraftRequirement
    {
        public string Type { get; set; }
        public float Value { get; set; }

        public bool CheckRequirement(IRequireSatisfaction satisfaction)
        {
            if (satisfaction.Type != Type) return false;

            return satisfaction.CanSatisfy(this);
        }
    }
}
