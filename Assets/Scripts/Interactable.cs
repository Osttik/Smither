using Assets.Scripts.Abstraction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var consumers = collision.GetComponents<IInteractConsumer>();
        if (consumers == null) return;

        foreach (var consumer in consumers)
        {
            consumer.Interact(transform.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var consumers = collision.GetComponents<IDeinteractConsumer>();
        if (consumers == null) return;

        foreach (var consumer in consumers)
        {
            consumer.Deinteract(transform.gameObject);
        }
    }
}
