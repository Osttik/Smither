using Assets.Core;
using Assets.Core.Inventory;
using Assets.Scripts.Abstraction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreObject : ItemObject
{
    [SerializeField]
    private Manager _manager;

    [SerializeField]
    private string _nameTag = string.Empty;

    private void Start()
    {
        _manager.DataReader.OnAfterLoaded += LoadData;
    }

    private void OnDestroy()
    {
        _manager.DataReader.OnAfterLoaded -= LoadData;
    }

    public void LoadData()
    {
        if (_nameTag != string.Empty)
        {
            _item = GameObject.Find("Controllers").GetComponent<Manager>().DataReader.OreMixes[_nameTag];
        }
    }
}
