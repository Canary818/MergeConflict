using UnityEngine;
using UnityEngine.EventSystems;

public class MenuItem : MonoBehaviour
{
    [SerializeField] GameObject linkedObject;
    bool isActive;

    void Awake()
    {
        // Toggle disables itself if not set in editor
        if (!linkedObject)
        {
            linkedObject = this.gameObject;
        }
        isActive = linkedObject.activeInHierarchy;
    }

    public void ToggleMenu()
    {
        isActive = isActive ? false : true;
        linkedObject.SetActive(isActive);
    }
}
