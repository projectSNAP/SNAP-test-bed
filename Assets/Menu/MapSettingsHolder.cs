using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSettingsHolder : MonoBehaviour {

	private SaveMapSettings savedMS;

	public void setMapSettings(SaveMapSettings newMS){
		savedMS = newMS;
	}
}
