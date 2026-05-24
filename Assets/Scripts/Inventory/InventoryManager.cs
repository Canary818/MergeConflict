using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    List<ItemDataSO> items = new List<ItemDataSO>();

    public event Action<List<ItemDataSO>> InventoryUpdated;

    void Awake()
    {
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        
    }

    public void AddItem(ItemDataSO itemAsset)
    {
        Debug.Log("Item added: " + itemAsset.name);
        items.Add(itemAsset);
        Debug.Log("inventory count: " + items.Count);
        InventoryUpdated?.Invoke(items);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
