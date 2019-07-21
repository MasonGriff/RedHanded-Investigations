using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InterrogateSelections : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string Name;
    public Text NamePlate;
    public string SceneName;
    public static bool Pressed;
    public int PersonIdentityNumber;

	// Use this for initialization
	void Start () {
        NamePlate = this.gameObject.transform.parent.gameObject.transform.Find("ButtonName").gameObject.GetComponent<Text>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        NamePlate.text = Name;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        NamePlate.text = "";
    }

    public void PersonPressed()
    {
        if (!Pressed)
        {
            Pressed = true;
            SceneName = "Interrogate";
            Invoke("TransitionToScene", 0.05f);
        }
    }

    public void PersonArrested()
    {
        if (!Pressed)
        {
            Pressed = true;
            SceneName = "Arrest";
            Invoke("TransitionToScene", 0.05f);
        }
    }

    void TransitionToScene()
    {
        Pressed = false;
        Debug.Log("To Interrogation Scene!!!");
        Game.current.trackingGame.CurrentInterrogate = PersonIdentityNumber;
        Debug.Log("" + Game.current.trackingGame.CurrentInterrogate + "is arrest");
        SceneManager.LoadScene(SceneName); //Uncomment when scenes are made.
    }

}
