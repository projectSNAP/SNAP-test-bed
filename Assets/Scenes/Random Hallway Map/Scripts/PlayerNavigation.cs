using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNavigation : MonoBehaviour {


	////Public Variables
	public AudioSource north;
	public AudioSource south;
	public AudioSource east;
	public AudioSource west;
	public AudioSource ne;
	public AudioSource nw;
	public AudioSource se;
	public AudioSource sw;

	public GameObject player;


	/////Private Variables
	private float playerDir;


	/////Private Constant Variables
	private static const float northLowDeg = 330f;
	private static const float northHighDeg = 30f;
	private static const float neLowDeg = 30f;
	private static const float neHighDeg = 60f;
	private static const float eastLowDeg = 60f;
	private static const float eastHighDeg = 120f;
	private static const float seLowDeg = 120f;
	private static const float seHighDeg = 150f;
	private static const float southLowDeg = 150f;
	private static const float southHighDeg = 210f;
	private static const float swLowDeg = 210f;
	private static const float swHighDeg = 240f;
	private static const float westLowDeg = 240f;
	private static const float westHighDeg = 300f;
	private static const float nwLowDeg = 300f;
	private static const float nwHighDeg = 330f;

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
