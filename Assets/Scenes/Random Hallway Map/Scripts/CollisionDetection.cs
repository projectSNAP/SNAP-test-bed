using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

	public static int totalCollision = 0;

	void OnTriggerEnter(Collider col){

		//Destroy(col.gameObject);
		if(col.gameObject.name == "Cube(Clone)" || col.gameObject.name == "Sphere(Clone)"){
			//Debug.Log("COLLISION");
			//Destroy(col.gameObject);
			totalCollision++;
			Debug.Log("Total collision: ");
			Debug.Log(totalCollision);
		}


	}

}
