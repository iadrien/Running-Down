using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAM_DOM : MonoBehaviour {

    private List<GameObject> planes;
    // Use this for initialization
    void Start () {
		for (int i = 1; ; i++)
        {
            string planeName = "P" + i;
            GameObject plane = GameObject.Find(planeName);
            if (plane != null)
            {
                break;
            }
            else
            {
                planes.Add(plane);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
