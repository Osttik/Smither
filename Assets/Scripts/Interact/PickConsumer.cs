using Assets.Core.Inventory;
using Assets.Scripts.Abstraction;
using UnityEngine;

public class PickConsumer : MonoBehaviour, IInteractConsumer<IPickable, Item>
{
    public void ConsumeInteraction(IPickable target, Item result)
    {
        
    }
}
