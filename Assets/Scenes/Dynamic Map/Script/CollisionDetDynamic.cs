using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CollisionDetDynamic : MonoBehaviour {

	public static int totalCollision = 0; //Keeps track of total amount of collision

	/*
	* Function detects when a character hits an obstacle and increments totalCollisions
	*/
	void OnTriggerEnter(Collider col){
		/*
		if(col.gameObject.name == "Cube 1(Clone)" || col.gameObject.name == "Sphere 1(Clone)" ||
				col.gameObject.name == "Ground" || col.gameObject.name == "Right Wall" ||
				col.gameObject.name == "Left Wall" || col.gameObject.name == "Back Wall" ||
				col.gameObject.name == "Front Wall" || col.gameObject.name == "Wanderer" ||
				col.gameObject.name == "Wanderer (1)" || col.gameObject.name == "Wanderer (2)" ||
				col.gameObject.name == "Wanderer (3)" || col.gameObject.name == "Wanderer (4)" ||
				col.gameObject.name == "Wanderer (5)" || col.gameObject.name == "Wanderer (6)" ||
				col.gameObject.name == "Wanderer (7)" || col.gameObject.name == "Wanderer (8)" ){
				*/
		if(col.gameObject.tag == "Collidable"){
			totalCollision++;
			Debug.Log(col.gameObject.name + ": " + totalCollision);
		}
	}

	public int GetTotalCollisions(){
		return totalCollision;
	}

}
