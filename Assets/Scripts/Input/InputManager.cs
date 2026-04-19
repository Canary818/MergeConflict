using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

// singleton to poll input per frame
public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public PlayerInput input;

    public static event Action<InputEvent> OnInteract;


    public struct InputData
    {
        public bool started;
        public bool performed;
        public bool canceled;
    }
    public struct InputEvent
    {
        public InputData data;
        public Vector2 mousePos;
    }

    void Awake()
    {
        input = GetComponent<PlayerInput>();
        Instance = this;

    }

    private void OnEnable()
    {
        input.onActionTriggered += HandleInput;
    }

    private void OnDisable()
    {
        input.onActionTriggered -= HandleInput;
    }

    void HandleInput(InputAction.CallbackContext ctx)
    {
        if (ctx.action.name == "PrimaryClick" && ctx.performed)
        {
            HandleClick(ctx);           
        }

    }

    void HandleClick(InputAction.CallbackContext ctx)
    {
        // conduct ray cast to what's on screen
        Vector2 screenPos = Mouse.current.position.ReadValue();

        var point = Camera.main.ScreenToWorldPoint(screenPos);
        var inputEvent = new InputEvent();
        {
            inputEvent.mousePos = point;
            inputEvent.data.started = ctx.started;
            inputEvent.data.performed = ctx.performed;
            inputEvent.data.canceled = ctx.canceled;
        }

        LayerMask mask = LayerMask.GetMask("World");
        RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero, 0f, mask);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("World"))
            {
                OnInteract?.Invoke(inputEvent);
            }
        }
        /*
        foreach (Collider2D c in result)
        {
            // check ui first
            // check item
            if (c.CompareTag("World"))
            {
                OnInteract?.Invoke(inputEvent);
            }
            // check world
        }
        */

        
    }

}
