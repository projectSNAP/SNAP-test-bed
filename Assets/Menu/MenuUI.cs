using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary; //Used for saving configuration files
using System.IO; //Lets us read/write to save files
using UnityEngine.SceneManagement;
using SFB;


[System.Serializable]

public class MenuUI : MonoBehaviour {
	/*Main Menu UI elements*/
	public static bool EscapeMenuIsOpen = false;
	public static bool NewConfigurationMenuIsOpen = false;
	public static bool SelectMapMenuIsOpen = false;
	public static bool MapSettingsMenuIsOpen = false;
	public static bool LogsMenuIsOpen = false;
	public GameObject ConfigurationMenuUI;
	public GameObject EscapeMenuUI;
	public GameObject MapSelectionUI;
	public GameObject MapSettingUI;
	public GameObject LogsMenuUI;

	/*Configuration settings elements*/
	public float frequency;
	public float tempFrequency;
	public float maxFrequency;
	public UnityEngine.UI.Slider FrequencySlider;
	public UnityEngine.UI.InputField FrequencyInputField;

	public float frequencyIncrement;
	public float tempFrequencyIncrement;
	public float maxFrequencyIncrement;
	public UnityEngine.UI.Slider FrequencyIncrementSlider;
	public UnityEngine.UI.InputField FrequencyIncrementInputField;

	public float horizontalSteps;
	public float tempHorizontalSteps;
	public float maxHorizontalSteps;
	public UnityEngine.UI.Slider HorizontalStepsSlider;
	public UnityEngine.UI.InputField HorizontalStepsInputField;

	public float stepDelay;
	public float tempStepDelay;
	public float maxStepDelay;
	public UnityEngine.UI.Slider StepDelaySlider;
	public UnityEngine.UI.InputField StepDelayInputField;

	public float audioSpreadDegree;
	public float tempAudioSpreadDegree;
	public float maxAudioSpreadDegree;
	public UnityEngine.UI.Slider AudioSpreadDegreeSlider;
	public UnityEngine.UI.InputField AudioSpreadDegreeInputField;

	public float audioVolumeRollOff;
	public float tempAudioVolumeRollOff;
	public float maxAudioVolumeRollOff;
	public UnityEngine.UI.Slider AudioVolumeRollOffSlider;
	public UnityEngine.UI.InputField AudioVolumeRollOffInputField;

	public int scanningType;
	public int tempScanningType;
	public int maxScanningType;
	public UnityEngine.UI.Dropdown ScanningTypeDropdown;

	public bool vision;
	public bool tempVision;
	public UnityEngine.UI.Toggle VisionToggle;


	/*Map settings elements*/
	public int cubesSpawned;
	public int tempCubesSpawned;
	public int maxCubesSpawned;
	public UnityEngine.UI.Slider CubesSpawnedSlider;
	public UnityEngine.UI.InputField CubesSpawnedInputField;

	public int spheresSpawned;
	public int tempSpheresSpawned;
	public int maxSpheresSpawned;
	public UnityEngine.UI.Slider SpheresSpawnedSlider;
	public UnityEngine.UI.InputField SpheresSpawnedInputField;

	public int cubeMinSize;
	public int tempCubeMinSize;
	public int maxCubeMinSize;
	public UnityEngine.UI.Slider CubeMinSizeSlider;
	public UnityEngine.UI.InputField CubeMinSizeInputField;

	public int cubeMaxSize;
	public int tempCubeMaxSize;
	public int maxCubeMaxSize;
	public UnityEngine.UI.Slider CubeMaxSizeSlider;
	public UnityEngine.UI.InputField CubeMaxSizeInputField;

	public int sphereMinSize;
	public int tempSphereMinSize;
	public int maxSphereMinSize;
	public UnityEngine.UI.Slider SphereMinSizeSlider;
	public UnityEngine.UI.InputField SphereMinSizeInputField;

	public int sphereMaxSize;
	public int tempSphereMaxSize;
	public int maxSphereMaxSize;
	public UnityEngine.UI.Slider SphereMaxSizeSlider;
	public UnityEngine.UI.InputField SphereMaxSizeInputField;

	public int mapSelected;
	public int tempMapSelected;
	public int maxMapType;
	public UnityEngine.UI.Dropdown MapSelectedDropdown;


	private SaveMapSettings mainMapSettings = new SaveMapSettings();


	/*Minimum value for configurations*/
	public float minValue;

