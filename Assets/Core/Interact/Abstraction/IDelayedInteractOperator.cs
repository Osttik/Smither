using Assets.Scripts.Abstraction;
using System.Collections.Generic;

namespace Assets.Core.Interact.Abstraction
{
    public interface IDelayedInteractOperator<T, R> : IInteractOperator<T, R> where T : IInteractable
    {
        public List<T> Operands { get; set; }
    }
}
