using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionSystem : MonoBehaviour, IInputHandler
{
    public LayerMask mask;
    public void HandleInput(InputManager.InputEvent inputEvent)
    {
        RaycastHit2D selectable = Physics2D.Raycast(inputEvent.mousePos, Vector2.zero, 0f, mask);
        if (selectable.collider != null)
        {
            Debug.Log(selectable.collider);
        }
        else
        {
            Debug.Log("No hit" + selectable.collider);
            Debug.Log("Position" + inputEvent.mousePos);
        }
    }

    private void OnEnable()
    {
        InputManager.OnInteract += HandleInput;
    }

    private void OnDisable()
    {
        InputManager.OnInteract -= HandleInput;
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
