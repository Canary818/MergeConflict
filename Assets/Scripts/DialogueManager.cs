using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using System.Security.Cryptography;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textField;
    [SerializeField] private GameObject textBox;
    private ReferenceManager referenceManager;

    //Runtime Vars
    public bool isTypeWriterRunning = false;
    public bool IsDialogueRunning = false;
    private List<string> subStrings = new();
    private int currentSubStringIndex = 0;
    private string stringCurrentlyBeingTypewritten;

    //Tuning Vars
    [SerializeField] private float typeWriterDelayBetweenChars;
    [SerializeField] private GameObject[] choices;
    [SerializeField] private TextMeshProUGUI[] choiceTexts;

    public TextAsset test;

    private Story currentStory;

    private void Start()
    {
        referenceManager = ReferenceManager.Instance;
        EnterDialogueMode(test);

        HideChoices();
    }

    public void EnterDialogueMode(TextAsset inkjson)
    {
        IsDialogueRunning = true;
        currentStory = new Story(inkjson.text);
        //dialogueCurrentlyPlaying = true;
        
        ContinueStory();
    }

    private IEnumerator TypeWriter(string dialogue)
    {
        isTypeWriterRunning = true;
        string stringToBuild = "";
        stringCurrentlyBeingTypewritten = dialogue;
        foreach (char character in dialogue)
        {
            stringToBuild = stringToBuild + character;
            textField.text = stringToBuild;
            yield return new WaitForSeconds(typeWriterDelayBetweenChars);
        }
        isTypeWriterRunning = false;
        currentSubStringIndex++;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            ContinueStory();
        }
    }

    private void ContinueStory()
    {
        if (isTypeWriterRunning)
        {
            StopAllCoroutines();
            textField.text = stringCurrentlyBeingTypewritten;           
            isTypeWriterRunning = false;
            return;
        }

        if (currentStory.canContinue)
        {
            Debug.Log("Continuing Story");
            stringCurrentlyBeingTypewritten = currentStory.Continue();
            StartCoroutine(TypeWriter(stringCurrentlyBeingTypewritten));
        }
        else
        {
            Debug.Log("NOT Continuing Story");
            CreateChoices();
            if (currentStory.currentChoices.Count > 0)
            {
                
            }
        }
    }

    private void CreateChoices()
    {
        int i = 0;
        foreach (TextMeshProUGUI text in choiceTexts)
        {
            choices[i].SetActive(true);
            List<Choice> currentChoices = currentStory.currentChoices;
            text.text = currentChoices[i].text;
            i++;
        }
    }


    private void HideChoices()
    {
        foreach (GameObject choice in choices)
        {
            choice.SetActive(false);
        }
    }

    public void MakeChoice(int index)
    {
        HideChoices();

        currentStory.ChooseChoiceIndex(index);
        ContinueStory();
    }


}
