using Assets.Scripts.Abstraction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickControll : MonoBehaviour, IInteractConsumer
{
    [SerializeField]
    private IPuttable _puttable;

    private void Start()
    {
        _puttable ??= GetComponent<IPuttable>();
    }

    public void Interact(GameObject obj)
    {
        if (!obj.TryGetComponent<IPickable>(out var pickable)) return;

        if (_puttable.PutItem(pickable.Pick()))
        {
            Destroy(obj);
        }
    }
}
