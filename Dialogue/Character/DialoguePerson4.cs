using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePerson4 : MonoBehaviour {
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
    public string[] Alibi2;
    public string[] Alibi3;
    [Tooltip("Blame Mike")]
    public string[] Blame;
    [Tooltip("Blame Riley")]
    public string[] Blame2;
    [Tooltip("Blame Brother")]
    public string[] Blame3;
    [Tooltip("Blame Kasie")]
    public string[] Blame4;
    [Tooltip("Blame her husband")]
    public string[] BlameVictim;
    public string[] Weapon;
    public string[] Weapon2;
    public string[] Money;
    public string[] Money2;
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
        DialogueSystem.Instance.AddNewText(RelationToVictim, Name, Face);
    }
    void OccupationGo()
    {
        DialogueSystem.Instance.AddNewText(Occupation, Name, Face);
    }
    void AlibiGo()
    {
        Debug.Log("alibi");
        if (Game.current.trackingGame.WifesFirstAlibi == false || Game.current.trackingGame.BrothersAlibi == false && Game.current.trackingGame.WifesFirstAlibi == true)
        {
            DialogueSystem.Instance.AddNewText(Alibi, Name, Face);
            Game.current.trackingGame.WifesFirstAlibi = true;
            Debug.Log("first");
        }
        else if (Game.current.trackingGame.BrothersAlibi == true && Game.current.trackingGame.WifesFirstAlibi == true && Game.current.trackingGame.WifesSecondAlibi == false)
        {
            DialogueSystem.Instance.AddNewText(Alibi2, Name, Face);
            Game.current.trackingGame.WifesSecondAlibi = true;
            if (Game.current.trackingGame.SufEviWifeLiedAlibi != true)
            {
                Game.current.trackingGame.SufEviWifeLiedAlibi = true;
                Game.current.trackingGame.SufficientEvidence++;
                Debug.Log("2nd");
            }
        }
        else if (Game.current.trackingGame.BrothersAlibi == true && Game.current.trackingGame.WifesSecondAlibi == true)
        {
            DialogueSystem.Instance.AddNewText(Alibi3, Name, Face);
            Debug.Log("3rd");
        }
    }
    void BlameGo()
    {
        int BlameAnyone = 0;
        BlameAnyone = Random.Range(1, 5);
        if (BlameAnyone == 1)
        {
            DialogueSystem.Instance.AddNewText(Blame, Name, Face);
        }
        else if (BlameAnyone == 2)
        {
            DialogueSystem.Instance.AddNewText(Blame2, Name, Face);
        }
        else if (BlameAnyone == 3)
        {
            DialogueSystem.Instance.AddNewText(Blame3, Name, Face);
        }
        else if (BlameAnyone == 4)
        {
            DialogueSystem.Instance.AddNewText(Blame4, Name, Face);
        }
        else if (BlameAnyone == 5 && Game.current.trackingGame.ExaminedBody == false)
        {
            DialogueSystem.Instance.AddNewText(BlameVictim, Name, Face);
        }
        else if (BlameAnyone == 5 && Game.current.trackingGame.ExaminedBody == true)
        {
            DialogueSystem.Instance.AddNewText(Blame2, Name, Face);
        }
    }
    void WeaponGo()
    {
        if (Game.current.trackingGame.WeaponPrintsMatched == false)
        {
            DialogueSystem.Instance.AddNewText(Weapon, Name, Face);
        }
        else if (Game.current.trackingGame.WeaponPrintsMatched == true)
        {
            DialogueSystem.Instance.AddNewText(Weapon2, Name, Face);
            if (Game.current.trackingGame.SufEviWifeLiedWeapon != true)
            {
                Game.current.trackingGame.SufEviWifeLiedWeapon = true;
                Game.current.trackingGame.SufficientEvidence++;
            }
        }
    }
    void MoneyGo()
    {
        
        if (Game.current.trackingGame.WifeMentionedMoney == false || Game.current.trackingGame.WifeMentionedMoney == true && Game.current.trackingGame.AccountantMentionedMoney == false)
        {
            DialogueSystem.Instance.AddNewText(Money, Name, Face);
            Game.current.trackingGame.WifeMentionedMoney = true;
            Game.current.trackingGame.ImportantMentionedMoney++;
        }

        else if (Game.current.trackingGame.WifeMentionedMoney == true && Game.current.trackingGame.ImportantMentionedMoney >= 2)
        {
            DialogueSystem.Instance.AddNewText(Money2, Name, Face);
            if (Game.current.trackingGame.SufEviWifeLiedMoney != true)
            {
                Game.current.trackingGame.SufEviWifeLiedMoney = true;
                Game.current.trackingGame.SufficientEvidence++;
            }
        }
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
