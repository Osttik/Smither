using Assets.Core.Interact.Abstraction;
using Assets.Scripts.Abstraction;
using UnityEngine;
using Zenject;

public class InteractManager : MonoBehaviour
{
    [Inject]
    private DiContainer _container;

    public void ProceedInteraction<T, R>(T interactable, IInteractConsumer<T, R> consumer) where T : IInteractable
    {
        var interactOperator = _container.Resolve<IInteractOperator<T, R>>();

        interactOperator.Operate(interactable, consumer);
    }
}
