using UnityEngine;

public class UIInteractionSystem : MonoBehaviour
{
    [SerializeField] private InputReader input;

    void HandleInput(Vector2 screenPos)
    {
        
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
