using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDButtons : MonoBehaviour {

    public bool ArrestOn = false;
    public bool InterrogateOn = false;
    public bool LocationsOn = false;

    public GameObject ParentButtons;
    public GameObject hudParent;
    public HUD hudScript;

    public GameObject ArrestUI;
    public GameObject InterrogateUI;
    public GameObject LocationsUI;

    public float invokeTime = .05f;

	// Use this for initialization
	void Start () {
        ParentButtons = this.gameObject.transform.parent.gameObject;
        hudParent = ParentButtons.transform.parent.gameObject;
        hudScript = hudParent.GetComponent<HUD>();

        //ArrestUI = hudScript.Arrest;
        //InterrogateUI = hudScript.Interrogate;
        //LocationsUI = hudScript.Location;

        CancelButton cancelled = ArrestUI.transform.Find("Cancel").gameObject.GetComponent<CancelButton>();
        cancelled.ButtonsObj = ParentButtons;
        cancelled = InterrogateUI.transform.Find("Cancel").gameObject.GetComponent<CancelButton>();
        cancelled.ButtonsObj = ParentButtons;

        ArrestUI.SetActive(false);
        InterrogateUI.SetActive(false);
        LocationsUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (LocationsOn && Input.GetKeyDown(KeyCode.Escape))
        {
            LocationOff();
        }
        
	}

    public void InterrogateButton()
    {
        Debug.Log("int button pressed");
        if (!InterrogateOn)
        {
            if (!ArrestOn)
            {
                InterrogateOn = true;
                Invoke("InterrogateScreenUp", invokeTime);
            }
        }
    }

    public void ArrestButton()
    {
        Debug.Log("arr button pressed");
        if (!ArrestOn)
        {
            if (!InterrogateOn)
            {
                ArrestOn = true;
                Invoke("ArrestScreenUp", invokeTime);
            }
        }
    }

    public void LocationButton()
    {
        if (!LocationsOn)
        {
            
            LocationOn();
        }
        else if (LocationsOn)
        {
            
            LocationOff();
        }
    }

    void ArrestScreenUp()
    {
        ArrestUI.SetActive(true);
        LocationOff();
        ArrestOn = false;
        ParentButtons.SetActive(false);
    }

    void InterrogateScreenUp()
    {
        InterrogateUI.SetActive(true);
        LocationOff();
        InterrogateOn = false;
        ParentButtons.SetActive(false);
    }

    void LocationOn()
    {
        LocationsOn = true;
        LocationsUI.SetActive(true);
    }

    void LocationOff()
    {
        LocationsOn = false;
        LocationsUI.SetActive(false);
    }

}
