using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {
	public GameObject MenuCanvas;

	/*
	*Function detects when character has entered the finish line of the map
	*/
	void OnTriggerEnter(Collider col){

		if(col.gameObject.name == "FinishLine"){
			Debug.Log("HI THERE");
			//Application.Quit();
			MenuCanvas.GetComponent<RandomHallwayMenuUI>().OpenTestCompleteMenu();
		}
	}
}
