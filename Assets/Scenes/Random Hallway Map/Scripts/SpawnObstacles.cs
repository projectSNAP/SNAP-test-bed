using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour {


	public GameObject cubePrefab;
	public GameObject spherePrefab;


	public Vector3 center;
	public Vector3 size;



	// Use this for initialization
	void Start () {
		int numCubes = 50; //Number of cubes spawned
		int numSpheres = 50; //Number of spheres spawned


		/*Generate Cubes*/
		for(int i = 0; i < numCubes; i++){
			SpawnSquareRandObstacles();
		}

		/*Generate Spheres*/
		for(int i = 0; i < numSpheres; i++){
			SpawnSphereRandObstacles();
		}


	}

	// Update is called once per frame
	void Update () {

	}

	/*
	* Function spawns a sphere of a random size and random position onto the map
	*/
	public void SpawnSphereRandObstacles(){
		int xSize, ySize, zSize; //Holds the scale sizes of each dimension of the sphere
		int minRange, maxRange; //Range the scale will randomly be between
		Vector3 pos; //Will hold a random position vector within the desired volume for the sphere

		minRange = 10;
		maxRange = 30;

		pos = center + new Vector3(Random.Range(-size.x / 2 , size.x/2), Random.Range(-size.y / 2 , size.y/2),Random.Range(-size.z / 2 , size.z/2));

		xSize = Random.Range(minRange, maxRange);
		ySize = Random.Range(minRange, maxRange);
		zSize = Random.Range(minRange, maxRange);

		spherePrefab.transform.localScale = new Vector3(xSize, ySize, zSize);

		Instantiate(spherePrefab, pos, Quaternion.identity);
	}


	/*
	* Function spawns a cube of a random size and random position onto the map
	*/
	public void SpawnSquareRandObstacles(){
		int xSize, ySize, zSize; //Holds the scale sizes of each dimension of the cube
		int minRange, maxRange; //Range the scale will randomly be between
		Vector3 pos; //Will hold a random position vector within the desired volume for the cube

		minRange = 10;
		maxRange = 30;

		pos = center + new Vector3(Random.Range(-size.x / 2 , size.x/2), Random.Range(-size.y / 2 , size.y/2),Random.Range(-size.z / 2 , size.z/2));

		xSize = Random.Range(minRange, maxRange);
		ySize = Random.Range(minRange, maxRange);
		zSize = Random.Range(minRange, maxRange);

		cubePrefab.transform.localScale = new Vector3(xSize, ySize, zSize);

		Instantiate(cubePrefab, pos, Quaternion.identity);
	}

	/*
	* Function that creates a transparent cube that contains the volume where obstacles can spawn
	*/
	void OnDrawGizmosSelected(){
		Gizmos.color = new Color(1,0,0,0.5f);
		Gizmos.DrawCube(transform.localPosition + center, size);


	}
}
