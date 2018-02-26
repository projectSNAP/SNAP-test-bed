using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //allows us to use Button stuff
using System.IO;

public class LogButtonScript : MonoBehaviour {

	public Button logButton;
	public Text dateLabel;
	public Text mapLabel;
	public Text collisionLabel;
	public Text timeLabel;

	// Use this for initialization
	void Start () {
		
	}

	public void Setup(string logFilePath){
		/*Searches for the log file, and fills in the information for the button*/
		if (System.IO.File.Exists (logFilePath)) {
			/*Converts log file to json string*/
			string jsonLogFile = File.ReadAllText (logFilePath);

			/*Create an instance of the SaveLoggingInformation class
			 *so we can extract information from the json string and
			 *insert it into each class variable.
			 */
			SaveLoggingInformation savedLogFile;
			savedLogFile = JsonUtility.FromJson<SaveLoggingInformation> (jsonLogFile);

			/*Extract the data and insert it into our button via Text components*/
			mapLabel.text = savedLogFile.mapName;
			collisionLabel.text = "Collisions: " + savedLogFile.numberOfCollisions.ToString ();
			timeLabel.text = "Time: " + savedLogFile.timeCompleted.ToString ();
			dateLabel.text = "Date: " + savedLogFile.date;
		} else {
			/*If we can't find the file, thrown an error*/
			Debug.Log ("error: file does not exist");
		}
	}
}
