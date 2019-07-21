using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomSwitchInPerson : MonoBehaviour {

    [Tooltip("The Room this takes you to. Up for room 1, down for 2, E for 3.")]
    public string room1, room2, room3;

    [Tooltip("Does this input method take you to a room.")]
    public bool PressUp, PressDown, PressE = false;

    public bool PlayerCollided = false;

    public string LeavingThisLocationName;

    public GameObject Indicator1, Indicator2, Indicator3;


    // Use this for initialization
    void Start () {
		if (Indicator1 != null)
        {
            Indicator1.SetActive(false);
        }
        if (Indicator2 != null)
        {
            Indicator2.SetActive(false);
        }
        if (Indicator3 != null)
        {
            Indicator3.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        float move = Input.GetAxis("Vertical");
        if (PlayerCollided)
        {
            if (PressUp)
            {
                Indicator1.SetActive(true);
            
            }
            if (PressDown)
            {
                Indicator2.SetActive(true);
            }
            if (PressE)
            {
                Indicator3.SetActive(true);
            }

            if(PressUp && move > 0)
            {
                Game.current.trackingGame.GameplayPaused = false;
                Game.current.trackingGame.RoomLastVisited = LeavingThisLocationName;
                SceneManager.LoadScene(room1);
            }
            else if (PressDown && move < 0)
            {
                Game.current.trackingGame.GameplayPaused = false;
                SceneManager.LoadScene(room2);
            }
            else if(PressE && Input.GetButtonDown("EButton"))
            {
                Game.current.trackingGame.GameplayPaused = false;
                Game.current.trackingGame.RoomLastVisited = LeavingThisLocationName;
                SceneManager.LoadScene(room3);
            }
        }
	}
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Detective")
        {
            PlayerCollided = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Detective")
        {
            PlayerCollided = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Detective")
        {
            PlayerCollided = false;
            if (Indicator1 != null)
            {
                Indicator1.SetActive(false);
            }
            if (Indicator2 != null)
            {
                Indicator2.SetActive(false);
            }
            if (Indicator3 != null)
            {
                Indicator3.SetActive(false);
            }
        }

    }



    public void ButtonPressedVersion()
    {
        Game.current.trackingGame.GameplayPaused = false;
        Game.current.trackingGame.RoomLastVisited = LeavingThisLocationName;
        SceneManager.LoadScene(room1);
    }

}
