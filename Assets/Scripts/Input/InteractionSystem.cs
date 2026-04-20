using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField] private InputReader input;

    public LayerMask mask;
    public void HandleInput(Vector2 position)
    {
        Vector2 target = Camera.main.ScreenToWorldPoint(position);
        Collider2D selectable = Physics2D.OverlapPoint(target, mask);
        if (selectable != null)
        {
            Debug.Log(selectable.gameObject);
        }
        else
        {
            Debug.Log("No hit: " + selectable);
            Debug.Log("Position: " + target);
        }
    }

    private void OnEnable()
    {
        input.InteractEvent += HandleInput;
    }

    private void OnDisable()
    {
        input.InteractEvent -= HandleInput;
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
