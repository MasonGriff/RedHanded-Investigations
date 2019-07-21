using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterrogationQuestionButtons : MonoBehaviour {
    public GameObject InterroButtonList;
    public GameObject BlameButtonUI;
    public GameObject WeaponButtonUI;
    public GameObject MoneyButtonUI;

    public GameObject InterrogationPersonList;
    InterrogateSetup IPLScript;

    public GameObject CurrentPerson;
    ButtonState PersonSettingScript;

    // Use this for initialization
    void Start () {
        CheckNewQuestionsAvailable();
        IPLScript = InterrogationPersonList.GetComponent<InterrogateSetup>();
        SetCurrentInterrogate(Game.current.trackingGame.CurrentInterrogate);
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    void CheckNewQuestionsAvailable()
    {
        if (Game.current.trackingGame.PeopleTalkedTo != 5)
        {
            BlameButtonUI.SetActive(false);
        }
        if (Game.current.trackingGame.FoundWeapon == false)
        {
            WeaponButtonUI.SetActive(false);
        }
        if (Game.current.trackingGame.SearchedWallet == false)
        {
            MoneyButtonUI.SetActive(false);
        }
    }

    void SetCurrentInterrogate(int Person)
    {
        if (Person == 1)
        {
            CurrentPerson = IPLScript.Obj1;
        }
        else if (Person == 2)
        {
            CurrentPerson = IPLScript.Obj2;
        }
        else if (Person == 3)
        {
            CurrentPerson = IPLScript.Obj3;
        }
        else if (Person == 4)
        {
            CurrentPerson = IPLScript.Obj4;
        }
        else if (Person == 5)
        {
            CurrentPerson = IPLScript.Obj5;
        }
        PersonSettingScript = CurrentPerson.GetComponent<ButtonState>();
    }

    public void RelationshipButton()
    {
        PersonSettingScript.QuestioningState = 1;
        InterroButtonList.SetActive(false);
    }
    public void OccupationButton()
    {
        PersonSettingScript.QuestioningState = 2;
        InterroButtonList.SetActive(false);
    }
    public void AlibiButton()
    {
        PersonSettingScript.QuestioningState = 3;
        InterroButtonList.SetActive(false);
    }
    public void BlameButton()
    {
        PersonSettingScript.QuestioningState = 4;
        InterroButtonList.SetActive(false);
    }
    public void WeaponButton()
    {
        PersonSettingScript.QuestioningState = 5;
        InterroButtonList.SetActive(false);
    }
    public void MoneyButton()
    {
        PersonSettingScript.QuestioningState = 6;
        InterroButtonList.SetActive(false);
    }




}
