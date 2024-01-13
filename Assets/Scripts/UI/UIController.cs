using Assets.Scripts.Abstraction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject _inventoryPanel;

    private InventoryUIController _inventoryItemsControll;

    private void Start()
    {
        _inventoryItemsControll = GetComponent<InventoryUIController>();
    }

    public void OpenCloseInventory()
    {
        bool activate = !_inventoryPanel.activeInHierarchy;
        _inventoryPanel.SetActive(activate);

        if (activate)
        {
            _inventoryItemsControll.Reload();
        }
    }
}
