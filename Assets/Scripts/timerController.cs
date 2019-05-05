using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerController : MonoBehaviour {


    public Text txtTimeLeft;
    public float timeLeft = 30.0f;
	// Use this for initialization
	void Start () {
		
	}
    

    // Update is called once per frame
    void Update () {
        timeLeft -= Time.deltaTime;
        txtTimeLeft.text = "You got " + Mathf.Floor(timeLeft) + " s left";
        if (timeLeft <= 0)
        {
            gameObject.GetComponent<Fading>().resetCurrentScene();
        }
	}
}
