using Assets.Core;
using Assets.Core.Inventory;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Abstraction
{
    public interface IActorInvetoryHolder: IInventoryHolder
    {
        public event Action<IActorInvetoryHolder, IInteractConsumer<IDiggable, Item>> OnAct;
        public List<Tool> GetToolsByType(string toolType);
        public Tool GetMainToolByType(string toolType);
    }
}
