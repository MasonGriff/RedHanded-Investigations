using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectOnly : MonoBehaviour {

    [Tooltip("This is the object under HUD that is where the buttons reference.")]
    public GameObject ButtonObj;
    [Tooltip("This is the script of the object above.")]
    public InspectAndFingerprints ButtonScript;

    [Tooltip("Denotes what piece of evidence this is by the Int number. The specific IDs are commented in the script. Not to be confused with fingerprint ID or Evidence item ID")]
    public int ItemID;
    //==  ID Numbers  ==
    /* 0: None
     * 1: Bar's Trash Can
     * 2: Wall Dent
     * 3: TV
     * 4: Bike pump
     * 5: 
     * 6:
     * 7:
     * 8:
     * 9:
     */

    [Tooltip("The face icon of the item that displays to the left of the dialogue box.")]
    public Sprite ItemIcon;
    [Tooltip("Name of Item.")]
    public string ItemName;
    [Tooltip("The information that goes to the dialogue box when the player inspects the item")]
    public string[] Inspect;
    [Tooltip("Displays this string instead of the string 'Inspect' when the player has done something that lets them search for new information. Such conditions are taken from the Game Constant bools.")]
    public string[] InspectFurther;

    public int dialogueSequenceNumber;
    public int dialogueSequenceMaximum = 2;
    public bool dialogueStarted;

    [Tooltip("Switches on when Player has OnTriggerEnter2D.")]
    public bool InsideItemsCollider = false;

    [Tooltip("Will be set Automatically on player coming into contact.")]
    public GameObject PlayerObj;
    [Tooltip("Will be set Automatically on player coming into contact.")]
    public PlayerController Player;

    // Use this for initialization
    void Start () {
        dialogueSequenceNumber = 1;
        InsideItemsCollider = false;
        //CheckingPrints = false;
        ButtonObj.SetActive(false);
        //CheckForHudElements();
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
            dialogueStarted = false;
        }

    }

    void ResetDialogueWindow()
    {
        dialogueStarted = false;
        dialogueSequenceNumber = 1;
        ButtonObj.SetActive(true);
        if (Player != null)
        {
            Player.NoteTaking = false;
            Player.SpriteAnim.SetBool("Notations", false);
        }
    }

    public void InspectVoid()
    {
        ButtonObj.SetActive(false);
        Invoke(("Item" + ItemID), 0);
        if (Player != null)
        {
            Player.NoteTaking = true;
            Player.SpriteAnim.SetBool("Notations", true);
            Debug.Log("Anim Go");
        }
    }

    private void OnTriggerEnter2D(Collider2D myColl)
    {
        if (myColl.tag == "Detective")
        {
            ButtonObj.SetActive(true);
            ButtonScript.Items = this;
            InsideItemsCollider = true;
            PlayerObj = myColl.gameObject;
            Player = PlayerObj.GetComponent<PlayerController>();
            if (Player != null)
            {
                Debug.Log("player Set");
            }
        }
        //ButtonScript.InpsectOnlyCheck = true;
    }

    private void OnTriggerExit2D(Collider2D myColl)
    {
        if (myColl.tag == "Detective")
        {
            ButtonObj.SetActive(false);
            ButtonScript.Evidence = null;
            InsideItemsCollider = false;
            PlayerObj = myColl.gameObject;
            Player = PlayerObj.GetComponent<PlayerController>();
        }
    }

    void Item1()
    {
        ItemName = "Trash Can";
        if (Game.current.trackingGame.TrashCanMentioned == false && Game.current.trackingGame.CheckedTrash == false && Game.current.trackingGame.ExaminedBody == false && Game.current.trackingGame.TrashCanMentioned == false)
        {
            DialogueSystem.Instance.AddNewText(Inspect, ItemName, ItemIcon);
            Debug.Log("Bool: Checked Trash not active yet");
        }
        else if (Game.current.trackingGame.TrashCanMentioned && Game.current.trackingGame.CheckedTrash == false || Game.current.trackingGame.ExaminedBody && Game.current.trackingGame.CheckedTrash == false)
        {
            DialogueSystem.Instance.AddNewText(InspectFurther, ItemName, ItemIcon);
            Game.current.trackingGame.CheckedTrash = true;
            Debug.Log("Bool: Checked Trash");
        }
        else if (Game.current.trackingGame.CheckedTrash && Game.current.trackingGame.TrashCanMentioned || Game.current.trackingGame.CheckedTrash && Game.current.trackingGame.ExaminedBody)
        {
            DialogueSystem.Instance.AddNewText(Inspect, ItemName, ItemIcon);
            Debug.Log("Bool: Checked Trash already active");
        }
    }

    void Item2()
    {
        ItemName = "Wall Dent";
        if (!Game.current.trackingGame.ExaminedBody && !Game.current.trackingGame.FoundWeapon)
        {
            DialogueSystem.Instance.AddNewText(Inspect, ItemName, ItemIcon);
        }
        else if(Game.current.trackingGame.ExaminedBody || Game.current.trackingGame.FoundWeapon)
        {
            DialogueSystem.Instance.AddNewText(InspectFurther, ItemName, ItemIcon);
        }
    }

    void Item3()
    {
        ItemName = "Flat-Screen Television";
        DialogueSystem.Instance.AddNewText(Inspect, ItemName, ItemIcon);
    }
    void Item4()
    {
        ItemName = "Bike Pump";
        if (!Game.current.trackingGame.ExaminedBody && !Game.current.trackingGame.FoundWeapon)
        {
            DialogueSystem.Instance.AddNewText(Inspect, ItemName, ItemIcon);
        }
        else if (Game.current.trackingGame.ExaminedBody || Game.current.trackingGame.FoundWeapon)
        {
            DialogueSystem.Instance.AddNewText(InspectFurther, ItemName, ItemIcon);
        }
    }
}
