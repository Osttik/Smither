using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ListViewPort : MonoBehaviour
{
    [SerializeField]
    private RectTransform _viewPort;

    [SerializeField]
    private ListCell _cell;

    private List<ListCell> _cells = new List<ListCell>();

    public void ClearList()
    {
        for (int i = 0; i < _cells.Count; i++)
        {
            Destroy(_cells[i].gameObject);
        }

        _cells.Clear();

        ResizeList(_viewPort.sizeDelta.y * -1);
    }

    public void AddChild(Action<ListCell> onAdded)
    {
        var element = Instantiate(_cell, _viewPort);
        var rectOfPrefab = element.GetComponent<RectTransform>();

        AppendToBeLast(rectOfPrefab);

        onAdded.Invoke(element);

        ResizeList(rectOfPrefab.rect.height);
    }

    private void AppendToBeLast(RectTransform newElement)
    {
        newElement.anchoredPosition = new Vector2(newElement.anchoredPosition.x, newElement.anchoredPosition.y - _viewPort.sizeDelta.y);
    }

    private void ResizeList(float resizeDelta)
    {
        _viewPort.sizeDelta = new Vector2(_viewPort.sizeDelta.x, _viewPort.sizeDelta.y + resizeDelta);
    }
}
