using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core.Craft.Abstraction
{
    public interface IRequireSatisfaction
    {
        public string Type { get; set; }
        public bool CanSatisfy(CraftRequirement requirement);
        public bool TrySatisfy(CraftRequirement requirement);
    }
}
