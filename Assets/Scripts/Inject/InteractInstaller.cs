using Assets.Core.Interact;
using Assets.Core.Interact.Abstraction;
using Assets.Core.Inventory;
using Assets.Scripts.Abstraction;
using UnityEngine;
using Zenject;

public class InteractInstaller : MonoInstaller<InteractInstaller>
{
    [SerializeField]
    private InteractManager _interactManager;

    public override void InstallBindings()
    {
        Container.Bind<InteractManager>().FromInstance(_interactManager).AsSingle();

        Container.Bind<IInteractOperator<IPickable, Item>>().To<PickOperator>().AsSingle();

        var digOperator = new DigOperator();
        Container.Bind<IDelayedInteractOperator<IDiggable, Item>>().To<DigOperator>().FromInstance(digOperator).AsSingle();
        Container.Bind<IDeintractOperator<IDiggable>>().To<DigOperator>().FromInstance(digOperator).AsSingle();
    }
}