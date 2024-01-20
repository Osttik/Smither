using Assets.Core.Interact.Abstraction;
using Assets.Core.Inventory;
using Assets.Scripts.Abstraction;
using System.Collections.Generic;

namespace Assets.Core.Interact
{
    public class DigOperator : IDelayedInteractOperator<IDiggable, Item>, IDeintractOperator<IDiggable>
    {
        public List<IDiggable> Operands { get; set; } = new List<IDiggable>();

        public void Deinteract(IDiggable interactable)
        {
            Operands.Remove(interactable);
        }

        public void Operate(IDiggable operateTarget, IInteractConsumer<IDiggable, Item> consumer)
        {
            if (!operateTarget.GetGameObject().TryGetComponent<IActorInvetoryHolder>(out var holder))
            {
                return;
            }

            holder.OnAct += Dig;
        }

        private void Dig(IActorInvetoryHolder holder, IInteractConsumer<IDiggable, Item> consumer)
        {
            foreach (var operand in Operands)
            {
                var requiredTool = holder.GetMainToolByType(operand.RequiredToolType);
                if (requiredTool != null)
                {
                    var item = operand.Dig(requiredTool);

                    consumer.ConsumeInteraction(operand, item);
                }
            }
        }
    }
}
