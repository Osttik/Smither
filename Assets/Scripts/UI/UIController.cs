using Assets.Scripts.Abstraction;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private InventoryContainer _inventoryContainer;

    [SerializeField]
    private TextMeshProUGUI _itemElement;

    [SerializeField]
    private GameObject _holder;

    public void OpenCloseInventory()
    {
        bool activate = !_inventoryContainer.gameObject.activeSelf;
        _inventoryContainer.gameObject.SetActive(activate);
    }
}
