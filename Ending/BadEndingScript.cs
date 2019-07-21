using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class BadEndingScript : MonoBehaviour {

    string Name = "";
    public Sprite Face;

    public GameObject endText;

    public float ToCredTransition = 2;

    public string[] ClosingLines;

    //public int dialogueSequenceNumber;  
    //public int dialogueSequenceMaximum = 2;
    public bool dialogueStarted;

    public bool endFinished = false;

    public bool endFinished2 = false;

    private void Awake()
    {
        Vector3 SmalVect = new Vector3 (0, 0, 0);
        endText.transform.localScale = SmalVect;
    }
    // Use this for initialization
    void Start () {
        dialogueStarted = true;
        endFinished = false;
        endFinished2 = false;
        DialogueGo();
	}
	
	// Update is called once per frame
	void Update () {
        if (dialogueStarted && !(DialogueSystem.Instance.dialogueBegin) && endFinished == false)
        {
            //Game.current.Alyzara.GameplayPaused = false;
            endText.SetActive(true);
            endFinished = true;
            endText.transform.DOScale(1, ToCredTransition);
            Invoke("EndPrep", ToCredTransition);
        }
        if(endFinished == true)
        {
            if (endFinished2 == true)
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

    void EndPrep()
    {
        endFinished2 = true;
    }

    void ToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
