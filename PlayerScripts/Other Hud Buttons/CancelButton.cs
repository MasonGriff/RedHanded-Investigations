using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelButton : MonoBehaviour {

    public GameObject cancelButton;
    public GameObject parentObj;
    public GameObject ButtonsObj;

	// Use this for initialization
	void Start () {
        cancelButton = this.gameObject;
        parentObj = cancelButton.transform.parent.gameObject;
        //ButtonsObj = parentObj.transform.Find("Buttons").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CancelButtonPressed();
        }	
	}


    public void CancelButtonPressed()
    {
        Debug.Log("Cancel Pressed");

        ButtonsObj.SetActive(true);
        parentObj.SetActive(false);
    }

}
