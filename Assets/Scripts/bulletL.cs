using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletL : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(-0.05f, 0, 0);
        if (transform.position.y > 10f)
            Destroy(gameObject);
    }
}
