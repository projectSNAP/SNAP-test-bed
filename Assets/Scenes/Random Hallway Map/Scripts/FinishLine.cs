using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour {

	public float totalTime;
	private float startTime;


	/*
	*Function detects when character has entered the finish line of the map
	*/
	void OnTriggerEnter(Collider col){

		if(col.gameObject.name == "FinishLine"){
			totalTime = Time.time;

			Debug.Log("TIME");
			Debug.Log(totalTime);
			Application.Quit();

		}
	}
}