	/*Map Selection UI elements*/
	public static bool HallwayRandomObjects = true;
	public static bool HallwayDynamic = false;
	public UnityEngine.UI.Toggle HallwayRandomObjectToggle;
	public UnityEngine.UI.Toggle HallwayDynamicToggle;

	// Use this for initialization
	void Start () {
		/*min value setting for all configurations*/
		minValue = 0;

		/*max settings*/
		maxFrequency = 50;
		maxFrequencyIncrement = 10;
		maxHorizontalSteps = 10;
		maxStepDelay = 10;
		maxAudioSpreadDegree = 90;
		maxAudioVolumeRollOff = 50;
		maxScanningType = 1; //two scanning type options, 0 or 1

		/*default configuration settings*/
		frequency = 25f;
		frequencyIncrement = 5f;
		horizontalSteps = 5f;
		stepDelay = 5f;
		audioSpreadDegree = 45f;
		audioVolumeRollOff = 25f;
		scanningType = 0;
		vision = false;

		/*default temp configuration settings*/
		tempFrequency = 25f;
		tempFrequencyIncrement = 5f;
		tempHorizontalSteps = 5f;
		tempStepDelay = 5f;
		tempAudioSpreadDegree = 45f;
		tempAudioVolumeRollOff = 25f;
		tempScanningType = 0;
		tempVision = false;

		/*max map settings*/
		maxCubesSpawned = 30;
		maxSpheresSpawned = 30;
		maxCubeMinSize = 15;
		maxCubeMaxSize = 30;
		maxSphereMinSize = 15;
		maxSphereMaxSize = 30;
		maxScanningType = 1; //two scanning type options, 0 or 1

		/*default configuration settings*/
		cubesSpawned = 15;
		spheresSpawned = 15;
		cubeMinSize = 15;
		cubeMaxSize = 15;
		sphereMinSize = 15;
		sphereMaxSize = 15;
		mapSelected = 0;

		/*default temp configuration settings*/
		tempCubesSpawned = 15;
		tempSpheresSpawned = 15;
		tempCubeMinSize = 15;
		tempCubeMaxSize = 15;
		tempSphereMinSize = 15;
		tempSphereMaxSize = 15;
		tempMapSelected = 0;

		/*default map settings*/
		mainMapSettings.savedCubesSpawned = cubesSpawned;
		mainMapSettings.savedSpheresSpawned = spheresSpawned;
		mainMapSettings.savedCubeMinSize = cubeMinSize;
		mainMapSettings.savedCubeMaxSize = cubeMaxSize;
		mainMapSettings.savedSphereMinSize = sphereMinSize;
		mainMapSettings.savedSphereMaxSize = sphereMaxSize;
		mainMapSettings.savedMapSelected = 0;



		/*default Map Selection settings*/
		if (HallwayRandomObjects) {
			HallwayRandomObjectToggle.isOn = true;
		} else if (HallwayDynamic) {
			HallwayDynamicToggle.isOn = true;
		} else {
			HallwayRandomObjectToggle.isOn = false;
			HallwayDynamicToggle.isOn = false;
		}

		/*Main Menu will be showing when a user clicks any "back to main menu" button*/
		EscapeMenuUI.SetActive (true);
		CloseConfigMenu ();
		//CloseMapSelectionMenu ();
		CloseMapSettingsMenu();
		CloseLogsMenu ();


		/*Sets the cursor as active*/
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	// Update is called once per frame
	void Update () {
		/* Open/Close Escape menu when Escape is pressed */
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (EscapeMenuIsOpen) {
				CloseEscapeMenu ();
			} else if (NewConfigurationMenuIsOpen) {
				CloseConfigMenu ();
				OpenEscapeMenu ();
			} else if (MapSettingsMenuIsOpen){
				CloseMapSettingsMenu ();
				OpenEscapeMenu ();
			} else if (LogsMenuIsOpen){
				CloseLogsMenu ();
				OpenEscapeMenu ();
			} else {
				OpenEscapeMenu ();
			}
		}

	}


	/********************************* Open/Close SNAP Menu ******************************************/
	/*On Escape Button pressed*/
	public void CloseEscapeMenu(){
		EscapeMenuUI.SetActive (false);
		Time.timeScale = 1f;
		EscapeMenuIsOpen = false;
	}

	public void OpenEscapeMenu(){
		EscapeMenuUI.SetActive (true);
		Time.timeScale = 0f;
		EscapeMenuIsOpen = true;
	}

