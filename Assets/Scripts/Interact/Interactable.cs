using Assets.Scripts.Abstraction;
using System;
using UnityEngine;
using Zenject;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    public event Action<Collider2D> OnInteractPossible;

    [SerializeField]
    public event Action<Collider2D> OnDeInteract;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var consumers = collision.GetComponents<IInteractConsumer>();
        if (consumers == null) return;

        OnInteractPossible!.Invoke(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var consumers = collision.GetComponents<IInteractConsumer>();
        if (consumers == null) return;

        foreach (var consumer in consumers)
        {
            OnDeInteract!.Invoke(collision);
        }
    }
}
