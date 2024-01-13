using Assets.Core.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _loadAfter = new List<GameObject>();
    public DataReader DataReader = new();

    private void Awake()
    {
        DataReader.ReadOres();
        foreach (GameObject obj in _loadAfter)
        {
            obj.SetActive(true);
        }
    }
}
