using UnityEngine;
using UnityEngine.EventSystems;

public class Pickuppable : Interactable
{
    InventoryManager inventory;
    public ItemData itemData;

    void Start()
    {
        inventory = ReferenceManager.Instance.inventoryManager;
    }

    protected override void Interact()
    {
        inventory.AddItem(itemData);
        Debug.Log("picked up!");
        base.Interact();
    }
}
