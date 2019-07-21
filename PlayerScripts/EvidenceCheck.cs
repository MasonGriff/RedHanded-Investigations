using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvidenceCheck : MonoBehaviour {

    [Tooltip("This is the object under HUD that is where the buttons reference.")]
    public GameObject ButtonObj;
    [Tooltip("This is the script of the object above.")]
    public InspectAndFingerprints ButtonScript;

    [Tooltip("The Dialogue Box.")]
    public Text DialogueBoxLinesObject;
    [Tooltip("The Name Box.")]
    public Text DialogueBoxNamesObject;
    [Tooltip("The Picture Box.")]
    public Image DialogueBoxPictureObject;
    [Tooltip("The empty facebox sprite goes here.")]
    public Sprite DefaultBlankSprite;

    [Tooltip("Denotes what piece of evidence this is by the Int number. The specific IDs are commented in the script. Not to be confused with fingerprint ID or Inspect Only item ID.")]
    public int ItemID;
    //==  ID Numbers  ==
    /* 0: None/Simple Item with no Conditions for further inspection.
     * 1: Victim's corpse
     * 2: Insurance Papers
     * 3: Pipe
     * 4: Baseball Bat
     * 5: Trash Can
     * 6: Wall Dent
     * 7: Bike Pump
     * 8: Kitchen Knife
     * 9: Tool Box
     */

    [Tooltip("If the FP2 and 3 bools are on then it means this item has multiple fingerprint matches.")]
    public bool FP2, FP3;
    [Tooltip("Sets the ID of the character who's fingerprints are on this item. The specific IDs are commented in Game Constants")]
    public int Prints1, Prints2, Prints3;
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

    public bool CheckingPrints = false;

    string FingerprintString = " Fingerprints match.", FingerPrintName = "Fingerprint Scan Results";
    int FingerprintResults;

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
        CheckingPrints = false;
        ButtonObj.SetActive(false);
        CheckForHudElements();
	}
	
	// Update is called once per frame
	void Update () {
        if (CheckingPrints == false)
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
                dialogueStarted = false;
            }
        }
        else if (CheckingPrints)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                ResetFromFingerprintScan();
            }
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

    void ResetFromFingerprintScan()
    {
        DialogueBoxLinesObject.text = "";
        DialogueBoxNamesObject.text = "";
        DialogueBoxPictureObject.sprite = DefaultBlankSprite;
        CheckingPrints = false;
        ButtonObj.SetActive(true);
    }

    void CheckForHudElements()
    {
        GameObject HUD = GameObject.Find("HUD").gameObject;
        GameObject TextGroup = HUD.transform.Find("Text").gameObject;
        DialogueBoxLinesObject = TextGroup.transform.Find("TextBox").gameObject.GetComponent<Text>();
        DialogueBoxNamesObject = TextGroup.transform.Find("Name").gameObject.GetComponent<Text>();
        DialogueBoxPictureObject = TextGroup.transform.Find("Face").gameObject.GetComponent<Image>();
    }

    public void InspectVoid()
    {
        ButtonObj.SetActive(false);
        Invoke(("Item" + ItemID), 0);
        if (Player != null)
        {
            Player.NoteTaking = true;
            Player.SpriteAnim.SetBool("Notations", true);
        }
    }

    public void FingerprintVoid()
    {
        ButtonObj.SetActive(false);
        CheckingPrints = true;
        FingerprintResults = 0;
        if (Prints1 != 0)
        {
            if (Game.current.trackingGame.FingerprintSlot1 == Prints1 || Game.current.trackingGame.FingerprintSlot2 == Prints1 || Game.current.trackingGame.FingerprintSlot3 == Prints1)
            {
                FingerprintResults++;
                if(ItemID == 2)
                {
                    if (Prints1 == 4)
                    {
                        if (Game.current.trackingGame.SufEviInsurancePrints != true)
                        {
                            Game.current.trackingGame.SufEviInsurancePrints = true;
                            Game.current.trackingGame.SufficientEvidence++;
                        }
                    }
                }
                if (ItemID == 3)
                {
                    if (Prints1 == 4)
                    {
                        if (Game.current.trackingGame.SufEviWeaponPrints != true)
                        {
                            Game.current.trackingGame.SufEviWeaponPrints = true;
                            Game.current.trackingGame.SufficientEvidence++;
                        }
                    }
                }
            }
            if (FP2 == true)
            {
                if (Game.current.trackingGame.FingerprintSlot1 == Prints2 || Game.current.trackingGame.FingerprintSlot2 == Prints2 || Game.current.trackingGame.FingerprintSlot3 == Prints2)
                {
                    FingerprintResults++;
                }
            }
            if (FP3 == true)
            {
                if (Game.current.trackingGame.FingerprintSlot1 == Prints3 || Game.current.trackingGame.FingerprintSlot2 == Prints3 || Game.current.trackingGame.FingerprintSlot3 == Prints3)
                {
                    FingerprintResults++;
                }
            }
        }
        DialogueBoxLinesObject.text = (FingerprintResults + FingerprintString);
        DialogueBoxNamesObject.text = FingerPrintName;
        DialogueBoxPictureObject.sprite = ItemIcon;
    }

    private void OnTriggerEnter2D(Collider2D myColl)
    {
        if (myColl.tag == "Detective")
        {
            ButtonObj.SetActive(true);
            ButtonScript.Evidence = this;
            InsideItemsCollider = true;

            PlayerObj = myColl.gameObject;
            Player = PlayerObj.GetComponent<PlayerController>();
        }

        //ButtonScript.InpsectOnlyCheck = false;
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

    void Item0()
    {
        DialogueSystem.Instance.AddNewText(Inspect, ItemName, ItemIcon);
    }

    void Item1() //Victim's Corpse
    {
        //Debug.Log("item 1");
        if (Game.current.trackingGame.InitialInspectBody == false)
        {
            Game.current.trackingGame.InitialInspectBody = true;
            Debug.Log("Bool: Initial Checked Body");
            ItemName = "Victim's Body";
            DialogueSystem.Instance.AddNewText(Inspect, ItemName, ItemIcon);
        }
        else if (Game.current.trackingGame.InitialInspectBody == true && !Game.current.trackingGame.ExaminedBody)
        {
            ItemName = "James Charles";
            Game.current.trackingGame.ExaminedBody = true;
            Debug.Log("Bool: Examined Body");
            DialogueSystem.Instance.AddNewText(InspectFurther, ItemName, ItemIcon);
        }
        else if (Game.current.trackingGame.ExaminedBody == true && Game.current.trackingGame.InitialInspectBody == true)
        {
            ItemName = "James Charles";
            Debug.Log("Bool: Examined Body already active");
            DialogueSystem.Instance.AddNewText(InspectFurther, ItemName, ItemIcon);
        }

    }

    void Item2()
    {
        if(Game.current.trackingGame.SufEviFoundInsurance != true)
        {
            Game.current.trackingGame.SufEviFoundInsurance = true;
            Game.current.trackingGame.SufficientEvidence++;
        }
        if (!Game.current.trackingGame.SearchedWallet)
        {
            Game.current.trackingGame.SearchedWallet = true;
            ItemName = "Misc. Papers";
            DialogueSystem.Instance.AddNewText(Inspect, ItemName, ItemIcon);
        }
        else if (Game.current.trackingGame.SearchedWallet && Game.current.trackingGame.ImportantMentionedMoney < 2)
        {
            ItemName = "Insurance Papers";
            DialogueSystem.Instance.AddNewText(Inspect, ItemName, ItemIcon);
        }
        else if (Game.current.trackingGame.SearchedWallet && Game.current.trackingGame.ImportantMentionedMoney >= 2)
        {
            ItemName = "Insurance Papers";
            DialogueSystem.Instance.AddNewText(InspectFurther, ItemName, ItemIcon);
        }
    }

    void Item3() //pipe, the murder weapon
    {
        if (!Game.current.trackingGame.ExaminedBody)
        //Game.current.trackingGame.FoundWeapon = true;
        {
            ItemName = "Steel Pipe";
            DialogueSystem.Instance.AddNewText(Inspect, ItemName, ItemIcon);
        }
        else if (Game.current.trackingGame.ExaminedBody)
        {
            
            if (!Game.current.trackingGame.FoundWeapon)
            {
                ItemName = "Steel Pipe";
                Game.current.trackingGame.FoundWeapon = true;
                Debug.Log("Bool: Found Weapon");
            }
            else if (Game.current.trackingGame.FoundWeapon)
            {
                ItemName = "Murder Weapon: Steel Pipe";
                Debug.Log("Bool: Found Weapon already active");
            }
            
            DialogueSystem.Instance.AddNewText(InspectFurther, ItemName, ItemIcon);
        }
    }

    void Item4()
    {
        if (!Game.current.trackingGame.ExaminedBody && !Game.current.trackingGame.FoundWeapon)
        {
            DialogueSystem.Instance.AddNewText(Inspect, ItemName, ItemIcon);
        }
        else if (Game.current.trackingGame.ExaminedBody || Game.current.trackingGame.FoundWeapon)
        {
            DialogueSystem.Instance.AddNewText(InspectFurther, ItemName, ItemIcon);
        }
    }

    void Item5()
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

    void Item6()
    {
        ItemName = "Wall Dent";
        if (!Game.current.trackingGame.ExaminedBody && !Game.current.trackingGame.FoundWeapon)
        {
            DialogueSystem.Instance.AddNewText(Inspect, ItemName, ItemIcon);
        }
        else if (Game.current.trackingGame.ExaminedBody || Game.current.trackingGame.FoundWeapon)
        {
            DialogueSystem.Instance.AddNewText(InspectFurther, ItemName, ItemIcon);
        }
    }

    void Item7()
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
    void Item8()
    {
        ItemName = "Kitchen Knife";
        if (!Game.current.trackingGame.ExaminedBody && !Game.current.trackingGame.FoundWeapon)
        {
            DialogueSystem.Instance.AddNewText(Inspect, ItemName, ItemIcon);
        }
        else if (Game.current.trackingGame.ExaminedBody || Game.current.trackingGame.FoundWeapon)
        {
            DialogueSystem.Instance.AddNewText(InspectFurther, ItemName, ItemIcon);
        }
    }
    void Item9()
    {
        ItemName = "ToolBox";
        DialogueSystem.Instance.AddNewText(InspectFurther, ItemName, ItemIcon);
    }
}
