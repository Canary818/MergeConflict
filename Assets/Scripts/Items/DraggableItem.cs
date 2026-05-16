using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Image = UnityEngine.UI.Image;


public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public ItemData itemData;
    Image image;
    [HideInInspector] public Transform parentAfterDrag;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void UpdateItemData(ItemData item)
    {
        itemData = item;
        if (itemData)
        {
            gameObject.SetActive(true);
            image.sprite = item.sprite;
        }
        else
        {
            gameObject.SetActive(false);
            image.sprite = null;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("released");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }

}
