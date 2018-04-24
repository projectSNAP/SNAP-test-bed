using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour {

	private float totalTime; //Holds the total time the user took to finish the map
	private float startTime;
	private float endTime;
	public GameObject MenuCanvas;
	public Transform FPSControllerObject;
	public Text collisionsLabel;
	public Text timeLabel;
	public string mapName;
	int LogFileNumber;

	void Start(){
		/*Variable that changes if the log file with the LogFileNumber is already saved.
		 * For example: if a file is called "Log4.json", then the next file should be called "Log5.json",
		 * so LogFileNumber should equal 5
		 */
		LogFileNumber = 0;
		startTime = Time.time;
	}

	/*
	*Function detects when character has entered the finish line of the map
	*/
	void OnTriggerEnter(Collider col){

		if(col.gameObject.name == "FinishLine"){
			endTime = Time.time;
			totalTime = endTime - startTime;
			/*Opens the Test Complete Menu when reaching the finish line*/
			MenuCanvas.GetComponent<SubMenuUI>().OpenTestCompleteMenu();
			/*Accesses the "CollisionDetection" script through the FPSController to grab the number of collisions from the test*/
			collisionsLabel.text = "Collisions: " + FPSControllerObject.GetComponent<CollisionDetection> ().GetTotalCollisions ();
			timeLabel.text = "Time: " + totalTime.ToString() + " sec";
			/*Save all the information as a JSON file*/
			SaveLogFile ();
			/*reset Total Collisions for next test */
			FPSControllerObject.GetComponent<CollisionDetection> ().ResetTotalCollisions();
		}
	}



	/****************************************** Save Log File ******************************************/

	private SaveLoggingInformation CreateLogFile(){
		SaveLoggingInformation save = new SaveLoggingInformation ();
		save.mapName = mapName;
		save.numberOfCollisions = FPSControllerObject.GetComponent<CollisionDetection> ().GetTotalCollisions();
		save.timeCompleted = totalTime;
		save.date = System.DateTime.Now.ToString("MM/dd/yyyy");
		return save;
	}

	public void SaveLogFile(){
		/*Uses the "SaveLoggingInformation" class to create a "LogSaveFile"*/
		SaveLoggingInformation LogSaveFile = CreateLogFile ();

		/*Convert "LogSaveFile" information to json string*/
		string json = JsonUtility.ToJson (LogSaveFile);

		/*The log file name*/
		string logfile = "log" + LogFileNumber + ".json";

		/*Check if the log file exists with the specific LogFileNumber exists.
		 *If it does exist, then increment the LogFileNumber until you find
		 *an available file name.
		 */
		while (System.IO.File.Exists ("Logs/" + logfile)) {
			LogFileNumber++;
			logfile = "log" + LogFileNumber + ".json";
		}
		logfile = "log" + LogFileNumber;

		var path = "Logs/" + logfile + ".json";

		/*Write the file with the given path*/
		if (path.Length != 0) {
			File.WriteAllText (path, string.Empty); /*makes sure that the file is empty before writing to it*/
			StreamWriter writer = new StreamWriter (path, true);
			writer.Write (json);
			writer.Close ();
		}
		LogFileNumber++;
	}
	/***************************************************************************************************/
}
