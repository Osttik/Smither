using Assets.Core.Inventory;
using Assets.Scripts.Abstraction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour, IPickable
{
    [SerializeField]
    protected Interactable _interact;
    [SerializeField]
    protected Item _item = null;

    void Start()
    {
        _interact = _interact != null ? _interact : GetComponent<Interactable>();
        OnStart();
    }

    public void SetItem(Item item)
    {
        _item = item;
    }

    public virtual void OnStart() { }

    public Item Pick()
    {
        Debug.Log(_item);
        return _item;
    }
}
