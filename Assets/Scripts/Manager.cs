using Assets.Core.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public DataReader DataReader = new();

    private void Awake()
    {
        DataReader.ReadOres();
    }
}
