using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    List<ItemDataSO> items ;

    public event Action InventoryUpdated;

    void Awake()
    {
        items = new List<ItemDataSO>();
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        
    }

    public void Add(ItemDataSO itemAsset)
    {
        Debug.Log("Item added: " + itemAsset.name);
        items.Add(itemAsset);
        InventoryUpdated?.Invoke();
    }

    public ItemDataSO GetItem(int index)
    {
        if (index <= (items.Count - 1) && index >= 0)
            return items[index];
        return null;
    }

    public int Count => items.Count;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
