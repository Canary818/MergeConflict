using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IPointerClickHandler, IDropHandler
{
    public UnityEvent OnInteract;
    public void OnDrop(PointerEventData eventData)
    {
        Item item = eventData.pointerDrag.GetComponent<Item>();
        OnInteract.Invoke();
        Debug.Log(item.name + " used on " + name);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(name  + " inspected!");
    }

    
}
