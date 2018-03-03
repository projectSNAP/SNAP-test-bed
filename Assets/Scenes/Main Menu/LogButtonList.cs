using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LogButtonList : MonoBehaviour {

	#region Singleton
	public static LogButtonList instance;

	void Awake(){
		instance = this;
	}
	#endregion

	public List<GameObject> logsList = new List<GameObject>();

	public GameObject logButton; /*holds my "LogButton" prefab*/
	public Transform grid;

	// Use this for initialization
	void Start () {
		RefreshDisplay ();
	}

	public void RefreshDisplay(){
		AddLogButton ();
	}

	private void AddLogButton(){
		/*For each log file in the "Logs" folder, we need to create a button*/
		int logFileNumber = 0;
		string logFilePath;
		/*While loop seaches through "Logs" folder and checks if the log file, with a specific number, exists*/
		while (System.IO.File.Exists ("Assets/Logs/log" + logFileNumber + ".json")) {
			/*Path to the log file*/
			logFilePath = "Assets/Logs/log" + logFileNumber + ".json";

			/*Create a new log button from "LogButton" prefab. (Assets->UX Prefabs)*/
			GameObject newLogButton = Instantiate(logButton);

			/*Place the button in the "Grid" Transform component*/
			newLogButton.transform.SetParent (grid);

			/*Creates an instance of our LogButtonScript class using our newLogButton*/
			LogButtonScript informationLogButton = newLogButton.GetComponent<LogButtonScript> ();

			/*Access the "Setup" function from out LogButtonScript class, which
			 *takes the information from the log file and puts it in our button.
			 */
			informationLogButton.Setup (logFilePath);

			/*Add the log button to our log button list*/
			logsList.Add (newLogButton);

			logFileNumber++;
		}

	}

	public void Add(GameObject log){
		logsList.Add (log);
	}

	public void Filter(string mapName){
		foreach (GameObject log in logsList) {
			if (log.GetComponent<LogButtonScript>().mapLabel.text != mapName) {
				log.SetActive (false);
			} else {
				log.SetActive (true);
			}
		}
	}

	public void ResetFilter(){
		foreach (GameObject log in logsList) {
			log.SetActive (true);
		}
	}

}
