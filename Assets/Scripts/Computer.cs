using System.Buffers;
using UnityEngine;

public class Computer : MonoBehaviour
{
    [SerializeField] GameObject gif;
    private ReferenceManager referenceManager;
    [SerializeField] private TextAsset textToDisplay;

    private void Start()
    {
        referenceManager = ReferenceManager.Instance;
    }

    public void ActivateGif()
    {
        if (!gif.activeInHierarchy)
            gif.SetActive(true);
        else
            gif.SetActive(false);
    }

    public void DisplayText()
    {
        referenceManager.dialogueManager.EnterDialogueMode(textToDisplay);
    }

}
