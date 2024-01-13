using Assets.Scripts.Abstraction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActControll : MonoBehaviour, IInteractConsumer, IDeinteractConsumer
{
    [SerializeField]
    private IActor _actor;

    public List<IInteractable> Interactables { get; set; } = new();

    private void Start()
    {
        _actor ??= GetComponent<IActor>();
    }

    public void Interact(GameObject obj)
    {
        if (!obj.TryGetComponent<IInteractable>(out var interactable)) return;

        Interactables.Add(interactable);
    }

    public void DoAction()
    {
        foreach (var obj in Interactables)
        {
            _actor.Act(obj);
        }
    }

    public void Deinteract(GameObject obj)
    {
        Interactables.Remove(obj.GetComponent<IInteractable>());
    }
}
