using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class credits : MonoBehaviour {

    public GameObject CreditRoll;
    public Transform endPoint;

    public float timeLimit = 30f;
    float timeLimit2;

	// Use this for initialization
	void Start () {
        //to be commented out later
        // Game.current.trackingGame.theEnd = true;
        //SceneManager.LoadScene("FakeLoading");
        //to be commented out later
        timeLimit2 = timeLimit;
        CreditRoll.transform.DOMoveY(endPoint.position.y, timeLimit);
    }

    // Update is called once per frame
    void Update () {
        timeLimit2 -= Time.deltaTime;

        if (CreditRoll.transform.position.y == endPoint.position.y || timeLimit2 <= 0)
        {
            //Game.current = new Game();
            Game.current.trackingGame.LoadingOpening = 2;
            Game.current.trackingGame.theEnd = true;
            SceneManager.LoadScene("FakeLoading");

        }
	}
}
