using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePerson3 : MonoBehaviour {
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
    public string[] RelationToVictim2;
    public string[] Occupation;
    public string[] Alibi;
    public string[] Alibi2;
    public string[] Alibi3;
    public string[] Blame;
    public string[] Blame2;
    public string[] Weapon;
    public string[] Weapon2;
    public string[] Money;

    // Use this for initialization
    void Start () {
        ThisPerson = this.gameObject;
        DialogueSetting = ThisPerson.GetComponent<ButtonState>();
        dialogueSequenceNumber = 1;
    }
	
	// Update is called once per frame
	void Update () {
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
        if (Game.current.trackingGame.BrotherIsDead == false)
        {
            DialogueSystem.Instance.AddNewText(RelationToVictim, Name, Face);
            Game.current.trackingGame.BrotherIsDead = true;
        }
        else if (Game.current.trackingGame.BrotherIsDead == true)
        {
            DialogueSystem.Instance.AddNewText(RelationToVictim2, Name, Face);
        }
    }
    void OccupationGo()
    {
        DialogueSystem.Instance.AddNewText(Occupation, Name, Face);
    }
    void AlibiGo()
    {
        Game.current.trackingGame.BrothersAlibi = true;
        if(Game.current.trackingGame.FoundWeapon == false && Game.current.trackingGame.BrotherSeesWeapon == false)
        {
            DialogueSystem.Instance.AddNewText(Alibi, Name, Face);
        }
        else if(Game.current.trackingGame.FoundWeapon == true && Game.current.trackingGame.BrotherSeesWeapon == false)
        {
            DialogueSystem.Instance.AddNewText(Alibi2, Name, Face);
        }
        else if (Game.current.trackingGame.FoundWeapon == true && Game.current.trackingGame.BrotherSeesWeapon == true)
        {
            DialogueSystem.Instance.AddNewText(Alibi3, Name, Face);
        }
    }
    void BlameGo()
    {
        int PersonCheck = 0;
        PersonCheck = Random.Range(1, 2);
        DialogueSystem.Instance.AddNewText(Blame, Name, Face);
        if (PersonCheck == 1)
        {
            DialogueSystem.Instance.AddNewText(Blame, Name, Face);
        }
        else if (PersonCheck == 2)
        {
            DialogueSystem.Instance.AddNewText(Blame2, Name, Face);
            if (Game.current.trackingGame.SufEviBlame3 != true)
            {
                Game.current.trackingGame.SufEviBlame3 = true;
                Game.current.trackingGame.SufficientEvidence++;
            }
        }
    }
    void WeaponGo()
    {
        if (Game.current.trackingGame.BrotherSeesWeapon == false)
        {
            DialogueSystem.Instance.AddNewText(Weapon, Name, Face);
            Game.current.trackingGame.BrotherSeesWeapon = true;
        }
        else if (Game.current.trackingGame.BrotherSeesWeapon == true)
        {
            DialogueSystem.Instance.AddNewText(Weapon2, Name, Face);
        }

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
