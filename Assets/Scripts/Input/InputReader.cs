using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

// singleton to poll input per frame
[CreateAssetMenu(menuName = "InputReader")]
public class InputReader : ScriptableObject, AdventureInput.IExploreActions
{
    public event Action<Vector2> InteractEvent;

    public event Action<Vector2> PointEvent;

    private AdventureInput adventureInput;

    private void OnEnable()
    {
        adventureInput = new AdventureInput();

        adventureInput.Explore.SetCallbacks(this);

        SetExplore();
    }

    public void SetExplore()
    {
        adventureInput.Explore.Enable();
        // disable UI
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started)
            InteractEvent?.Invoke(Mouse.current.position.ReadValue());
        HandleClick(Mouse.current.position.ReadValue());
    }

    public void HandleClick(Vector2 screenPos)
    {
        /*
        Vector2 target = Camera.main.ScreenToWorldPoint(screenPos);
        Collider2D selectable = Physics2D.OverlapPoint(target);
        if (selectable == null)
        {
            Debug.Log("No hit: " + selectable);
            Debug.Log("Position: " + target);
            return;
        }

        Debug.Log(selectable.gameObject);
        if (selectable.CompareTag("World"))
        {
            InteractEvent?.Invoke(target);
        }
        */
    }
}
