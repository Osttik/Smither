using Assets.Core;
using Assets.Scripts.Abstraction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreObject : ItemObject
{
    [SerializeField]
    private string _nameTag = string.Empty;

    public override void OnStart()
    {
        base.OnStart();
        if (_nameTag != string.Empty)
        {
            _item = GameObject.Find("Controllers").GetComponent<Manager>().DataReader.OreMixes[_nameTag];
        }
    }
}
