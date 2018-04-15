using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNavigation : MonoBehaviour {

	public AudioSource north;
	public AudioSource south;

	public GameObject player;

	private float playerDir;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		playerDir = player.transform.eulerAngles.y;


		if (Input.GetKeyDown("p")){
			Debug.Log(playerDir);
			if ((playerDir > 270f && playerDir <= 360f) || (playerDir > 0f && playerDir < 90f)){
				north.Play();
			}
			else if((playerDir < 270f && playerDir > 180f) || (playerDir > 90f && playerDir < 180f)){
				south.Play();
			}
		}

	}
}