	/**************************/
	public void CloseMapSettingsMenu(){
		MapSettingUI.SetActive(false);
		Time.timeScale = 1f;
		MapSettingsMenuIsOpen = false;

	}

	public void CloseConfigMenu(){
		ConfigurationMenuUI.SetActive (false);
		Time.timeScale = 1f;
		NewConfigurationMenuIsOpen = false;
	}

	/*New Configuration Button*/
	public void OpenConfigMenu(){
		ConfigurationMenuUI.SetActive (true);
		Time.timeScale = 0f;
		NewConfigurationMenuIsOpen = true;
		EscapeMenuIsOpen = false;
	}

	/* Load Configuration Button
	 * Useful information on JSON for Unity:
	 * 	https://docs.unity3d.com/Manual/JSONSerialization.html
	*/
	public void OnLoadConfigurationClick(){
		var path = StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false);
		string result = string.Concat(path);
		string json = File.ReadAllText (result);
		SaveConfigurationSettings LoadedConfig;
		LoadedConfig = JsonUtility.FromJson<SaveConfigurationSettings> (json);

		/*set all configuration settings to loaded configurations*/
		if (LoadedConfig.savedFrequency >= minValue && LoadedConfig.savedFrequency <= maxFrequency)
			frequency = LoadedConfig.savedFrequency;
		else
			Debug.Log ("error: value for 'frequency' is out of range");

		if(LoadedConfig.savedFrequencyIncrement >= minValue && LoadedConfig.savedFrequencyIncrement <= maxFrequencyIncrement)
			frequencyIncrement = LoadedConfig.savedFrequencyIncrement;
		else
			Debug.Log ("error: value for 'frequency increment' is out of range");

		if(LoadedConfig.savedHorizontalSteps >= minValue && LoadedConfig.savedHorizontalSteps <= maxHorizontalSteps)
			horizontalSteps = LoadedConfig.savedHorizontalSteps;
		else
			Debug.Log ("error: value for 'horizontal steps' is out of range");

		if(LoadedConfig.savedStepDelay >= minValue && LoadedConfig.savedStepDelay <= maxStepDelay)
			stepDelay = LoadedConfig.savedStepDelay;
		else
			Debug.Log ("error: value for 'step delay' is out of range");

		if(LoadedConfig.savedAudioSpreadDegree >= minValue && LoadedConfig.savedAudioSpreadDegree <= maxAudioSpreadDegree)
			audioSpreadDegree = LoadedConfig.savedAudioSpreadDegree;
		else
			Debug.Log ("error: value for 'audio spread degree' is out of range");

		if(LoadedConfig.savedAudioVolumeRollOff >= minValue && LoadedConfig.savedAudioVolumeRollOff <= maxAudioVolumeRollOff)
			audioVolumeRollOff = LoadedConfig.savedAudioVolumeRollOff;
		else
			Debug.Log ("error: value for 'audio volume roll-off' is out of range");

		if(LoadedConfig.savedScanningType >= minValue && LoadedConfig.savedScanningType <= maxScanningType)
			scanningType = LoadedConfig.savedScanningType;
		else
			Debug.Log ("error: value for 'scanning type' is out of range");

		vision = LoadedConfig.savedVision;

		/*set all configuration Sliders and Input Fields to loaded configuration values*/
		FrequencySlider.value = frequency;
		FrequencyInputField.text = frequency.ToString();

		FrequencyIncrementSlider.value = frequencyIncrement;
		FrequencyIncrementInputField.text = frequencyIncrement.ToString();

		HorizontalStepsSlider.value = horizontalSteps;
		HorizontalStepsInputField.text = horizontalSteps.ToString();

		StepDelaySlider.value = stepDelay;
		StepDelayInputField.text = stepDelay.ToString();

		AudioSpreadDegreeSlider.value = audioSpreadDegree;
		AudioSpreadDegreeInputField.text = audioSpreadDegree.ToString();

		AudioVolumeRollOffSlider.value = audioVolumeRollOff;
		AudioVolumeRollOffInputField.text = audioVolumeRollOff.ToString();

		ScanningTypeDropdown.value = scanningType;

