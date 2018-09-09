using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
	public int speed;
	TextMesh tm;
	int score;
	int timer;

	// Use this for initialization
	void Start () {
		tm = GetComponent<TextMesh> ();
		speed = 70;
		score = 0;
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (timer == 0) {
			tm.text = "Score: " + score;
			Increment ();
		}
		timer = (timer + 1) % speed;
		//Debug.Log (timer);
		*/
	}

	public void Increment(){
		tm.text = "Score: " + score;
		score++;
	}


}
