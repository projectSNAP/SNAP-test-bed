using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogsFilter : MonoBehaviour {

	#region Singleton
	public static LogsFilter instance;

	void Awake(){
		instance = this;
	}
	#endregion

	LogButtonList logButtonList;

	public void Start(){
		logButtonList = LogButtonList.instance;
	}

	public void OnFilterClicked(Dropdown filter){
		switch(filter.value){
		case 0:
			logButtonList.ResetFilter ();
			break;
		case 1:
			logButtonList.Filter ("Hallway: Random Objects");
			break;
		case 2:
			logButtonList.Filter ("Hallway: Dynamic");
			break;
		default:
			break;
		}
	}

}
