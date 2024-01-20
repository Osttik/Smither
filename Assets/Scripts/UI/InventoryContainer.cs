using Assets.Scripts.Abstraction;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.WSA;

public class InventoryContainer : MonoBehaviour
{
    [SerializeField]
    private ListViewPort _listViewPort;

    [SerializeField]
    private GameObject _holder;

    public void Reload()
    {
        _listViewPort.ClearList();

        if (!_holder.TryGetComponent<IInventoryHolder>(out var holder)) return;

        foreach (var item in holder.Inventory.Items)
        {
            _listViewPort.AddChild(child =>
            {
                var editable = child.GetEditableElement();

                editable.text = item.NameTag + " | " + item.Weight.ToString() + " Kg | " + item.Price.ToString() + " coin";
            });
        }

    }

    private void OnEnable()
    {
        Reload();
    }
}
