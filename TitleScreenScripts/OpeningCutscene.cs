using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningCutscene : MonoBehaviour {

    string Name = "";
    public Sprite Face;

    public string[] OpeningLines;

    //public int dialogueSequenceNumber;
    //public int dialogueSequenceMaximum = 2;
    public bool dialogueStarted;

    // Use this for initialization
    void Start () {
        //this script will be added to eventually
        //SceneManager.LoadScene("Outside"); //to be commentted out when actually working on this script.
        dialogueStarted = true;
        DialogueGo();
	}
	
	// Update is called once per frame
	void Update () {
        //if (DialogueSystem.Instance.dialogueBegin && !dialogueStarted && dialogueSequenceNumber < dialogueSequenceMaximum)
        // {
        //   dialogueStarted = true;
        //DialogueSetting.QuestioningState = 0;
        //}
        if (dialogueStarted && !(DialogueSystem.Instance.dialogueBegin))
        {
            //Game.current.Alyzara.GameplayPaused = false;

            SceneManager.LoadScene("FakeLoading");
        }
    }

    public void DialogueGo()
    {
        DialogueSystem.Instance.AddNewText(OpeningLines, Name, Face);
    }
}
