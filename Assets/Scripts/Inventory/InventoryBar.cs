using System.Collections.Generic;
using UnityEngine;

// Inventory bar manages the visual side of the inventory, allowing user to cycle
// through items, if more items than slots are available
public class InventoryBar : MonoBehaviour
{
    ReferenceManager referenceManager;
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
        referenceManager = ReferenceManager.Instance;
        referenceManager.inventoryManager.InventoryUpdated += UpdateInventoryBar;
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
        referenceManager.inventoryManager.InventoryUpdated -= UpdateInventoryBar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementIndex()
    {
        if (draggableItems.Length > slotCount)
        {
            currentIndex++;
            Debug.Log("incremented" + currentIndex);
        }
    }       

    public void DecrementIndex()
    {
        if (draggableItems.Length > slotCount & currentIndex > slotCount)
        {
            currentIndex--;
            Debug.Log("decremented" + currentIndex);
        }
    }

    // possibly redo this update bar function if performance takes a hit from 
    // cleaning and allocating on inventory update 
    public void UpdateInventoryBar(List<ItemDataSO> itemDatas)
    {
        int available = itemDatas.Count - currentIndex;
        for (int i = 0; i < draggableItems.Length; i++)
        {
            if (i < available)
                draggableItems[i].UpdateItemData(itemDatas[currentIndex + i]);
            else 
                draggableItems[i].UpdateItemData(null);
        }
    }
}
