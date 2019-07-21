using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePerson1 : MonoBehaviour {

    public GameObject ThisPerson;
    public ButtonState DialogueSetting;
    public GameObject InterrogateButtons;
    //public

    public string Name;
    public Sprite Face;


    public int dialogueSequenceNumber;
    public int dialogueSequenceMaximum = 2;
    public bool dialogueStarted;

    public string[] RelationToVictim;
    public string[] Occupation;
    public string[] Alibi;
    public string[] Blame;
    public string[] Blame2;
    public string[] Weapon;
    public string[] Money;

    // Use this for initialization
    void Start () {
        ThisPerson = this.gameObject;
        DialogueSetting = ThisPerson.GetComponent<ButtonState>();
        dialogueSequenceNumber = 1;
	}

    // Update is called once per frame
    void Update()
    {
        if (DialogueSystem.Instance.dialogueBegin && !dialogueStarted && dialogueSequenceNumber < dialogueSequenceMaximum)
        {
            dialogueStarted = true;
            //DialogueSetting.QuestioningState = 0;
        }
        if (dialogueSequenceNumber < dialogueSequenceMaximum && dialogueStarted && !(DialogueSystem.Instance.dialogueBegin))
        {
            dialogueSequenceNumber++;

        }
        else if (dialogueSequenceNumber >= dialogueSequenceMaximum && dialogueStarted && !(DialogueSystem.Instance.dialogueBegin))
        {
            ResetDialogueWindow();
        }

        if (!dialogueStarted)
        { 
            SetDialogueChoices();
        }
	}

    void RelationGo()
    {
        DialogueSystem.Instance.AddNewText(RelationToVictim, Name, Face);
    }
    void OccupationGo()
    {
        DialogueSystem.Instance.AddNewText(Occupation, Name, Face);
    }
    void AlibiGo()
    {
        DialogueSystem.Instance.AddNewText(Alibi, Name, Face);
    }
    void BlameGo()
    {
        int BlameCheck = Random.Range(1, 2);
        if (BlameCheck == 1)
        { 
            DialogueSystem.Instance.AddNewText(Blame, Name, Face);
            if (Game.current.trackingGame.SufEviBlame1 != true)
            {
                Game.current.trackingGame.SufEviBlame1 = true;
                Game.current.trackingGame.SufficientEvidence++;
            }
        }
        else if (BlameCheck == 2)
        {
            DialogueSystem.Instance.AddNewText(Blame2, Name, Face);
        }
    }
    void WeaponGo()
    {
        DialogueSystem.Instance.AddNewText(Weapon, Name, Face);
    }
    void MoneyGo()
    {
        DialogueSystem.Instance.AddNewText(Money, Name, Face);
    }

    void ResetDialogueWindow()
    {
        dialogueStarted = false;
        InterrogateButtons.SetActive(true);
        DialogueSetting.QuestioningState = 0;
        dialogueSequenceNumber = 1;
    }

    void SetDialogueChoices()
    {
        if (DialogueSetting.QuestioningState != 0)
        {
            if (DialogueSetting.QuestioningState == 1)
            {
                RelationGo();
            }
            if (DialogueSetting.QuestioningState == 2)
            {
                OccupationGo();
            }
            if (DialogueSetting.QuestioningState == 3)
            {
                AlibiGo();
            }
            if (DialogueSetting.QuestioningState == 4)
            {
                BlameGo();
            }
            if (DialogueSetting.QuestioningState == 5)
            {
                WeaponGo();
            }
            if (DialogueSetting.QuestioningState == 6)
            {
                MoneyGo();
            }
        }
    }

}
