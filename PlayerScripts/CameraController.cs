using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    GameObject MainCam;
    public GameObject Player;
    public Vector3 HoriMinimum;
    public Vector3 HoriMaximum;


    // Use this for initialization
    void Start () {
        MainCam = this.gameObject;
        Player = GameObject.Find("Player").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        //horizontal camera controls

        if (Player.transform.position.x > HoriMinimum.x && Player.transform.position.x < HoriMaximum.x)
        {
            Vector3 positionToPlayer = transform.position;
            positionToPlayer.x = Player.transform.position.x;
            transform.position = positionToPlayer;
        }
        else if (Player.transform.position.x <= HoriMinimum.x)
        {
            Vector3 positionToHoriMin = transform.position;
            positionToHoriMin.x = HoriMinimum.x;
            MainCam.transform.position = positionToHoriMin;
        }
        else if (Player.transform.position.x >= HoriMaximum.x)
        {
            Vector3 positionToHoriMax = transform.position;
            positionToHoriMax.x = HoriMaximum.x;
            transform.position = positionToHoriMax;
        }

    }
}
