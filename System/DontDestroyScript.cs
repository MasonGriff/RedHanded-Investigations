using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyScript : MonoBehaviour {

    public static DontDestroyScript MusicInstance;

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (MusicInstance == null)
        {
            MusicInstance = this;
            Debug.Log("Background music instance set");
        }
        else
        {
            Debug.Log("destroyed");
            Destroy(this.gameObject);
            return;
        }

    }

    // Update is called once per frame
    void Update () {
		if (Game.current.trackingGame.theEnd == true)
        {
            Destroy(this.gameObject);
        }
	}
}
