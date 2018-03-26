using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

	public static int totalCollision = 0; //Keeps track of total amount of collision

	/*
	* Function detects when a character hits an obstacle and increments totalCollisions
	*/
	void OnTriggerEnter(Collider col){

		if(col.gameObject.name == "Cube(Clone)" || col.gameObject.name == "Sphere(Clone)" ||
				col.gameObject.name == "Ground" || col.gameObject.name == "Right Wall" ||
				col.gameObject.name == "Left Wall" || col.gameObject.name == "Back Wall" ||
				col.gameObject.name == "Front Wall"){
			totalCollision++;
			Debug.Log(totalCollision);
		}

		/*
		if (col.gameObject.tag == "Collidable") {
			totalCollision++;
			Debug.Log (totalCollision);
		}
		*/
	}

	public int GetTotalCollisions(){
		return totalCollision;
	}

	public void ResetTotalCollisions(){
		totalCollision = 0;
	}

}
