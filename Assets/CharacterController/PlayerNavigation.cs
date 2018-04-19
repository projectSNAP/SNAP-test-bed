using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNavigation : MonoBehaviour {


	////Private Variables
	public AudioClip north;
	public AudioClip south;
	public AudioClip east;
	public AudioClip west;
	public AudioClip ne;
	public AudioClip nw;
	public AudioClip se;
	public AudioClip sw;

	public GameObject player;

	public AudioSource audio;

	////Private Variables
	private float playerDir;


	/////Private Constant Variables
	private const float northLowDeg = 330f;
	private const float northHighDeg = 30f;
	private const float neLowDeg = 30f;
	private const float neHighDeg = 60f;
	private const float eastLowDeg = 60f;
	private const float eastHighDeg = 120f;
	private const float seLowDeg = 120f;
	private const float seHighDeg = 150f;
	private const float southLowDeg = 150f;
	private const float southHighDeg = 210f;
	private const float swLowDeg = 210f;
	private const float swHighDeg = 240f;
	private const float westLowDeg = 240f;
	private const float westHighDeg = 300f;
	private const float nwLowDeg = 300f;
	private const float nwHighDeg = 330f;

	void Start () {


	}

	/*
	* Called once per frame, and reassigns the player's directions
	* Also checks to see if 'p' is pressed in order to play their direction
	*/
	void Update () {
		playerDir = player.transform.eulerAngles.y;


		if (Input.GetKeyDown("p")){
			PlayPlayerDirection();
		}

	}

	/*
	*Checks the direction of the player and plays the respective audio clip
	*/
	private void PlayPlayerDirection(){
		if(playerDir > northLowDeg && playerDir < 360f || playerDir > 0f && playerDir < northHighDeg){
			audio.PlayOneShot(north);
		}
		else if(playerDir > neLowDeg && playerDir < neHighDeg){
			audio.PlayOneShot(ne);
		}
		else if(playerDir > eastLowDeg && playerDir < eastHighDeg){
			audio.PlayOneShot(east);
		}
		else if(playerDir > seLowDeg && playerDir < seHighDeg){
			audio.PlayOneShot(se);
		}
		else if(playerDir > southLowDeg && playerDir < southHighDeg){
			audio.PlayOneShot(south);
		}
		else if(playerDir > swLowDeg && playerDir < swHighDeg){
			audio.PlayOneShot(sw);
		}
		else if(playerDir > westLowDeg && playerDir < westHighDeg){
			audio.PlayOneShot(west);
		}
		else if(playerDir > nwLowDeg && playerDir < nwHighDeg){
			audio.PlayOneShot(nw);
		}
	}
}
