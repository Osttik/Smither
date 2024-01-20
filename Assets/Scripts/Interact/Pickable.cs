using Assets.Core.Inventory;
using Assets.Scripts.Abstraction;
using UnityEngine;
using Zenject;

public class Pickable : MonoBehaviour, IPickable
{
    [SerializeField]
    private Interactable _interactable;

    [SerializeField]
    private ItemObject _itemGameObject;

    [Inject]
    private InteractManager _interactManager;

    private void Start()
    {
        if (_interactable != null)
        {
            Debug.Log("Register interact");
            _interactable.OnInteractPossible += ProceedInteract;
        }
    }

    public void ProceedInteract(Collider2D collision)
    {
        Debug.Log("On Inner proceed");
        if (!collision.TryGetComponent<PickConsumer>(out var consumer))
        {
            return;
        }
        Debug.Log(consumer);

        _interactManager.ProceedInteraction(this, consumer);
    }

    public GameObject GetGameObject()
    {
        return _itemGameObject.gameObject;
    }

    public Item Pick()
    {
        return _itemGameObject.Item;
    }
}