		VisionToggle.isOn = vision;

	}

	/*Back Button*/
	public void OnSNAPBackButtonClick(){
		CloseEscapeMenu ();
	}
	/****************************************************************************************************/


	/********************** Save/Cancel Configurations from Configuration Menu **************************/
	/*When the Save Button is clicked, a new instance of the SaveConfiguration Class is created
	 *and stored in a JSON file
	 */
	private SaveConfigurationSettings CreateConfigurationSave(){
		SaveConfigurationSettings save = new SaveConfigurationSettings ();
		save.savedFrequency = tempFrequency;
		save.savedFrequencyIncrement = tempFrequencyIncrement;
		save.savedHorizontalSteps = tempHorizontalSteps;
		save.savedStepDelay = tempStepDelay;
		save.savedAudioSpreadDegree = tempAudioSpreadDegree;
		save.savedAudioVolumeRollOff = tempAudioVolumeRollOff;
		save.savedScanningType = tempScanningType;
		save.savedVision = tempVision;
		return save;
	}

	private SaveMapSettings CreateMapSave(){
		SaveMapSettings save = new SaveMapSettings();
		save.savedCubesSpawned = tempCubesSpawned;
		save.savedSpheresSpawned = tempSpheresSpawned;
		save.savedCubeMinSize = tempCubeMinSize;
		save.savedCubeMaxSize = tempCubeMaxSize;
		save.savedSphereMinSize = tempSphereMinSize;
		save.savedSphereMaxSize = tempSphereMaxSize;
		save.savedMapSelected = tempMapSelected;

		if(tempMapSelected == 0){
			HallwayRandomObjects = true;
			HallwayDynamic = false;
		}
		else{
			HallwayRandomObjects = false;
			HallwayDynamic = true;
		}

		return save;
	}

	/* Saves the configurations when the Save Button is clicked.
	 * Brings up the File Explorer window so the user can select where to place the new configuration file.
	 * Allows the user to name the file whatever they want.
	 */
	public void SaveConfigurationOnSaveClick(){
		SaveConfigurationSettings save = CreateConfigurationSave ();
		/*serialization of save*/


		string json = JsonUtility.ToJson (save);
		var path = StandaloneFileBrowser.SaveFilePanel("Save configuration", "", "newconfig", "json");
		string newPath = string.Concat(path);
		if (newPath.Length != 0) {
			File.WriteAllText (path, string.Empty); //makes sure that the file is empty before writing to it
			StreamWriter writer = new StreamWriter (path, true);
			writer.Write (json);
			writer.Close ();
		}
	}

	public void SaveMapSettingsOnSaveClick(){
		SaveMapSettings save = CreateMapSave();

		mainMapSettings = save;

		string json = JsonUtility.ToJson (save);
		var path = Application.dataPath + "/MapSettings/mapsetting.json";
		//string newPath = string.Concat(path);
		if (path.Length != 0) {
			File.WriteAllText (path, string.Empty); //makes sure that the file is empty before writing to it
			StreamWriter writer = new StreamWriter (path, true);
			writer.Write (json);
			writer.Close ();
		}

		CloseMapSettingsMenu();
		OpenEscapeMenu();

		/*
		string json = JsonUtility.ToJson(save);
		var path = StandaloneFileBrowser.SaveFilePanel("Save Map Settings", "", "newmap", "json");
		string newPath = string.Concat(path);
		if(newPath.Length != 0){
			File.WriteAllText(path, string.Empty);
			StreamWriter writer = new StreamWriter (path, true);
			writer.Write(json);
			writer.Close();
		}
		*/
	}

	public void OnMapSettingCancelClick(){
		/* When the Cancel Button is clicked, set all Slider and Input Fields back to the original settings.*/
		CubesSpawnedSlider.value = cubesSpawned;
		CubesSpawnedInputField.text = cubesSpawned.ToString();

		SpheresSpawnedSlider.value = spheresSpawned;
		SpheresSpawnedInputField.text = spheresSpawned.ToString();

		CubeMinSizeSlider.value = cubeMinSize;
		CubeMinSizeInputField.text = cubeMinSize.ToString();

		CubeMaxSizeSlider.value = cubeMaxSize;
		CubeMaxSizeInputField.text = cubeMaxSize.ToString();

		SphereMinSizeSlider.value = sphereMinSize;
		SphereMinSizeInputField.text = sphereMinSize.ToString();

		SphereMaxSizeSlider.value = sphereMaxSize;
		SphereMaxSizeInputField.text = sphereMaxSize.ToString();

		MapSelectedDropdown.value = mapSelected;


		CloseMapSettingsMenu ();
		OpenEscapeMenu ();
	}

	public void OnCancelButtonClick(){
		/* When the Cancel Button is clicked, set all Slider and Input Fields back to the original settings.*/
		FrequencySlider.value = frequency;
		FrequencyInputField.text = frequency.ToString();

		FrequencyIncrementSlider.value = frequencyIncrement;
		FrequencyIncrementInputField.text = frequencyIncrement.ToString();

		HorizontalStepsSlider.value = horizontalSteps;
		HorizontalStepsInputField.text = horizontalSteps.ToString();

		StepDelaySlider.value = stepDelay;
		StepDelayInputField.text = stepDelay.ToString();

		AudioSpreadDegreeSlider.value = audioSpreadDegree;
		AudioSpreadDegreeInputField.text = audioSpreadDegree.ToString();

		AudioVolumeRollOffSlider.value = audioVolumeRollOff;
		AudioVolumeRollOffInputField.text = audioVolumeRollOff.ToString();

		ScanningTypeDropdown.value = scanningType;

		VisionToggle.isOn = vision;

		CloseConfigMenu ();
		OpenEscapeMenu ();
	}

	public void onMapSettingBackButtonClick(){
		cubesSpawned = tempCubesSpawned;
		spheresSpawned = tempSpheresSpawned;
		cubeMinSize = tempCubeMinSize;
		cubeMaxSize = tempCubeMaxSize;
		sphereMinSize = tempSphereMinSize;
		sphereMaxSize = tempSphereMaxSize;
		mapSelected = tempMapSelected;

		CloseMapSettingsMenu ();
		OpenEscapeMenu ();
	}

	public void OnConfigurationBackButtonClick(){
		/* When the Back Button is clicked, set all configurations equal to temporary configurations.
		 * i.e. Remembers the configurations the user changed when they click the Back Button
		 */
		frequency = tempFrequency;
		frequencyIncrement = tempFrequencyIncrement;
		horizontalSteps = tempHorizontalSteps;
		stepDelay = tempStepDelay;
		audioSpreadDegree = tempAudioSpreadDegree;
		audioVolumeRollOff = tempAudioVolumeRollOff;
		scanningType = tempScanningType;
		vision = tempVision;

		CloseConfigMenu ();
		OpenEscapeMenu ();
	}
	/****************************************************************************************************/


	/********************************* Cubes Spawned Configuration ******************************************/
	/*Adjusts the frequency when the Frequency Slider is moved*/
	public void AdjustCubesSpawnedFromSlider(){
		tempCubesSpawned = (int) CubesSpawnedSlider.value;
	}

	/*Adjust the frequency when the Frequency Input Field is changed*/
	public void AdjustCubesSpawnedInputField(){
		tempCubesSpawned = int.Parse(CubesSpawnedInputField.text);
	}

	/*Change the Frequency Input Field text to match Frequency Slider value when slider is moved*/
	public void OnCubesSpawnedSliderChanged(){
		CubesSpawnedInputField.text = tempCubesSpawned.ToString();
	}

	/*Change the Frequency Slider value to match Frequency Input Field when input field is changed*/
	public void OnCubesSpawnedInputFieldChanged(){
		CubesSpawnedSlider.value = tempCubesSpawned;
	}

	/****************************************************************************************************/


	/********************************* Spheres Spawned Configuration ******************************************/
	/*Adjusts the frequency when the Frequency Slider is moved*/
	public void AdjustSpheresSpawnedFromSlider(){
		tempSpheresSpawned = (int) SpheresSpawnedSlider.value;
	}

	/*Adjust the frequency when the Frequency Input Field is changed*/
	public void AdjustSpheresSpawnedInputField(){
		tempSpheresSpawned = int.Parse(SpheresSpawnedInputField.text);
	}

	/*Change the Frequency Input Field text to match Frequency Slider value when slider is moved*/
	public void OnSpheresSpawnedSliderChanged(){
		SpheresSpawnedInputField.text = tempSpheresSpawned.ToString();
	}

	/*Change the Frequency Slider value to match Frequency Input Field when input field is changed*/
	public void OnSpheresSpawnedInputFieldChanged(){
		SpheresSpawnedSlider.value = tempSpheresSpawned;
	}

	/****************************************************************************************************/


	/********************************* Cube Minimum Size Configuration ******************************************/
	/*Adjusts the frequency when the Frequency Slider is moved*/
	public void AdjustCubeMinSizeFromSlider(){
		tempCubeMinSize = (int) CubeMinSizeSlider.value;
	}

	/*Adjust the frequency when the Frequency Input Field is changed*/
	public void AdjustCubeMinSpawnInputField(){
		tempCubeMinSize = int.Parse(CubeMinSizeInputField.text);
	}

	/*Change the Frequency Input Field text to match Frequency Slider value when slider is moved*/
	public void OnCubeMinimumSliderChanged(){
		CubeMinSizeInputField.text = tempCubeMinSize.ToString();
	}

	/*Change the Frequency Slider value to match Frequency Input Field when input field is changed*/
	public void OnCubeMinimumFieldChanged(){
		CubeMinSizeSlider.value = tempCubeMinSize;
	}

	/****************************************************************************************************/


	/********************************* Cube Maximum Size Configuration ******************************************/
	/*Adjusts the frequency when the Frequency Slider is moved*/
	public void AdjustCubeMaxSizeFromSlider(){
		tempCubeMaxSize = (int) CubeMaxSizeSlider.value;
	}

	/*Adjust the frequency when the Frequency Input Field is changed*/
	public void AdjustCubeMaxSizeFromInputField(){
		tempCubeMaxSize = int.Parse(CubeMaxSizeInputField.text);
	}

	/*Change the Frequency Input Field text to match Frequency Slider value when slider is moved*/
	public void OnCubeMaxSizeSliderChanged(){
		CubeMaxSizeInputField.text = tempCubeMaxSize.ToString();
	}

	/*Change the Frequency Slider value to match Frequency Input Field when input field is changed*/
	public void OnCubeMaxSizeInputFieldChanged(){
		CubeMaxSizeSlider.value = tempCubeMaxSize;
	}

	/****************************************************************************************************/


	/********************************* Sphere Minimum Size Configuration ******************************************/
	/*Adjusts the frequency when the Frequency Slider is moved*/
	public void AdjustSphereMinSizeFromSlider(){
		tempSphereMinSize = (int) SphereMinSizeSlider.value;
	}

	/*Adjust the frequency when the Frequency Input Field is changed*/
	public void AdjustSphereMinSizeFromInputField(){
		tempSphereMinSize = int.Parse(SphereMinSizeInputField.text);
	}

	/*Change the Frequency Input Field text to match Frequency Slider value when slider is moved*/
	public void OnSphereMinSizeSliderChanged(){
		SphereMinSizeInputField.text = tempSphereMinSize.ToString();
	}

	/*Change the Frequency Slider value to match Frequency Input Field when input field is changed*/
	public void OnSphereMinSizeInputFieldChanged(){
		SphereMinSizeSlider.value = tempSphereMinSize;
	}

	/****************************************************************************************************/


	/********************************* Sphere Maximum Size Configuration ******************************************/
	/*Adjusts the frequency when the Frequency Slider is moved*/
	public void AdjustSphereMaxSizeFromSlider(){
		tempSphereMaxSize = (int) SphereMaxSizeSlider.value;
	}

	/*Adjust the frequency when the Frequency Input Field is changed*/
	public void AdjustSphereMaxSizeFromInputField(){
		tempSphereMaxSize = int.Parse(SphereMaxSizeInputField.text);
	}

	/*Change the Frequency Input Field text to match Frequency Slider value when slider is moved*/
	public void OnSphereMaxSizeSliderChanged(){
		SphereMaxSizeInputField.text = tempSphereMaxSize.ToString();
	}

	/*Change the Frequency Slider value to match Frequency Input Field when input field is changed*/
	public void OnSphereMaxSizeInputFieldChanged(){
		SphereMaxSizeSlider.value = tempSphereMaxSize;
	}

	/****************************************************************************************************/


	/******************************************* Map Selected ******************************************/
	public void AdjustMapSelectedDropdown(){
		tempMapSelected = MapSelectedDropdown.value;
	}

	public void OnMapSelectedDropdownClicked(){
		MapSelectedDropdown.value = tempMapSelected;
	}



	/****************************************************************************************************/


	/********************************* Frequency Configuration ******************************************/
	/*Adjusts the frequency when the Frequency Slider is moved*/
	public void AdjustFrequencyFromSlider(){
		tempFrequency = FrequencySlider.value;
	}

	/*Adjust the frequency when the Frequency Input Field is changed*/
	public void AdjustFrequencyFromInputField(){
		tempFrequency = float.Parse(FrequencyInputField.text);
	}

	/*Change the Frequency Input Field text to match Frequency Slider value when slider is moved*/
	public void OnFrequencySliderChanged(){
		FrequencyInputField.text = tempFrequency.ToString();
	}

	/*Change the Frequency Slider value to match Frequency Input Field when input field is changed*/
	public void OnFrequencyInputFieldChanged(){
		FrequencySlider.value = tempFrequency;
	}
	/****************************************************************************************************/


	/******************************** Frequency Increment Configuration *********************************/
	/*Adjusts the frequency increment when the Frequency Increment Slider is moved*/
	public void AdjustFrequencyIncrementFromSlider(){
		tempFrequencyIncrement = FrequencyIncrementSlider.value;
	}

	/*Adjust the frequency increment when the Frequency Increment Input Field is changed*/
	public void AdjustFrequencyIncrementFromInputField(){
		tempFrequencyIncrement = float.Parse (FrequencyIncrementInputField.text);
	}

	/*Change the Frequency Increment Input Field text to match Frequency Increment Slider value when slider is moved*/
	public void OnFrequencyIncrementSliderChanged(){
		FrequencyIncrementInputField.text = tempFrequencyIncrement.ToString();
	}

	/*Change the Frequency Increment Slider value to match Frequency Increment Input Field when input field is changed*/
	public void OnFrequencyIncrementInputFieldChanged(){
		FrequencyIncrementSlider.value = tempFrequencyIncrement;
	}
	/****************************************************************************************************/


	/**************************************** Horizontal Steps *****************************************/
	/*Adjusts the horizontal steps when the Horizontal Steps Slider is moved*/
	public void AdjustHorizontalStepsFromSlider(){
		tempHorizontalSteps = HorizontalStepsSlider.value;
	}

	/*Adjust the horizontal steps when the Horizontal Steps Input Field is changed*/
	public void AdjustHorizontalStepsFromInputField(){
		tempHorizontalSteps = float.Parse (HorizontalStepsInputField.text);
	}

	/*Change the Horizontal Steps Input Field text to match Horizontal Steps Slider value when slider is moved*/
	public void OnHorizontalStepsSliderChanged(){
		HorizontalStepsInputField.text = tempHorizontalSteps.ToString();
	}

	/*Change the Horizontal Steps Slider value to match Horizontal Steps Input Field when input field is changed*/
	public void OnHorizontalStepsInputFieldChanged(){
		HorizontalStepsSlider.value = tempHorizontalSteps;
	}
	/****************************************************************************************************/


	/******************************************** Step Delay ********************************************/
	/*Adjusts the step delay when the Step Delay Slider is moved*/
	public void AdjustStepDelayFromSlider(){
		tempStepDelay = StepDelaySlider.value;
	}

	/*Adjust the step delay when the Step Delay Input Field is changed*/
	public void AdjustStepDelayFromInputField(){
		tempStepDelay = float.Parse (StepDelayInputField.text);
	}

	/*Change the step delay Input Field text to match Step Delay Slider value when slider is moved*/
	public void OnStepDelaySliderChanged(){
		StepDelayInputField.text = tempStepDelay.ToString();
	}

	/*Change the step delay Slider value to match Step Delay Input Field when input field is changed*/
	public void OnStepDelayInputFieldChanged(){
		StepDelaySlider.value = tempStepDelay;
	}
	/****************************************************************************************************/


	/**************************************** Audio Spread Degree ***************************************/
	/*Adjusts the audio spread degree when the Audio Spread Degree Slider is moved*/
	public void AdjustAudioSpreadDegreeFromSlider(){
		tempAudioSpreadDegree = AudioSpreadDegreeSlider.value;
	}

	/*Adjust the audio spread degree when the Audio Spread Degree Input Field is changed*/
	public void AdjustAudioSpreadDegreeFromInputField(){
		tempAudioSpreadDegree = float.Parse (AudioSpreadDegreeInputField.text);
	}

	/*Change the audio spread degree Input Field text to match Audio Spread Degree Slider value when slider is moved*/
	public void OnAudioSpreadDegreeSliderChanged(){
		AudioSpreadDegreeInputField.text = tempAudioSpreadDegree.ToString();
	}

	/*Change the audio spread degree Slider value to match Audio Spread Degree Input Field when input field is changed*/
	public void OnAudioSpreadDegreeInputFieldChanged(){
		AudioSpreadDegreeSlider.value = tempAudioSpreadDegree;
	}
	/****************************************************************************************************/


	/*************************************** Audio Volume Roll-off **************************************/
	/*Adjusts the audio volume roll-off when the Audio Volume Roll-off Slider is moved*/
	public void AdjustAudioVolumeRollOffFromSlider(){
		tempAudioVolumeRollOff = AudioVolumeRollOffSlider.value;
	}

	/*Adjust the audio volume roll-off when the Audio Volume Roll-off Input Field is changed*/
	public void AdjustAudioVolumeRollOffFromInputField(){
		tempAudioVolumeRollOff = float.Parse (AudioVolumeRollOffInputField.text);
	}

	/*Change the audio volume roll-off Input Field text to match Audio Volume Roll-off Slider value when slider is moved*/
	public void OnAudioVolumeRollOffSliderChanged(){
		AudioVolumeRollOffInputField.text = tempAudioVolumeRollOff.ToString();
	}

	/*Change the audio volume roll-off Slider value to match Audio Volume Roll-off Input Field when input field is changed*/
	public void OnAudioVolumeRollOffInputFieldChanged(){
		AudioVolumeRollOffSlider.value = tempAudioVolumeRollOff;
	}
	/****************************************************************************************************/


	/********************************************** Vision *********************************************/
	public void AdjustVisionToggle(){
		tempVision = VisionToggle.isOn;
	}

	public void OnVisionToggleClicked(){
		VisionToggle.isOn = tempVision;
	}
	/****************************************************************************************************/


	/******************************************* Scanning Type ******************************************/
	public void AdjustScanningTypeDropdown(){
		tempScanningType = ScanningTypeDropdown.value;
	}

	public void OnScanningTypeDropdownClicked(){
		ScanningTypeDropdown.value = tempScanningType;
	}
	/****************************************************************************************************/




	/************************************** Map Selection Menu ******************************************/
	public void OnSelectMapButtonClicked(){
		CloseEscapeMenu ();
		OpenMapSelectionMenu ();
	}

	public void OnMapSettingsButtonClicked(){
		CloseEscapeMenu();
		OpenMapSettingsMenu();
	}

	public void OnSelectMapBackButtonClicked(){
		CloseMapSelectionMenu ();
		OpenEscapeMenu ();
	}

	public void OnHallwayMapRandomObjectsToggled(){
		if (HallwayRandomObjectToggle.isOn == true) {
			HallwayDynamicToggle.isOn = false;
			HallwayDynamic = false;
		}
		HallwayRandomObjects = HallwayRandomObjectToggle.isOn;
	}

	public void OnHallwayMapDynamicToggled(){
		if (HallwayDynamicToggle.isOn == true) {
			HallwayRandomObjectToggle.isOn = false;
			HallwayRandomObjects = false;
		}
		HallwayDynamic = HallwayDynamicToggle.isOn;
	}


	public void CloseMapSelectionMenu (){
		MapSelectionUI.SetActive (false);
		Time.timeScale = 1f;
		SelectMapMenuIsOpen = false;
	}

	public void OpenMapSelectionMenu(){
		MapSelectionUI.SetActive (true);
		Time.timeScale = 0f;
		SelectMapMenuIsOpen = true;
		EscapeMenuIsOpen = false;
	}

	public void OpenMapSettingsMenu(){
		MapSettingUI.SetActive(true);
		Time.timeScale = 0f;
		MapSettingsMenuIsOpen = true;
		EscapeMenuIsOpen = false;
	}
	/****************************************************************************************************/



	/******************************************** Logs Menu *********************************************/
	/* Logs Button Clicked */
	public void OnLogsButtonClicked(){
		CloseEscapeMenu ();
		OpenLogsMenu ();
		LoadLogFiles ();
	}

	/* Logs Menu Back Button */
	public void OnLogsMenuBackButton(){
		CloseLogsMenu ();
		OpenEscapeMenu ();
	}

	public void CloseLogsMenu(){
		LogsMenuUI.SetActive (false);
		Time.timeScale = 1f;
		LogsMenuIsOpen = false;
	}

	public void OpenLogsMenu(){
		LogsMenuUI.SetActive (true);
		Time.timeScale = 0f;
		LogsMenuIsOpen = true;
		EscapeMenuIsOpen = false;
	}

	public void LoadLogFiles(){

	}
	/****************************************************************************************************/


	/**************************************** Start Button *********************************************/
	public void OnStartButtonClicked(){
		EscapeMenuIsOpen = false;
		if (HallwayRandomObjects == true) {
			SceneManager.LoadScene ("Random Hallway Map", LoadSceneMode.Single);
		} else if (HallwayDynamic == true){
			SceneManager.LoadScene ("Dynamic Map", LoadSceneMode.Single);
		} else{
			Debug.Log ("No Map Selected. Got to \"Select Map\" and choose a map.");
		}
	}
	/****************************************************************************************************/
}
