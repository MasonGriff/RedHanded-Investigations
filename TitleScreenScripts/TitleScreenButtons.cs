using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleScreenButtons : MonoBehaviour {

    public float ButtonHitDelay = 0.1f;

	// Use this for initialization
	void Start () {
        //Screen.SetResolution(427, 240, false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewGameButton()
    {
        Invoke("ToNewGame", ButtonHitDelay);
    }

    public void QuitGameButton()
    {
        Invoke("ToQuit", ButtonHitDelay);
    }

    public void ControlsButton()
    {
        Debug.Log("Controls Menu Opened");
        SceneManager.LoadScene("Controls");
    }

    void ToNewGame()
    {
        Debug.Log("New Game Start");
        Game.current = new Game();
        SceneManager.LoadScene("FakeLoading");
    }

    void ToQuit()
    {
        Debug.Log("quitting");
        Application.Quit();
    }
}
