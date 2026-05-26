using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Image = UnityEngine.UI.Image;


public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public ItemDataSO itemDataSo;
    Image image;
    [HideInInspector] public Transform parentAfterDrag;
    bool isEmpty = true;

    void Awake()
    {
        image = GetComponent<Image>();
        image.enabled = false;
    }

    public void UpdateItemData(ItemDataSO item)
    {
        itemDataSo = item;
        if (itemDataSo)
        {
            isEmpty = false;
            image.sprite = item.sprite;
            image.enabled = true;
        }
        else
        {
            isEmpty = true;
            image.sprite = null;
            image.enabled = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isEmpty)
            return;
        //Debug.Log("Begin");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isEmpty)
            return;
        //Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("released");
        transform.SetParent(parentAfterDrag);

        RectTransform rect = transform as RectTransform;
        rect.anchoredPosition = Vector2.zero;

        image.raycastTarget = true;
    }

}
