using Assets.Scripts.Abstraction;

namespace Assets.Core.Interact.Abstraction
{
    public interface IDeintractOperator<T> where T: IInteractable
    {
        public void Deinteract(T interactable);
    }
}
