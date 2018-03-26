using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

	public static int totalCollision = 0; //Keeps track of total amount of collision
	private static float lastCollisionTime = 0f; //Holds the time of the previous collision
	private const float MAX_COLLISION_INTERVAL = 1f; //Maximum interval to count another collision

	/*
	* Function detects when a character hits an obstacle and increments totalCollisions
	*/
	void OnTriggerEnter(Collider col){

		if(col.gameObject.name == "Cube(Clone)" || col.gameObject.name == "Sphere(Clone)" ||
				col.gameObject.name == "Ground" || col.gameObject.name == "Right Wall" ||
				col.gameObject.name == "Left Wall" || col.gameObject.name == "Back Wall" ||
				col.gameObject.name == "Front Wall"){
			AddToTotalCollisions();
		}

	}

	/*
	*Checks to see if Collisions are separated by MAX_COLLISION_INTERVAL before adding to totalCollision
	*/
	private void AddToTotalCollisions(){
		if(lastCollisionTime == 0.0){
			lastCollisionTime = Time.time;
			totalCollision++;
			return;
		}

		float currTime, netTime;

		currTime = Time.time;
		netTime = currTime - lastCollisionTime;

		if(netTime > MAX_COLLISION_INTERVAL){
			totalCollision++;
		}

		lastCollisionTime = currTime;

	}

	/*
	*Gets the total collisions
	*/
	public int GetTotalCollisions(){
		return totalCollision;
	}
	/*
	*Resets the totalCollision variable
	*/
	public void ResetTotalCollisions(){
		totalCollision = 0;
	}

}
