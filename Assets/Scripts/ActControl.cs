using Assets.Core.Inventory;
using Assets.Scripts.Abstraction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActControl : MonoBehaviour, IInteractConsumer<IDiggable, Item>
{
    [SerializeField]
    private IActorInvetoryHolder _holder;

    public void DoAction()
    {

    }

    public void ConsumeInteraction(IDiggable target, Item result)
    {
        _holder.Inventory.TryAdd(result);
    }
}
