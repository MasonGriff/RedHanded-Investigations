using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForGameCurrent : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		if(Game.current == null)
        {
            Game.current = new Game();
            Debug.Log("Game.current set");
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
	
}
