using Assets.Core.Inventory;
using Assets.Scripts.Abstraction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField]
    protected Item _item = null;

    public Item Item
    {
        get => _item;
        set => _item = value;
    }
}
