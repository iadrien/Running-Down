using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour {
	public float speed;

	// Use this for initialization
	void Start () {
		if (speed == 0)
			speed = 0.02f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (0, speed, 0);
		if (transform.position.y > 8f) {
			Destroy (gameObject);
			GameObject.Find ("Score").GetComponent<Score> ().Increment ();
		}
	}

	void Freeze(){
		speed = 0f;
	}
}
