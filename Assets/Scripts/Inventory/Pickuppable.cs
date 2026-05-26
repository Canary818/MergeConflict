using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class Pickuppable : Interactable
{
    InventoryManager inventory;
    [SerializeField] private ItemDataSO itemDataSO;
    [SerializeField] private bool removeAfterPickup = true;

    void Start()
    {
        inventory = ReferenceManager.Instance.inventoryManager;
    }

    protected override void Interact()
    {
        inventory.Add(itemDataSO);
        Debug.Log("picked up!");
        base.Interact();
        if (removeAfterPickup)
            Destroy(gameObject);
    }
}
