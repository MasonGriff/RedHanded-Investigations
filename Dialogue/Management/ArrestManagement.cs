using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArrestManagement : MonoBehaviour {


    public Image PortraitBox;


    public Sprite Per1, Per2, Per3, Per4, Per5;

    public string Name;
    public Sprite Face;
    public int dialogueSequenceNumber;
    public int dialogueSequenceMaximum = 2;
    public bool dialogueStarted;
    public bool dialogueFinished;

    public bool CorrectArrest;

    public string[] WrongPersonDialogue;
    public string[] CorrectPerson, PrintsOnWeapon, Alibi, Weapon, Money, FoundInsurance, PrintsOnInsurance, blame1, blame2, blame3, UnderArrest;


    public Sprite p1, p2, p3, p4, p5;
    public string NameSuspect;
    public Sprite FaceSuspect;
    public string[] Denial;
    public string[] confession;

    public bool suspectResponds = false;
    // Use this for initialization 
    private void Awake() 
    {
        dialogueSequenceNumber = 1;
        CorrectArrest = false;
        dialogueStarted = false;
        dialogueFinished = false;
        if (Game.current.trackingGame.CurrentInterrogate == 1)
        {
            PortraitBox.sprite = Per1;
            FaceSuspect = p1;
            NameSuspect = "Mike Griffin";
        }
        else if (Game.current.trackingGame.CurrentInterrogate == 2)
        {
            PortraitBox.sprite = Per2;
            FaceSuspect = p2;
            NameSuspect = "John Riley";
        }
        else if (Game.current.trackingGame.CurrentInterrogate == 3)
        {
            PortraitBox.sprite = Per3;
            FaceSuspect = p3;
            NameSuspect = "Mack Charles";
        }
        else if (Game.current.trackingGame.CurrentInterrogate == 4)
        {
            PortraitBox.sprite = Per4;
            FaceSuspect = p4;
            NameSuspect = "Mary Charles";
        }
        else if (Game.current.trackingGame.CurrentInterrogate == 5)
        {
            PortraitBox.sprite = Per5;
            FaceSuspect = p5;
            NameSuspect = "Kasandra Babiuch";
        }
    }

    void Start () {
		if (Game.current.trackingGame.CurrentInterrogate != 4 || Game.current.trackingGame.SufficientEvidence < 5)
        {
            CorrectArrest = false;
            dialogueSequenceMaximum = 2;
            DialogueGoFalse();
        }
        else if (Game.current.trackingGame.CurrentInterrogate == 4 && Game.current.trackingGame.SufficientEvidence >= 5)
        {
            CorrectArrest = true;
            dialogueSequenceMaximum = 12;
            DialogueGoCorrect();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (CorrectArrest == true)
        {
            if (dialogueFinished == false)
            {
                if (DialogueSystem.Instance.dialogueBegin && !dialogueStarted && dialogueSequenceNumber < dialogueSequenceMaximum)
                {
                    dialogueStarted = true;
                }

                if (dialogueSequenceNumber < dialogueSequenceMaximum && dialogueStarted && !(DialogueSystem.Instance.dialogueBegin))
                {
                    dialogueSequenceNumber++;
                    if (dialogueSequenceNumber == 2)
                    {
                        //DialogueSystem.Instance.AddNewDialogue(Dialogue02, charName2);
                        if (Game.current.trackingGame.SufEviWeaponPrints == true)
                        {
                            DialogueSystem.Instance.AddNewText(PrintsOnWeapon, Name, Face);
                        }
                        else
                        {
                            dialogueSequenceNumber++;
                        }
                    }
                    else if (dialogueSequenceNumber == 3)
                    {
                        if (Game.current.trackingGame.SufEviWifeLiedAlibi == true)
                        {
                            DialogueSystem.Instance.AddNewText(Alibi, Name, Face);
                        }
                        else
                        {
                            dialogueSequenceNumber++;
                        }
                    }
                    else if (dialogueSequenceNumber == 4)
                    {
                        if (Game.current.trackingGame.SufEviWifeLiedWeapon == true)
                        {
                            DialogueSystem.Instance.AddNewText(Weapon, Name, Face);
                        }
                        else
                        {
                            dialogueSequenceNumber++;
                        }
                    }
                    else if (dialogueSequenceNumber == 5)
                    {
                        if (Game.current.trackingGame.SufEviWifeLiedMoney == true)
                        {
                            DialogueSystem.Instance.AddNewText(Money, Name, Face);
                        }
                        else
                        {
                            dialogueSequenceNumber++;
                        }
                    }
                    else if (dialogueSequenceNumber == 6)
                    {
                        if (Game.current.trackingGame.SufEviFoundInsurance == true)
                        {
                            DialogueSystem.Instance.AddNewText(FoundInsurance, Name, Face);
                        }
                        else
                        {
                            dialogueSequenceNumber++;
                        }
                    }
                    else if (dialogueSequenceNumber == 7)
                    {
                        if (Game.current.trackingGame.SufEviInsurancePrints == true)
                        {
                            DialogueSystem.Instance.AddNewText(PrintsOnInsurance, Name, Face);
                        }
                        else
                        {
                            dialogueSequenceNumber++;
                        }
                    }
                    else if (dialogueSequenceNumber == 8)
                    {
                        if (Game.current.trackingGame.SufEviBlame1 == true)
                        {
                            DialogueSystem.Instance.AddNewText(blame1, Name, Face);
                        }
                        else
                        {
                            dialogueSequenceNumber++;
                        }
                    }
                    else if (dialogueSequenceNumber == 9)
                    {
                        if (Game.current.trackingGame.SufEviBlame3 == true)
                        {
                            DialogueSystem.Instance.AddNewText(blame2, Name, Face);
                        }
                        else
                        {
                            dialogueSequenceNumber++;
                        }
                    }
                    else if (dialogueSequenceNumber == 10)
                    {
                        if (Game.current.trackingGame.SufEviBlame5 == true)
                        {
                            DialogueSystem.Instance.AddNewText(blame3, Name, Face);
                        }
                        else
                        {
                            dialogueSequenceNumber++;
                        }
                    }
                    else if (dialogueSequenceNumber == 11)
                    {
                        DialogueSystem.Instance.AddNewText(UnderArrest, Name, Face);
                    }
                }
                else if (dialogueSequenceNumber >= dialogueSequenceMaximum && dialogueStarted && !(DialogueSystem.Instance.dialogueBegin))
                {
                    dialogueStarted = false;
                    dialogueFinished = true;
                    dialogueSequenceNumber = 1;
                    dialogueSequenceMaximum = 2;
                    DialogueSystem.Instance.AddNewText(confession, NameSuspect, FaceSuspect);
                    dialogueStarted = true;
                    //Game.current.Alyzara.GameplayPaused = false;
                    //IntroStageGM.GMInstance.Dialogue01 = true;
                }
            }
            else if (dialogueFinished == true)
            {
                if (dialogueStarted && !(DialogueSystem.Instance.dialogueBegin))
                {
                    //Game.current.Alyzara.GameplayPaused = false;

                    SceneManager.LoadScene("GoodEnding");
                }
            }
        }
        else if (CorrectArrest == false)
        {
            if (suspectResponds == false)
            {
                if (dialogueStarted && !(DialogueSystem.Instance.dialogueBegin))
                {
                    //Game.current.Alyzara.GameplayPaused = false;
                    DialogueSystem.Instance.AddNewText(Denial, NameSuspect, FaceSuspect);
                    dialogueStarted = true;
                    suspectResponds = true;

                }
            }
            else if (suspectResponds == true)
            {
                if (dialogueStarted && !(DialogueSystem.Instance.dialogueBegin))
                {
                    //Game.current.Alyzara.GameplayPaused = false;

                    SceneManager.LoadScene("BadEnding");
                }
            }
        }
    }


    void DialogueGoCorrect()
    {
        DialogueSystem.Instance.AddNewText(CorrectPerson, Name, Face);
        dialogueStarted = true;
    }
    void DialogueGoFalse()
    {
        DialogueSystem.Instance.AddNewText(WrongPersonDialogue, Name, Face);
        dialogueStarted = true;
    }

}
