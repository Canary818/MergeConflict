using System.Collections.Generic;
using UnityEngine;

// Inventory bar manages the visual side of the inventory, allowing user to cycle
// through items, if more items than slots are available
public class InventoryBar : MonoBehaviour
{
    InventoryManager inventory;
    [SerializeField] private int currentIndex = 0;
    [SerializeField] private int slotCount = 5;  

    // place the singular parent of all the inventory slots
    [SerializeField] GameObject inventorySlotContainer = null;  
    DraggableItem[] draggableItems ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
    }
    void Start()
    {
        inventory = ReferenceManager.Instance.inventoryManager;
        inventory.InventoryUpdated += UpdateInventoryBar;
        draggableItems = new DraggableItem[slotCount];
        
        if (inventorySlotContainer)
        {
            for (int i = 0; i < inventorySlotContainer.transform.childCount; i++)
            {
                draggableItems[i] = inventorySlotContainer.transform.GetChild(i).GetComponentInChildren<DraggableItem>();
            }
            Debug.Log(draggableItems);
        }
        else
        {
            Debug.LogError("Need to have a container for inventory slots!");
        }
    }
    private void OnDestroy() 
    {
        inventory.InventoryUpdated -= UpdateInventoryBar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementIndex()
    {
        int maxIndex = inventory.Count / slotCount;
        if (inventory.Count > slotCount && currentIndex  < maxIndex)
        {
            currentIndex++;
            Debug.Log("incremented" + currentIndex);
        }
        UpdateInventoryBar();
    }       

    public void DecrementIndex()
    {
        if ((inventory.Count > slotCount) && (currentIndex > 0))
        {
            currentIndex--;
            Debug.Log("decremented" + currentIndex);
        }
        UpdateInventoryBar();
    }

    // possibly redo this update bar function if performance takes a hit from 
    // cleaning and allocating on inventory update 
    public void UpdateInventoryBar()
    {
        for (int i = 0; i < draggableItems.Length; i++)
        {
            draggableItems[i].UpdateItemData(inventory.GetItem((currentIndex * slotCount) + i));
        }
    }
}
