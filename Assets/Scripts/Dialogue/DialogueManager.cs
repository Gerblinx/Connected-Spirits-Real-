using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject[] choices;

    [SerializeField] private GameObject sinkTrigger;
    [SerializeField] private GameObject vCSink;
    [SerializeField] private GameObject water;


    private TextMeshProUGUI[] choiceText;

    private Story currentstory;

    public bool sinkDialogue;
    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManager instance;

    private void Awake()
    {
        water.SetActive(false);
        
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of DialogueManager in scene");
        }

        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choiceText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach(GameObject choice in choices)
        {
            choiceText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }


    }

    private void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ContinueStory();
        }

        
    }

    

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentstory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();

    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentstory.canContinue)
        {
            dialogueText.text = currentstory.Continue();

            DisplayChoices();
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentstory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More Choices were given than the UI can support");

        }

        int index = 0;

        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choiceText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }


    }

    public void OnSinkClickYes()
    {
       StartCoroutine(ExitDialogueMode());
       Destroy(sinkTrigger);
       Destroy(vCSink);
       water.SetActive(true);

    }

    public void OnSinkClickNo()
    {
        StartCoroutine(ExitDialogueMode());
    }

}
