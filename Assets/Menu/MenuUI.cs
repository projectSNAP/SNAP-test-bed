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
	public static bool MoreConfigurationMenuIsOpen = false;
	public static bool SelectMapMenuIsOpen = false;
	public static bool MapSettingsMenuIsOpen = false;
	public static bool LogsMenuIsOpen = false;
	public GameObject ConfigurationMenuUI;
	public GameObject EscapeMenuUI;
	public GameObject MapSelectionUI;
	public GameObject MapSettingUI;
	public GameObject LogsMenuUI;
	public GameObject MoreConfigurationMenuUI;

	/*Configuration settings elements*/
	public float frequencyMin;
	public float tempFrequencyMin;
	public float minFrequency;
	public UnityEngine.UI.Slider FrequencyMinSlider;
	public UnityEngine.UI.InputField FrequencyMinInputField;

	public float frequencyMax;
	public float tempFrequencyMax;
	public float maxFrequency;
	public UnityEngine.UI.Slider FrequencyMaxSlider;
	public UnityEngine.UI.InputField FrequencyMaxInputField;

	public int horizontalResolution;
	public int tempHorizontalResolution;
	public int maxHorizontalRes;
	public int minHorizontalRes;
	public UnityEngine.UI.Slider HorizontalResolutionSlider;
	public UnityEngine.UI.InputField HorizontalResolutionInputField;

	public int verticalResolution;
	public int tempVerticalResolution;
	public int maxVerticalRes;
	public int minVerticalRes;
	public UnityEngine.UI.Slider VerticalResolutionSlider;
	public UnityEngine.UI.InputField VerticalResolutionInputField;

	public float fieldOfView;
	public float tempFieldOfView;
	public float maxFieldOfView;
	public float minFieldOfView;
	public UnityEngine.UI.Slider FieldOfViewSlider;
	public UnityEngine.UI.InputField FieldOfViewInputField;

	public float sampleLength;
	public float tempSampleLength;
	public float maxSampleLength;
	public float minSampleLength;
	public UnityEngine.UI.Slider SampleLengthSlider;
	public UnityEngine.UI.InputField SampleLengthInputField;

	public int scanningType;
	public int tempScanningType;
	public int maxScanningType;
	public UnityEngine.UI.Dropdown ScanningTypeDropdown;

	public int cycleLength;
	public int tempCycleLength;
	public int maxCycleLength;
	public int minCycleLength;
	public UnityEngine.UI.Slider CycleLengthSlider;
	public UnityEngine.UI.InputField CycleLengthInputField;

	public int depthLength;
	public int tempDepthLength;
	public int maxDepthLength;
	public int minDepthLength;
	public UnityEngine.UI.Slider DepthLengthSlider;
	public UnityEngine.UI.InputField DepthLengthInputField;

	public int distanceIndicator;
	public int tempDistanceIndicator;
	public int maxDistanceIndicator;
	public UnityEngine.UI.Dropdown DistanceIndicatorDropdown;

	public int heightIndicator;
	public int tempHeightIndicator;
	public int maxHeightIndicator;
	public UnityEngine.UI.Dropdown HeightIndicatorDropdown;

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
		/*max/min settings*/
		maxFrequency = 4186.0f;
		minFrequency = 27.5f;
		maxHorizontalRes = 200;
		minHorizontalRes = 2;
		maxVerticalRes = 16;
		minVerticalRes = 1;
		maxFieldOfView = 180;
		minFieldOfView = 1;
		maxSampleLength = 10.0f;
		minSampleLength = 1.0f;
		maxCycleLength = 3000;
		minCycleLength = 100;
		maxScanningType = 3; 	//four scanning type options, 0 to 3
		maxDistanceIndicator = 3;
		maxHeightIndicator = 3;
		maxDepthLength = 15;
		minDepthLength = 0;

		/*default configuration settings*/
		frequencyMax = 440.0f;
		frequencyMin = 110.0f;
		horizontalResolution = 32;
		verticalResolution = 16;
		fieldOfView = 90.0f; //converted to float in VAE
		sampleLength = 1.0f;
		cycleLength = 1000;
		scanningType = 0;
		distanceIndicator = 0;
		heightIndicator = 0;
		depthLength = 10;
		vision = false;

		/*default temp configuration settings*/
		tempFrequencyMax = 440.0f;
		tempFrequencyMin = 110.0f;
		tempHorizontalResolution = 32;
		tempVerticalResolution = 16;
		tempFieldOfView = 90.0f; //converted to float in VAE
		tempSampleLength = 1.0f;
		tempCycleLength = 1000;
		tempScanningType = 0;
		tempDistanceIndicator = 0;
		tempHeightIndicator = 0;
		tempDepthLength = 10;
		tempVision = false;

		/*max map settings*/
		maxCubesSpawned = 30;
		maxSpheresSpawned = 30;
		maxCubeMinSize = 3;
		maxCubeMaxSize = 6;
		maxSphereMinSize = 3;
		maxSphereMaxSize = 6;
		maxScanningType = 1; //two scanning type options, 0 or 1

		/*default configuration settings*/
		cubesSpawned = 15;
		spheresSpawned = 15;
		cubeMinSize = 2;
		cubeMaxSize = 4;
		sphereMinSize = 2;
		sphereMaxSize = 4;
		mapSelected = 0;

		/*default temp configuration settings*/
		tempCubesSpawned = 15;
		tempSpheresSpawned = 15;
		tempCubeMinSize = 2;
		tempCubeMaxSize = 4;
		tempSphereMinSize = 2;
		tempSphereMaxSize = 4;
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
		CloseMapSettingsMenu();
		CloseLogsMenu ();
		CloseMoreConfigMenu ();


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
			} else if (MapSettingsMenuIsOpen) {
				CloseMapSettingsMenu ();
				OpenEscapeMenu ();
			} else if (LogsMenuIsOpen) {
				CloseLogsMenu ();
				OpenEscapeMenu ();
			}else if (MoreConfigurationMenuIsOpen){
				CloseMoreConfigMenu ();
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

	/*More Configuration Menu*/
	public void CloseMoreConfigMenu(){
		MoreConfigurationMenuUI.SetActive (false);
		Time.timeScale = 1f;
		MoreConfigurationMenuIsOpen = false;
	}

	public void OpenMoreConfigMenu(){
		MoreConfigurationMenuUI.SetActive (true);
		Time.timeScale = 0f;
		MoreConfigurationMenuIsOpen = true;
		NewConfigurationMenuIsOpen = false;
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
		if (LoadedConfig.savedFrequencyMax >= minFrequency && LoadedConfig.savedFrequencyMax <= maxFrequency)
			frequencyMax = LoadedConfig.savedFrequencyMax;
		else
			Debug.Log ("error: value for 'frequency max' is out of range");

		if (LoadedConfig.savedFrequencyMin >= minFrequency && LoadedConfig.savedFrequencyMin <= maxFrequency)
			frequencyMin = LoadedConfig.savedFrequencyMin;
		else
			Debug.Log ("error: value for 'frequency min' is out of range");

		if(LoadedConfig.savedHorizontalResolution >= minHorizontalRes && LoadedConfig.savedHorizontalResolution <= maxHorizontalRes)
			horizontalResolution = LoadedConfig.savedHorizontalResolution;
		else
			Debug.Log ("error: value for 'horizontal resolution' is out of range");

		if(LoadedConfig.savedVerticalResolution >= minVerticalRes && LoadedConfig.savedVerticalResolution <= maxVerticalRes)
			verticalResolution = LoadedConfig.savedVerticalResolution;
		else
			Debug.Log ("error: value for 'vertical resolution' is out of range");

		if(LoadedConfig.savedFieldOfView >= minFieldOfView && LoadedConfig.savedFieldOfView <= maxFieldOfView)
			fieldOfView = LoadedConfig.savedFieldOfView;
		else
			Debug.Log ("error: value for 'field of view' is out of range");

		if(LoadedConfig.savedSampleLength >= minSampleLength && LoadedConfig.savedSampleLength <= maxSampleLength)
			sampleLength = LoadedConfig.savedSampleLength;
		else
			Debug.Log ("error: value for 'sample length' is out of range");

		if(LoadedConfig.savedCycleLength >= minCycleLength && LoadedConfig.savedCycleLength <= maxCycleLength)
			cycleLength = LoadedConfig.savedCycleLength;
		else
			Debug.Log ("error: value for 'cycle length' is out of range");

		if(LoadedConfig.savedScanningType >= minValue && LoadedConfig.savedScanningType <= maxScanningType)
			scanningType = LoadedConfig.savedScanningType;
		else
			Debug.Log ("error: value for 'scanning type' is out of range");

		if(LoadedConfig.savedDistanceIndicator >= 0 && LoadedConfig.savedDistanceIndicator <= maxDistanceIndicator)
			distanceIndicator = LoadedConfig.savedDistanceIndicator;
		else
			Debug.Log ("error: value for 'distance indicator' is out of range");

		if(LoadedConfig.savedHeightIndicator >= 0 && LoadedConfig.savedHeightIndicator <= maxHeightIndicator)
			heightIndicator = LoadedConfig.savedHeightIndicator;
		else
			Debug.Log ("error: value for 'height indicator' is out of range");

		if(LoadedConfig.savedDepthLength >= minDepthLength && LoadedConfig.savedDepthLength <= maxDepthLength)
			depthLength = LoadedConfig.savedDepthLength;
		else
			Debug.Log ("error: value for 'depth length' is out of range");

		vision = LoadedConfig.savedVision;

		//set all configuration Sliders and Input Fields to loaded configuration values
		FrequencyMaxSlider.value = frequencyMax;
		FrequencyMaxInputField.text = frequencyMax.ToString ();

		FrequencyMinSlider.value = frequencyMin;
		FrequencyMinInputField.text = frequencyMin.ToString ();

		HorizontalResolutionSlider.value = horizontalResolution;
		HorizontalResolutionInputField.text = horizontalResolution.ToString();

		VerticalResolutionSlider.value = verticalResolution;
		VerticalResolutionInputField.text = verticalResolution.ToString ();

		FieldOfViewSlider.value = fieldOfView;
		FieldOfViewInputField.text = fieldOfView.ToString ();

		SampleLengthSlider.value = sampleLength;
		SampleLengthInputField.text = fieldOfView.ToString ();

		CycleLengthSlider.value = cycleLength;
		CycleLengthInputField.text = fieldOfView.ToString ();

		DepthLengthSlider.value = depthLength;
		DepthLengthInputField.text = depthLength.ToString ();

		ScanningTypeDropdown.value = scanningType;

		DistanceIndicatorDropdown.value = distanceIndicator;

		HeightIndicatorDropdown.value = heightIndicator;

		VisionToggle.isOn = vision;
	}

	/*Back Button*/
	public void OnSNAPBackButtonClick(){
		//CloseEscapeMenu ();
		Application.Quit();
	}
	/****************************************************************************************************/


	/********************** Save/Cancel Configurations from Configuration Menu **************************/
	/*When the Save Button is clicked, a new instance of the SaveConfiguration Class is created
	 *and stored in a JSON file
	 */
	private SaveConfigurationSettings CreateConfigurationSave(){
		SaveConfigurationSettings save = new SaveConfigurationSettings ();
		save.savedFrequencyMax = tempFrequencyMax;
		save.savedFrequencyMin = tempFrequencyMin;
		save.savedHorizontalResolution = tempHorizontalResolution;
		save.savedVerticalResolution = tempVerticalResolution;
		save.savedFieldOfView = tempFieldOfView;
		save.savedSampleLength = tempSampleLength;
		save.savedCycleLength = tempCycleLength;
		save.savedScanningType = tempScanningType;
		save.savedDistanceIndicator = tempDistanceIndicator;
		save.savedHeightIndicator = tempHeightIndicator;
		save.savedDepthLength = tempDepthLength;
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


		string json = JsonUtility.ToJson (save, true);
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

		string json = JsonUtility.ToJson (save, true);
		var path = Application.dataPath + "/MapSettings/mapsetting.json";
		if (path.Length != 0) {
			File.WriteAllText (path, string.Empty); //makes sure that the file is empty before writing to it
			StreamWriter writer = new StreamWriter (path, true);
			writer.Write (json);
			writer.Close ();
		}

		cubesSpawned = tempCubesSpawned;
		spheresSpawned = tempSpheresSpawned;
		cubeMinSize = tempCubeMinSize;
		cubeMaxSize = tempCubeMaxSize;
		sphereMinSize = tempSphereMinSize;
		sphereMaxSize = tempSphereMaxSize;
		mapSelected = tempMapSelected;

		CloseMapSettingsMenu();
		OpenEscapeMenu();
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
		FrequencyMaxSlider.value = frequencyMax;
		FrequencyMaxInputField.text = frequencyMax.ToString ();

		FrequencyMinSlider.value = frequencyMin;
		FrequencyMinInputField.text = frequencyMin.ToString ();

		HorizontalResolutionSlider.value = horizontalResolution;
		HorizontalResolutionInputField.text = horizontalResolution.ToString();

		VerticalResolutionSlider.value = verticalResolution;
		VerticalResolutionInputField.text = verticalResolution.ToString ();

		FieldOfViewSlider.value = fieldOfView;
		FieldOfViewInputField.text = fieldOfView.ToString ();

		SampleLengthSlider.value = sampleLength;
		SampleLengthInputField.text = fieldOfView.ToString ();

		CycleLengthSlider.value = cycleLength;
		CycleLengthInputField.text = fieldOfView.ToString ();

		DepthLengthSlider.value = depthLength;
		DepthLengthInputField.text = depthLength.ToString ();

		ScanningTypeDropdown.value = scanningType;

		DistanceIndicatorDropdown.value = distanceIndicator;

		HeightIndicatorDropdown.value = heightIndicator;

		VisionToggle.isOn = vision;

		CloseConfigMenu ();
		CloseMoreConfigMenu ();
		OpenEscapeMenu ();
	}

	public void OnConfigurationBackButtonClick(){
		/* When the Back Button is clicked, set all configurations equal to temporary configurations.
		 * i.e. Remembers the configurations the user changed when they click the Back Button
		 */
		frequencyMax = tempFrequencyMax;
		frequencyMin = tempFrequencyMin;
		horizontalResolution = tempHorizontalResolution;
		verticalResolution = tempVerticalResolution;
		fieldOfView = tempFieldOfView;
		sampleLength = tempSampleLength;
		cycleLength = tempCycleLength;
		scanningType = tempScanningType;
		distanceIndicator = tempDistanceIndicator;
		heightIndicator = tempHeightIndicator;
		depthLength = tempDepthLength;
		vision = tempVision;

		SaveConfigurationSettings save = CreateConfigurationSave (); //saves all the setting

		string json = JsonUtility.ToJson (save, true);
		var path = Application.dataPath + "/bin/config.json"; //save a config file to the bin folder for the VAE to recieve
		string newPath = string.Concat(path);
		if (newPath.Length != 0) {
			File.WriteAllText (path, string.Empty); //makes sure that the file is empty before writing to it
			StreamWriter writer = new StreamWriter (path, true);
			writer.Write (json);
			writer.Close ();
		}

		CloseConfigMenu ();
		OpenEscapeMenu ();
	}

	public void OnConfigurationMoreButtonClick(){
		/* When the "More" button is clicked it takes you to the menu with more configurations*/
		CloseConfigMenu ();
		OpenMoreConfigMenu ();
	}

	public void OnMoreConfigurationBackClick(){
		CloseMoreConfigMenu ();
		OpenConfigMenu ();
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


	/********************************* Frequency Max Configuration ******************************************/
	/*Adjusts the max frequency when the max Frequency Slider is moved*/
	public void AdjustMaxFrequencyFromSlider(){
		tempFrequencyMax = FrequencyMaxSlider.value;
	}

	/*Adjust the max frequency when the max Frequency Input Field is changed*/
	public void AdjustMaxFrequencyFromInputField(){
		tempFrequencyMax = float.Parse(FrequencyMaxInputField.text);
	}

	/*Change the max Frequency Input Field text to match max Frequency Slider value when slider is moved*/
	public void OnMaxFrequencySliderChanged(){
		FrequencyMaxInputField.text = tempFrequencyMax.ToString();
	}

	/*Change the max Frequency Slider value to match max Frequency Input Field when input field is changed*/
	public void OnMaxFrequencyInputFieldChanged(){
		FrequencyMaxSlider.value = tempFrequencyMax;
	}
	/****************************************************************************************************/


	/********************************* Frequency Min Configuration ******************************************/
	/*Adjusts the Min frequency when the Min Frequency Slider is moved*/
	public void AdjustMinFrequencyFromSlider(){
		tempFrequencyMin = FrequencyMinSlider.value;
	}

	/*Adjust the Min frequency when the Min Frequency Input Field is changed*/
	public void AdjustMinFrequencyFromInputField(){
		tempFrequencyMin = float.Parse(FrequencyMinInputField.text);
	}

	/*Change the Min Frequency Input Field text to match Min Frequency Slider value when slider is moved*/
	public void OnMinFrequencySliderChanged(){
		FrequencyMinInputField.text = tempFrequencyMin.ToString();
	}

	/*Change the max Frequency Slider value to match max Frequency Input Field when input field is changed*/
	public void OnMinFrequencyInputFieldChanged(){
		FrequencyMinSlider.value = tempFrequencyMin;
	}
	/****************************************************************************************************/


	/********************************* Horizontal Resolution Configuration ******************************************/
	/*Adjusts the Horizontal Resolution when the Horizontal Resolution Slider is moved*/
	public void AdjustHorizontalResolutionFromSlider(){
		tempHorizontalResolution = (int)HorizontalResolutionSlider.value;
	}

	/*Adjust the HorizontalResolution when the HorizontalResolution Input Field is changed*/
	public void AdjustHorizontalResolutionFromInputField(){
		tempHorizontalResolution = int.Parse(HorizontalResolutionInputField.text);
	}

	/*Change the HorizontalResolution Input Field text to match HorizontalResolution Slider value when slider is moved*/
	public void OnHorizontalResolutionSliderChanged(){
		HorizontalResolutionInputField.text = tempHorizontalResolution.ToString();
	}

	/*Change the HorizontalResolution Slider value to match HorizontalResolution Input Field when input field is changed*/
	public void OnHorizontalResolutionInputFieldChanged(){
		HorizontalResolutionSlider.value = tempHorizontalResolution;
	}
	/****************************************************************************************************/


	/********************************* Vertical Resolution Configuration ******************************************/
	/*Adjusts the Vertical Resolution when the Vertical Resolution Slider is moved*/
	public void AdjustVerticalResolutionFromSlider(){
		tempVerticalResolution = (int)VerticalResolutionSlider.value;
	}

	/*Adjust the VerticalResolution when the VerticalResolution Input Field is changed*/
	public void AdjustVerticalResolutionFromInputField(){
		tempVerticalResolution = int.Parse(VerticalResolutionInputField.text);
	}

	/*Change the Vertical Resolution Input Field text to match Vertical Resolution Slider value when slider is moved*/
	public void OnVerticalResolutionSliderChanged(){
		VerticalResolutionInputField.text = tempVerticalResolution.ToString();
	}

	/*Change the Vertical Resolution Slider value to match Vertical Resolution Input Field when input field is changed*/
	public void OnVerticalResolutionInputFieldChanged(){
		VerticalResolutionSlider.value = tempVerticalResolution;
	}
	/****************************************************************************************************/


	/********************************* Field of View Configuration ******************************************/
	/*Adjusts the Vertical Resolution when the Vertical Resolution Slider is moved*/
	public void AdjustFieldOfViewFromSlider(){
		tempFieldOfView = FieldOfViewSlider.value;
	}

	/*Adjust the VerticalResolution when the VerticalResolution Input Field is changed*/
	public void AdjustFieldOfViewFromInputField(){
		tempFieldOfView = float.Parse(FieldOfViewInputField.text);
	}

	/*Change the Vertical Resolution Input Field text to match Vertical Resolution Slider value when slider is moved*/
	public void OnFieldOfViewSliderChanged(){
		FieldOfViewInputField.text = tempFieldOfView.ToString();
	}

	/*Change the Vertical Resolution Slider value to match Vertical Resolution Input Field when input field is changed*/
	public void OnFieldOfViewInputFieldChanged(){
		FieldOfViewSlider.value = tempFieldOfView;
	}
	/****************************************************************************************************/


	/********************************* Sample Length Configuration ******************************************/
	/*Adjusts the Vertical Resolution when the Vertical Resolution Slider is moved*/
	public void AdjustSampleLengthFromSlider(){
		tempSampleLength = SampleLengthSlider.value;
	}

	/*Adjust the VerticalResolution when the VerticalResolution Input Field is changed*/
	public void AdjustSampleLengthFromInputField(){
		tempSampleLength = float.Parse(SampleLengthInputField.text);
	}

	/*Change the Vertical Resolution Input Field text to match Vertical Resolution Slider value when slider is moved*/
	public void OnSampleLengthSliderChanged(){
		SampleLengthInputField.text = tempSampleLength.ToString();
	}

	/*Change the Vertical Resolution Slider value to match Vertical Resolution Input Field when input field is changed*/
	public void OnSampleLengthInputFieldChanged(){
		SampleLengthSlider.value = tempSampleLength;
	}
	/****************************************************************************************************/


	/********************************* Cycle Length Configuration ******************************************/
	/*Adjusts the Vertical Resolution when the Vertical Resolution Slider is moved*/
	public void AdjustCycleLengthFromSlider(){
		tempCycleLength = (int)CycleLengthSlider.value;
	}

	/*Adjust the VerticalResolution when the VerticalResolution Input Field is changed*/
	public void AdjustCycleLengthFromInputField(){
		tempCycleLength = int.Parse(CycleLengthInputField.text);
	}

	/*Change the Vertical Resolution Input Field text to match Vertical Resolution Slider value when slider is moved*/
	public void OnCycleLengthSliderChanged(){
		CycleLengthInputField.text = tempCycleLength.ToString();
	}

	/*Change the Vertical Resolution Slider value to match Vertical Resolution Input Field when input field is changed*/
	public void OnCycleLengthInputFieldChanged(){
		CycleLengthSlider.value = tempCycleLength;
	}
	/****************************************************************************************************/


	/********************************* Depth Length Configuration ******************************************/
	/*Adjusts the Vertical Resolution when the Vertical Resolution Slider is moved*/
	public void AdjustDepthLengthFromSlider(){
		tempDepthLength = (int)DepthLengthSlider.value;
	}

	/*Adjust the VerticalResolution when the VerticalResolution Input Field is changed*/
	public void AdjustDepthLengthFromInputField(){
		tempDepthLength = int.Parse(DepthLengthInputField.text);
	}

	/*Change the Vertical Resolution Input Field text to match Vertical Resolution Slider value when slider is moved*/
	public void OnDepthLengthSliderChanged(){
		DepthLengthInputField.text = tempDepthLength.ToString();
	}

	/*Change the Vertical Resolution Slider value to match Vertical Resolution Input Field when input field is changed*/
	public void OnDepthLengthInputFieldChanged(){
		DepthLengthSlider.value = tempDepthLength;
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


	/******************************************* Distance Indicator ******************************************/
	public void AdjustDistanceIndicatorDropdown(){
		tempDistanceIndicator = DistanceIndicatorDropdown.value;
	}

	public void OnDistanceIndicatorDropdownClicked(){
		DistanceIndicatorDropdown.value = tempDistanceIndicator;
	}
	/****************************************************************************************************/


	/******************************************* Height Indicator ******************************************/
	public void AdjustHeightIndicatorDropdown(){
		tempHeightIndicator = HeightIndicatorDropdown.value;
	}

	public void OnHeightIndicatorDropdownClicked(){
		HeightIndicatorDropdown.value = tempHeightIndicator;
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
