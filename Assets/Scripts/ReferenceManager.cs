using UnityEngine;

public class ReferenceManager : MonoBehaviour
{
    //Singleton Stuff
    public static ReferenceManager Instance { get; private set; }
    //Refs
    public DialogueManager dialogueManager;
    public Inventory inventoryManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than 1 ReferenceManager in this scene! That's messed up fix it!!!");
        }
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}