using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public GameObject canvasObj;
    
    public Image slot1;
    public Image slot2;
    public Image slot3;

    public GameObject Interrogate;
    public GameObject Arrest;
    public GameObject Location;

    //=== Character Fingerprint Mini-Faces ===
    public Sprite MiniFace00; //Empty fingerprint slot sprite
    public Sprite MiniFace01; //face sprite for 3 fingerprint spots. Same with 2-9
    public Sprite MiniFace02;
    public Sprite MiniFace03;
    public Sprite MiniFace04;
    public Sprite MiniFace05;


    // Use this for initialization
    void Start () {
        canvasObj = this.gameObject;
        slot1 = canvasObj.transform.Find("Fingerprints_1").gameObject.GetComponent<Image>();
        slot2 = canvasObj.transform.Find("Fingerprints_2").gameObject.GetComponent<Image>();
        slot3 = canvasObj.transform.Find("Fingerprints_3").gameObject.GetComponent<Image>();

        Arrest = canvasObj.transform.Find("Arrest").gameObject;
        Interrogate = canvasObj.transform.Find("Interrogate").gameObject;
        Location = canvasObj.transform.Find("Location").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        FingerprintCheck(slot1, Game.current.trackingGame.FingerprintSlot1);
        FingerprintCheck(slot2, Game.current.trackingGame.FingerprintSlot2);
        FingerprintCheck(slot3, Game.current.trackingGame.FingerprintSlot3);
	}


    void FingerprintCheck(Image Slot, int SlotNumber)
    {
        if (SlotNumber == 0)
        {
            Slot.sprite = MiniFace00;
        }
        if (SlotNumber == 1)
        {
            Slot.sprite = MiniFace01;
        }
        if (SlotNumber == 2)
        {
            Slot.sprite = MiniFace02;
        }
        if (SlotNumber == 3)
        {
            Slot.sprite = MiniFace03;
        }
        if (SlotNumber == 4)
        {
            Slot.sprite = MiniFace04;
        }
        if (SlotNumber == 5)
        {
            Slot.sprite = MiniFace05;
        }
    }
}
