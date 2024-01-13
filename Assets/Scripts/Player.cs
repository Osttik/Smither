using Assets.Core.Inventory;
using Assets.Scripts.Abstraction;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour, IInventoryHolder, IPuttable, IActor
{
    public Inventory Inventory { get; private set; } = new Inventory();

    public bool PutItem(Item item)
    {
        return Inventory.TryAdd(item);
    }

    public void Act(IInteractable obj)
    {
        obj.InteractIn(transform.gameObject);
    }

    public void Update()
    {
        GameObject.Find("Dbug").GetComponent<TextMeshProUGUI>().text = Inventory.Items.Count.ToString();
    }
}
