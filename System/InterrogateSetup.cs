using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterrogateSetup : MonoBehaviour {

    public Image Portrait;
    //SpriteRenderer Portait;

    public Sprite Per1;
    public Sprite Per2;
    public Sprite Per3;
    public Sprite Per4;
    public Sprite Per5;

    public GameObject Obj1;
    public GameObject Obj2;
    public GameObject Obj3;
    public GameObject Obj4;
    public GameObject Obj5;


    // Use this for initialization
    void Start () {
        //Portait = PortraitObj.GetComponent<SpriteRenderer>();

        FingerPrintCheckSlots(Game.current.trackingGame.CurrentInterrogate);

        if(Game.current.trackingGame.CurrentInterrogate == 1)
        {
            Portrait.sprite = Per1;
            Obj1.SetActive(true);
            if(Game.current.trackingGame.Person1TalktedTo == false)
            {
                Game.current.trackingGame.Person1TalktedTo = true;
                Game.current.trackingGame.PeopleTalkedTo++;
            }
        }
        else if (Game.current.trackingGame.CurrentInterrogate == 2)
        {
            Portrait.sprite = Per2;
            Obj2.SetActive(true);
            if (Game.current.trackingGame.Person2TalktedTo == false)
            {
                Game.current.trackingGame.Person2TalktedTo = true;
                Game.current.trackingGame.PeopleTalkedTo++;
            }
        }
        else if (Game.current.trackingGame.CurrentInterrogate == 3)
        {
            Portrait.sprite = Per3;
            Obj3.SetActive(true);
            if (Game.current.trackingGame.Person3TalktedTo == false)
            {
                Game.current.trackingGame.Person3TalktedTo = true;
                Game.current.trackingGame.PeopleTalkedTo++;
            }
        }
        else if (Game.current.trackingGame.CurrentInterrogate == 4)
        {
            Portrait.sprite = Per4;
            Obj4.SetActive(true);
            if (Game.current.trackingGame.Person4TalktedTo == false)
            {
                Game.current.trackingGame.Person4TalktedTo = true;
                Game.current.trackingGame.PeopleTalkedTo++;
            }
        }
        else if (Game.current.trackingGame.CurrentInterrogate == 5)
        {
            Portrait.sprite = Per5;
            Obj5.SetActive(true);
            if (Game.current.trackingGame.Person5TalktedTo == false)
            {
                Game.current.trackingGame.Person5TalktedTo = true;
                Game.current.trackingGame.PeopleTalkedTo++;
            }
        }

        

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void FingerPrintCheckSlots(int Person)
    {
        if (Game.current.trackingGame.FingerprintSlot1 != Person && Game.current.trackingGame.FingerprintSlot2 != Person && Game.current.trackingGame.FingerprintSlot3 != Person)
        {
            if (Game.current.trackingGame.FingerprintSlotToUpdateNext == 1)
            {
                Game.current.trackingGame.FingerprintSlot1 = Person;
                Game.current.trackingGame.FingerprintSlotToUpdateNext = 2;
            }
            else if (Game.current.trackingGame.FingerprintSlotToUpdateNext == 2)
            {
                Game.current.trackingGame.FingerprintSlot2 = Person;
                Game.current.trackingGame.FingerprintSlotToUpdateNext = 3;
            }
            else if (Game.current.trackingGame.FingerprintSlotToUpdateNext == 3)
            {
                Game.current.trackingGame.FingerprintSlot3 = Person;
                Game.current.trackingGame.FingerprintSlotToUpdateNext = 1;
            }
        }
    }

}
