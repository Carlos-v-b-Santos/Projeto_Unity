using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using Ink.UnityIntegration;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;

    [Header("Globals Ink File")]
    [SerializeField] private InkFile globalsInkFile;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    private Story currentStory;

    private bool dialogueIsPlaying;

    public static DialogueManager instance;

    private const string SPEAKER_TAG = "speaker";

    private DialogueVariables dialogueVariables;

    GameManager gameManager;
    public event Action Finalizar;

    //desativar script
    public GameObject Player;
    public GameObject botao_proximo;

    // Start is called before the first frame update
    private void Awake()
    {
        Player = GameObject.FindWithTag("Player");
        botao_proximo = GameObject.Find("Next");

        if (instance != null)
        {
            Debug.LogWarning("Mais de uma instancia");
        }

        instance = this;

        dialogueVariables = new DialogueVariables(globalsInkFile.filePath);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }
    
    void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach(GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }

        //if(Input.GetKeyUp(KeyCode.Escape))
        //{
        //    ContinueStory();
        //}
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        //Player.GetComponent<MouseMove>().enabled = false;
        //------------------

        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        dialogueVariables.StartListening(currentStory);

        currentStory.BindExternalFunction("finalizarQuestStep", () =>
        {
            Debug.Log("finalizar parte da quest");
            Finalizar();
        });

        currentStory.BindExternalFunction("increaseEtica", (float value) =>
        {
            Debug.Log(value);
            gameManager.IncreaseEtica(value);
        });

        displayNameText.text = "???";

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        //Player.GetComponent<MouseMove>().enabled = true;

        dialogueVariables.StopListening(currentStory);

        currentStory.UnbindExternalFunction("increaseEtica");
        currentStory.UnbindExternalFunction("finalizarQuestStep");

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        GameEventsManager.Instance.dialogueEvents.ExitDialogue();
    }

    public void ContinueStory()
    {
        if(currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();

            DisplayChoices();

            HandleTags(currentStory.currentTags);
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach(string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if(splitTag.Length != 2)
            {
                Debug.LogError("Tag nao pode ser dividida" + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch(tagKey)
            {
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                default:
                    Debug.LogWarning("sem Tag" + tag);
                    break;
            }
        }
    }
    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if(currentChoices.Count > choices.Length)
        {
            Debug.LogError("Mais escolhas que o UI suporta" + currentChoices.Count);
        }

        int index = 0;

        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for(int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);

        }

       // StartCoroutine(SelectFirstChoice());
    }

    //private IEnumerator SelectFirstChoice()
    //{
        //EventSystem.current.SetSelectedGameObject(null);
        //yield return new WaitForEndOfFrame();
      //  EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    //}

    public void MakeChoice(int choiceIndex){
        currentStory.ChooseChoiceIndex(choiceIndex);

        //teste
        

    ContinueStory();
    }

    private void OnEnable()
    {
        GameEventsManager.Instance.dialogueEvents.OnEnterDialogue += EnterDialogueMode;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.dialogueEvents.OnEnterDialogue -= EnterDialogueMode;
    }
}
