using Assets.Scripts.Abstraction;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUIController : MonoBehaviour, IUIControll
{
    [SerializeField]
    private RectTransform _viewPort;
    [SerializeField]
    private TextMeshProUGUI _itemElement;

    [SerializeField]
    private GameObject _holder;

    public void Reload()
    {
        for (int i = 0; i < _viewPort.transform.childCount; i++)
        {
            Destroy(_viewPort.transform.GetChild(i).gameObject);
        }

        if (!_holder.TryGetComponent<IInventoryHolder>(out var holder)) return;
        
        float size = 0;

        foreach (var item in holder.Inventory.Items)
        {
            var element = Instantiate(_itemElement, _viewPort);
            var rectOfPrefab = element.GetComponent<RectTransform>();

            rectOfPrefab.anchoredPosition = new Vector2(rectOfPrefab.anchoredPosition.x, rectOfPrefab.anchoredPosition.y - size);
            element.text = item.NameTag + " | " + item.Weight.ToString() + " Kg | " + item.Price.ToString() + " coin";

            size += rectOfPrefab.rect.height;
        }

        var rect = _viewPort.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, size);

        var rectParent = _viewPort.root.GetComponent<RectTransform>();
        rectParent.rect.Set(rectParent.rect.x, rectParent.rect.y, rectParent.rect.width, size);
    }

    void Start()
    {
        _viewPort = _viewPort != null ? _viewPort : GameObject.Find("InventoryItemsContent").GetComponent<RectTransform>();
    }
}
