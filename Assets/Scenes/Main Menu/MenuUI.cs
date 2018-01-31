using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary; //Used for saving configuration files
using System.IO; //Lets us read/write to save files
using UnityEngine.SceneManagement;
using UnityEditor;


[System.Serializable]

public class MenuUI : MonoBehaviour {

	public static bool EscapeMenuIsOpen = false;
	public static bool NewConfigurationMenuIsOpen = false;
	public GameObject ConfigurationMenuUI;
	public GameObject EscapeMenuUI;

	public float frequency;
	public float tempFrequency;
	public UnityEngine.UI.Slider FrequencySlider;
	public UnityEngine.UI.InputField FrequencyInputField;

	public float frequencyIncrement;
	public float tempFrequencyIncrement;
	public UnityEngine.UI.Slider FrequencyIncrementSlider;
	public UnityEngine.UI.InputField FrequencyIncrementInputField;

	public float horizontalSteps;
	public float tempHorizontalSteps;
	public UnityEngine.UI.Slider HorizontalStepsSlider;
	public UnityEngine.UI.InputField HorizontalStepsInputField;

	public float stepDelay;
	public float tempStepDelay;
	public UnityEngine.UI.Slider StepDelaySlider;
	public UnityEngine.UI.InputField StepDelayInputField;

	public float audioSpreadDegree;
	public float tempAudioSpreadDegree;
	public UnityEngine.UI.Slider AudioSpreadDegreeSlider;
	public UnityEngine.UI.InputField AudioSpreadDegreeInputField;

	public float audioVolumeRollOff;
	public float tempAudioVolumeRollOff;
	public UnityEngine.UI.Slider AudioVolumeRollOffSlider;
	public UnityEngine.UI.InputField AudioVolumeRollOffInputField;


	// Use this for initialization
	void Start () {
		/*default configuration settings*/
		frequency = 25f;
		frequencyIncrement = 5f;
		horizontalSteps = 5f;
		stepDelay = 5f;
		audioSpreadDegree = 45f;
		audioVolumeRollOff = 25f;

		/*default temp configuration settings*/
		tempFrequency = 25f;
		tempFrequencyIncrement = 5f;
		tempHorizontalSteps = 5f;
		tempStepDelay = 5f;
		tempAudioSpreadDegree = 45f;
		tempAudioVolumeRollOff = 25f;
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
		
	public void CloseConfigMenu(){
		ConfigurationMenuUI.SetActive (false);
		Time.timeScale = 1f;
		NewConfigurationMenuIsOpen = false;
	}
	/**************************/

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
		var path = UnityEditor.EditorUtility.OpenFilePanel ("Load configuration", "", "json");
		string json = File.ReadAllText (path);
		SaveConfigurationSettings LoadedConfig;
		LoadedConfig = JsonUtility.FromJson<SaveConfigurationSettings> (json);

		/*set all configuration settings to loaded configurations*/
		frequency = LoadedConfig.savedFrequency;
		frequencyIncrement = LoadedConfig.savedFrequencyIncrement;
		horizontalSteps = LoadedConfig.savedHorizontalSteps;
		stepDelay = LoadedConfig.savedStepDelay;
		audioSpreadDegree = LoadedConfig.savedAudioSpreadDegree;
		audioVolumeRollOff = LoadedConfig.savedAudioVolumeRollOff;

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
		var path = UnityEditor.EditorUtility.SaveFilePanel ("Save configuration", "", "newconfig","json");

		if (path.Length != 0) {
			File.WriteAllText (path, string.Empty); /*makes sure that the file is empty before writing to it*/
			StreamWriter writer = new StreamWriter (path, true);
			writer.Write (json);
			writer.Close ();
		}
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

		CloseConfigMenu ();
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

		CloseConfigMenu ();
		OpenEscapeMenu ();
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

}
