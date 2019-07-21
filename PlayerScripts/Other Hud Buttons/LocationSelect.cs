using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationSelect : MonoBehaviour {

    string SceneLoad;
    public string Bedrooms;
    public string Kitchens;
    public string LivingRooms;
    public string Outsides;
    public string LeavingThisLocationName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Bedroom()
    {
        Game.current.trackingGame.GameplayPaused = false;
        SceneLoad = Bedrooms;
        LocationPressed();
    }
    public void Kitchen()
    {
        Game.current.trackingGame.GameplayPaused = false;
        SceneLoad = Kitchens;
        LocationPressed();
    }
    public void LivingRoom()
    {
        Game.current.trackingGame.GameplayPaused = false;
        SceneLoad = LivingRooms;
        Game.current.trackingGame.RoomLastVisited = LeavingThisLocationName;
        LocationPressed();
    }
    public void Outside()
    {
        Game.current.trackingGame.GameplayPaused = false;
        SceneLoad = Outsides;
        LocationPressed();
    }

    void LocationPressed()
    {
        Game.current.trackingGame.GameplayPaused = false;
        Debug.Log("pressed");
        SceneManager.LoadScene(SceneLoad);
    }

}
