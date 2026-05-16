using System.Collections.Generic;
using UnityEngine;

// Inventory bar manages the visual side of the inventory, allowing user to cycle
// through items, if more items than slots are available
public class InventoryBar : MonoBehaviour
{
    ReferenceManager referenceManager;
    [SerializeField] int currentIndex = 0;

    // place the singular parent of all the inventory slots
    [SerializeField] GameObject inventorySlotContainer = null;  
    DraggableItem[] itemHolders;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
    }
    void Start()
    {
        referenceManager = ReferenceManager.Instance;
        referenceManager.inventoryManager.InventoryUpdated += UpdateInventoryBar;
        if (inventorySlotContainer)
        {
            for (int i = 0; i < inventorySlotContainer.transform.childCount; i++)
            {
                itemHolders = inventorySlotContainer.transform.GetComponentsInChildren<DraggableItem>();
            }
        }
        else
        {
            Debug.LogError("Need to have a container for inventory slots!");
        }
    }
    void OnDisable()
    {
        referenceManager.inventoryManager.InventoryUpdated -= UpdateInventoryBar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementIndex()
    {

    }

    public void DecrementIndex()
    {

    }

    // possibly redo this update bar function if performance takes a hit from 
    // cleaning and allocating on inventory on inventory update 
    public void UpdateInventoryBar(List<ItemData> itemDatas)
    {
        int available = itemDatas.Count - currentIndex;
        for (int i = 0; i < itemHolders.Length; i++)
        {
            if (i < available)
                itemHolders[i].UpdateItemData(itemDatas[currentIndex + i]);
            else 
                itemHolders[i].UpdateItemData(null);
        }
    }
}
