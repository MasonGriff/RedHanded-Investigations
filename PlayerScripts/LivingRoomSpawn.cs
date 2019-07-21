using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoomSpawn : MonoBehaviour {

    public Transform pos1, pos2, pos3;
    public GameObject player;

	// Use this for initialization
	void Start () {
		if (Game.current.trackingGame.RoomLastVisited == "Outside" || Game.current.trackingGame.RoomLastVisited == "Interrogate")
        {
            player.transform.position = pos1.position;
        }
        else if (Game.current.trackingGame.RoomLastVisited == "Kitchen")
        {
            player.transform.position = pos2.position;
        }
        else if (Game.current.trackingGame.RoomLastVisited == "Bedroom")
        {
            player.transform.position = pos3.position;
            
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
