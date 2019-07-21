using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {

    public static DialogueSystem Instance { get; set; }

    public GameObject dialogueCanvas;
    public GameObject dialoguePanel;

    Text dialogueText, nameText;
    Image faceObj;
    int dialogueIndex;
    public AudioSource textAudio;
    public AudioClip textClip;

    float buttonRecast = 1;
    public float buttonRecastReset = 1;

    public string CharName;
    public List<string> dialogueLines = new List<string>();
    public Sprite FacePortrait;

    public bool dialogueBegin = false;
    public bool ContinueAvailable = false;

    public string resetText;
    public string resetName;
    public Sprite resetPortrait;


    void Awake()
    {
        dialogueCanvas = GameObject.Find("HUD").gameObject;
        dialoguePanel = dialogueCanvas.transform.Find("Text").gameObject;
        dialogueText = dialoguePanel.transform.Find("TextBox").gameObject.GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("Name").gameObject.GetComponent<Text>();
        faceObj = dialoguePanel.transform.Find("Face").gameObject.GetComponent<Image>();
        textAudio = dialoguePanel.GetComponent<AudioSource>();

        /*if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }*/
        Instance = this;
        ResetText();
    }
	
	// Update is called once per frame
	void Update () {
        buttonRecast -= Time.fixedDeltaTime;
        if(dialogueBegin == true)
        {
            if (dialogueText.text == (dialogueLines[dialogueIndex]))
            {
                ContinueAvailable = true;
            }

            if (dialogueBegin && ContinueAvailable)
            {
                if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    ContinueAvailable = false;
                    ContinueText();
                }
            }
            if (!dialogueBegin)
            {
                textAudio.Stop();
            }
        }
    }

    public void AddNewText(string[] lines, string Name, Sprite Face)
    {
        dialogueIndex = -1;
        dialogueLines = new List<string>();
        foreach (string line in lines)
        {
            dialogueLines.Add(line);
        }
        this.CharName = Name;
        // Debug.Log(dialogueLines.Count - 1);
        this.FacePortrait = Face;
        Game.current.trackingGame.GameplayPaused = true;
        CreateText();
    }

    public void CreateText()
    {
        nameText.text = CharName;
        faceObj.sprite = FacePortrait;
        dialogueBegin = true;
        ContinueText();
    }

    public void ContinueText()
    {
        if (dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = "";
            StopAllCoroutines();
            StartCoroutine(TypeSentence(dialogueLines[dialogueIndex]));
        }
        else
        {
            ResetText();
            dialogueBegin = false;
        }
    }

    public void ResetText()
    {
        dialogueText.text = resetText;
        nameText.text = resetName;
        faceObj.sprite = resetPortrait;
        Game.current.trackingGame.GameplayPaused = false;
    }

    IEnumerator TypeSentence(string sentence)
    {
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            if (textAudio != null)
            {
                textAudio.clip = textClip;

                textAudio.Play();
            }

            yield return null;
        }
    }
}
