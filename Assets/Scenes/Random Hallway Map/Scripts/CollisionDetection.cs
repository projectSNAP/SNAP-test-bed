using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

	public static int totalCollision = 0; //Keeps track of total amount of collision

	/*
	* Function detects when a character hits an obstacle and increments totalCollisions
	*/
	void OnTriggerEnter(Collider col){

		if(col.gameObject.name == "Cube(Clone)" || col.gameObject.name == "Sphere(Clone)"){
			totalCollision++;
			Debug.Log(totalCollision);
		}
	}

}
