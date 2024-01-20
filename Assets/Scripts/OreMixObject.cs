using Assets.Core;
using Assets.Scripts.Abstraction;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OreMixObject : MonoBehaviour//, IInteractable
{
    [SerializeField]
    private GameObject _orePiecePrefab;
    [SerializeField]
    private Manager _manager;
    [SerializeField]
    private string _nameTag = string.Empty;
    public string NameTag { get => _nameTag; set => _nameTag = value; }

    private OreMix _mix;

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
        _mix = GameObject.Find("Controllers").GetComponent<Manager>().DataReader.OreMixes[_nameTag];
    }

    public void InteractIn(GameObject interactor)
    {
        if (_mix == null || !interactor.TryGetComponent<IInventoryHolder>(out var holder)) return;
        var requiredTool = holder.Inventory.Items.FirstOrDefault(i => (i as Tool)?.Type == _mix.RequiredToolType);
        if (requiredTool == null) return;

        var intatiated = Instantiate(_orePiecePrefab, transform.position, transform.rotation);

        if (_mix.Weight - 10 < 0)
        {
            intatiated.GetComponent<ItemObject>().Item = _mix;

            Destroy(transform.gameObject);

            return;
        }
        var rarityPoints = _mix.MixedOres.Sum(x => x.Rarity);

        var toDrop = new OreMix()
        {
            Durability = _mix.Durability,
            MixedOres = _mix.MixedOres.Select(m =>
            {
                var weight = m.Rarity / rarityPoints * m.Weight;
                m.Weight -= weight;

                return new Ore()
                {
                    Material = m.Material,
                    Weight = weight,
                    Rarity = m.Rarity,
                    NameTag = m.NameTag
                };
            }).ToList(),
            NameTag = _mix.NameTag
        };

        intatiated.GetComponent<ItemObject>().Item = toDrop;
    }
}
