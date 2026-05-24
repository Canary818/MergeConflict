using UnityEngine;
using UnityEngine.EventSystems;

public class Pickuppable : Interactable
{
    InventoryManager inventory;
    public ItemDataSO itemDataSo;

    void Start()
    {
        inventory = ReferenceManager.Instance.inventoryManager;
    }

    protected override void Interact()
    {
        inventory.Add(itemDataSo);
        Debug.Log("picked up!");
        base.Interact();
    }
}
