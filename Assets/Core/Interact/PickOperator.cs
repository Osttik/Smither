using Assets.Core.Interact.Abstraction;
using Assets.Core.Inventory;
using Assets.Scripts.Abstraction;
using UnityEngine;

namespace Assets.Core.Interact
{
    public class PickOperator: IInteractOperator<IPickable, Item>
    {
        public void Operate(IPickable operateTarget, IInteractConsumer<IPickable, Item> consumer)
        {
            var item = operateTarget.Pick();

            consumer.ConsumeInteraction(operateTarget, item);

            Object.Destroy(operateTarget.GetGameObject());
        }
    }
}
