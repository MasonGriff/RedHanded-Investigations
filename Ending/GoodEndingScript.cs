using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class GoodEndingScript : MonoBehaviour {
    string Name = "";
    public Sprite Face;

    public Text textBox;

    public GameObject endText;

    public float ToCredTransition = 2;

    public string[] ClosingLines;

    public string EvidenceCounting;

    //public int dialogueSequenceNumber;  
    //public int dialogueSequenceMaximum = 2;
    public bool dialogueStarted;

    public int SequenceNumber = 0;

    public bool endFinish = false;
    // Use this for initialization
    void Start () {
        if (Game.current != null)
        {
            EvidenceCounting = ("You have found " + Game.current.trackingGame.SufficientEvidence + " of 9 possible pieces of sufficente evidence.");
        }
        Debug.Log(EvidenceCounting);
        endText.SetActive(false);
        SequenceNumber = 1;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(EvidenceCounting));
    }
	
	// Update is called once per frame
	void Update () {
		if (SequenceNumber == 1)
        {
            if (textBox.text == EvidenceCounting)
            {
                if (Input.anyKeyDown)
                {
                    SequenceNumber = 2;
                    textBox.text = "";
                }
            }
        }
        else if (SequenceNumber == 2)
        {
            DialogueGo();
            dialogueStarted = true;
            SequenceNumber = 3;
        }
        else if (SequenceNumber == 3)
        {
            if (dialogueStarted && !(DialogueSystem.Instance.dialogueBegin))
            {
                //Game.current.Alyzara.GameplayPaused = false;
                endText.SetActive(true);
                endText.transform.DOScale(1, ToCredTransition);
                Invoke("EndPrep", ToCredTransition);
                SequenceNumber = 4;
            }
        }
        else if (SequenceNumber == 4)
        {
            if(endFinish == true)
            {
                if (Input.anyKeyDown)
                {
                    ToCredits();
                }
            }
        }
	}

    void DialogueGo()
    {
        DialogueSystem.Instance.AddNewText(ClosingLines, Name, Face);
    }
    void ToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    void EndPrep()
    {
        endFinish = true;
    }

    IEnumerator TypeSentence(string sentence)
    {
        foreach (char letter in sentence.ToCharArray())
        {
            textBox.text += letter;
            yield return null;
        }
    }
}
