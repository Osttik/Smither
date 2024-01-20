using Assets.Scripts.Abstraction;

namespace Assets.Core.Interact.Abstraction
{
    public interface IInteractOperator<T, R> where T : IInteractable
    {
        public void Operate(T operateTarget, IInteractConsumer<T, R> consumer);
    }
}
