using UnityEngine;

public class Inventory : MonoBehaviour
{
    DraggableItem currentItem = null;
    [SerializeField] GameObject inventoryBar;

    void ViewInventory()
    {
        if (inventoryBar.activeSelf)
            inventoryBar.SetActive(false);
        else
            inventoryBar.SetActive(true);
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        
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
