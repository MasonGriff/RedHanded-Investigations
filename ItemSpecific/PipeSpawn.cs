using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour {

    public GameObject PipeObj;

	// Use this for initialization
	void Start () {
        if (!Game.current.trackingGame.CheckedTrash)
        {
            PipeObj.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Game.current.trackingGame.CheckedTrash)
        {
            PipeObj.SetActive(true);
        }
        else if (!Game.current.trackingGame.CheckedTrash)
        {
            PipeObj.SetActive(false);
        }
    }
}
