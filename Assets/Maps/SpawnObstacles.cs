using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary; //Used for saving configuration files
using System.IO; //Lets us read/write to save files
using UnityEngine;

public class SpawnObstacles : MonoBehaviour {


	public GameObject cubePrefab;
	public GameObject spherePrefab;

	public Vector3 center;
	public Vector3 size;

	private int minCubeSize;
	private int maxCubeSize;

	private int minSphereSize;
	private int maxSphereSize;

	private int numCubes;
	private int numSpheres;

	private bool vision;
	public GameObject visionBlocker;

	private int depthLength;
	public Camera cam; //FirstPersonCharacter camera

	private SaveMapSettings MapSetting = new SaveMapSettings();



	// Use this for initialization
	void Start () {

		LoadMapSettings();

		numCubes = MapSetting.cubesSpawned;
		numSpheres = MapSetting.spheresSpawned;
		minCubeSize = MapSetting.cubeMinSize;
		maxCubeSize = MapSetting.cubeMaxSize;
		minSphereSize = MapSetting.sphereMinSize;
		maxSphereSize =  MapSetting.sphereMaxSize;
		vision = MapSetting.vision;
		depthLength = MapSetting.depthLength;
		cam.farClipPlane = depthLength;
		visionBlocker.SetActive (vision);

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

	private void LoadMapSettings(){
		var path = Application.dataPath + "/MapSettings/mapsetting.json";
		string result = string.Concat(path);
		string json = File.ReadAllText (result);
		SaveMapSettings LoadedMapSettings;
		LoadedMapSettings = JsonUtility.FromJson<SaveMapSettings> (json);

		MapSetting = LoadedMapSettings;


		///TO DO: IMPLEMENT ERROR CHECKING similar to OnLoadConfigurationClick

	}

	/*
	* Function spawns a sphere of a random size and random position onto the map
	*/
	public void SpawnSphereRandObstacles(){
		int xSize, ySize, zSize; //Holds the scale sizes of each dimension of the sphere
		Vector3 pos; //Will hold a random position vector within the desired volume for the sphere
		GameObject clone; //clone of the Square prefab

		pos = center + new Vector3(Random.Range(-size.x / 2 , size.x/2), Random.Range(-size.y / 2 , size.y/2),Random.Range(-size.z / 2 , size.z/2));

		xSize = Random.Range(minSphereSize, maxSphereSize);
		ySize = Random.Range(minSphereSize, maxSphereSize);
		zSize = Random.Range(minSphereSize, maxSphereSize);

		//spherePrefab.transform.localScale = new Vector3(xSize, ySize, zSize);

		clone = Instantiate(spherePrefab, pos, Quaternion.identity);

		clone.transform.localScale = new Vector3(xSize, ySize, zSize);
	}


	/*
	* Function spawns a cube of a random size and random position onto the map
	*/
	public void SpawnSquareRandObstacles(){
		int xSize, ySize, zSize; //Holds the scale sizes of each dimension of the cube
		Vector3 pos; //Will hold a random position vector within the desired volume for the cube
		GameObject clone; //clone of the Square prefab

		pos = center + new Vector3(Random.Range(-size.x / 2 , size.x/2), Random.Range(-size.y / 2 , size.y/2),Random.Range(-size.z / 2 , size.z/2));

		xSize = Random.Range(minCubeSize, maxCubeSize);
		ySize = Random.Range(minCubeSize, maxCubeSize);
		zSize = Random.Range(minCubeSize, maxCubeSize);

		//cubePrefab.transform.localScale = new Vector3(xSize, ySize, zSize);

		clone = Instantiate(cubePrefab, pos, Quaternion.identity);

		clone.transform.localScale = new Vector3(xSize, ySize, zSize);

	}

	/*
	* Function that creates a transparent cube that contains the volume where obstacles can spawn
	*/
	void OnDrawGizmosSelected(){
		Gizmos.color = new Color(1,0,0,0.5f);
		Gizmos.DrawCube(transform.localPosition + center, size);


	}
}
