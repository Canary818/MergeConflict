using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IPointerClickHandler, IDropHandler
{
    public UnityEvent OnInteract;

    // for drag and drop items. 
    public void OnDrop(PointerEventData eventData)
    {
        ItemDataSO item = eventData.pointerDrag.GetComponent<DraggableItem>().itemDataSo;
        Interact();
        Debug.Log(item.name + " used on " + name);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(name  + " inspected!");
        Interact();
    }

    protected virtual void Interact()
    {
        OnInteract.Invoke();
    }
    
}
