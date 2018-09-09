using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundScript : MonoBehaviour {
	GameObject temp;
	private int count;
	private int timer;
	private int level;
	private Vector3 currPos;
	private Vector3 currScale;
	private float blockSpeed;
	public bool gameOver;
	private bool restart;
	private Vector3 endPosText1;
	private Vector3 endPosText2;


	void Start () {
		temp = GameObject.Find ("Template");
		count = 0;
		timer = 0;
		currPos = new Vector3 (-2f, -5f, -2.5f);
		blockSpeed = 0.02f;
		level = 0;
		gameOver = false;
		restart = false;
		endPosText1 = new Vector3 (-3.5f, 1f, -4f);
		endPosText2 = new Vector3 (-1f, -0.6f, -4f);
	}
	
	// Update is called once per frame
	void Update () {

        GameObject[] left = GameObject.FindGameObjectsWithTag("leftBullet");
        GameObject[] right = GameObject.FindGameObjectsWithTag("rightBullet");

        for (int i = 0; i < left.Length; i++)
        {
            //Debug.Log(left[i].transform.position);
            Vector3 temp = left[i].transform.position;
            temp = temp + new Vector3(-0.1f, 0.01f, 0);
            left[i].transform.position = temp;
            //Debug.Log(left[i].transform.position);
            if (left[i].transform.position.y > 10f || left[i].transform.position.x < -10f)
            {

                Destroy(left[i]);
            }
        }

        for (int i = 0; i < right.Length; i++)
        {
            right[i].transform.position += new Vector3(0.1f, 0.01f, 0);
            if (right[i].transform.position.y > 10f || right[i].transform.position.x > 10f)
            {

                Destroy(right[i]);
            }


        }

        //Debug.Log(left[0].transform.position);
		if (timer == 0 && !gameOver) {
			updateCurr ();
			GameObject newStair = Instantiate (temp, currPos, temp.transform.rotation);
			newStair.transform.localScale = currScale;
			newStair.name = "Stair" + count;
			newStair.AddComponent<Blocks> (); 
			newStair.GetComponent<Blocks> ().speed = blockSpeed;
			newStair.tag = "block";
			count++;
			level++;
        }

		if (level == 10) {
			level = 0;
			if (blockSpeed < 2.5f)
				blockSpeed *= 1.2f;
			Debug.Log (blockSpeed);
		}

		timer = (timer + 1) % (int)(2f/ blockSpeed);


		if (gameOver) {
			GameObject.Find ("GameOver").transform.position = endPosText1;
			GameObject.Find ("Restart").transform.position = endPosText2;
			if (Input.GetKeyDown(KeyCode.R) || Input.touchCount > 0){
				SceneManager.LoadScene (SceneManager.GetActiveScene().name);
				Time.timeScale = 1;
			}
		}

    }

	void updateCurr () {
		float randomPos = Random.value * 10 - 5;
		float randomScale = Random.value * 5 + 2;
		currPos = new Vector3 (randomPos, -5f, -2.5f);
		currScale = new Vector3 (randomScale, 0.5f, 1f);
	}

	void EndGame(){
		gameOver = true;
		Time.timeScale = 0;
	}
}
