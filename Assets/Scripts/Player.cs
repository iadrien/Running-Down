using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	Vector3 initPos;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		initPos = transform.position;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
		transform.Translate(1.5f * x, 0, 0);

		if (Input.GetKeyDown(KeyCode.R)) {
			transform.position = initPos;
			rb.velocity = new Vector3(0f,0f,0f); 
			rb.angularVelocity = new Vector3(0f,0f,0f);

		}
	}
}
