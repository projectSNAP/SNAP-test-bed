using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour {

	public static bool EscapeMenuIsOpen = false;
	public static bool NewConfigurationMenuIsOpen = false;
	public GameObject ConfigurationMenuUI;
	public GameObject EscapeMenuUI;

	public float frequency;
	public UnityEngine.UI.Slider FrequencySlider;
	public UnityEngine.UI.InputField FrequencyInputField;

	public float frequencyIncrement;
	public UnityEngine.UI.Slider FrequencyIncrementSlider;
	public UnityEngine.UI.InputField FrequencyIncrementInputField;

	public float horizontalSteps;
	public UnityEngine.UI.Slider HorizontalStepsSlider;
	public UnityEngine.UI.InputField HorizontalStepsInputField;

	public float stepDelay;
	public UnityEngine.UI.Slider StepDelaySlider;
	public UnityEngine.UI.InputField StepDelayInputField;

	public float audioSpreadDegree;
	public UnityEngine.UI.Slider AudioSpreadDegreeSlider;
	public UnityEngine.UI.InputField AudioSpreadDegreeInputField;

	public float audioVolumeRollOff;
	public UnityEngine.UI.Slider AudioVolumeRollOffSlider;
	public UnityEngine.UI.InputField AudioVolumeRollOffInputField;


	// Use this for initialization
	void Start () {
		frequency = 25f;
		frequencyIncrement = 10f;
		horizontalSteps = 10f;
		stepDelay = 10f;
		audioSpreadDegree = 45f;
		audioVolumeRollOff = 50f;
	}
	
	// Update is called once per frame
	void Update () {
		/* Open/Close menus when Escape is pressed */
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

	/************************************** Open/Close Menus ******************************************/
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

	public void OpenConfigMenu(){
		ConfigurationMenuUI.SetActive (true);
		Time.timeScale = 0f;
		NewConfigurationMenuIsOpen = true;
		EscapeMenuIsOpen = false;
	}
	/****************************************************************************************************/


	/********************************* Frequency Configuration ******************************************/
	/*Adjusts the frequency when the Frequency Slider is moved*/
	public void AdjustFrequencyFromSlider(){
		frequency = FrequencySlider.value;
	}

	/*Adjust the frequency when the Frequency Input Field is changed*/
	public void AdjustFrequencyFromInputField(){
		frequency = float.Parse(FrequencyInputField.text);
	}

	/*Change the Frequency Input Field text to match Frequency Slider value when slider is moved*/
	public void OnFrequencySliderChanged(){
		FrequencyInputField.text = frequency.ToString();
	}

	/*Change the Frequency Slider value to match Frequency Input Field when input field is changed*/
	public void OnFrequencyInputFieldChanged(){
		FrequencySlider.value = frequency;
	}
	/****************************************************************************************************/


	/******************************** Frequency Increment Configuration *********************************/
	/*Adjusts the frequency increment when the Frequency Increment Slider is moved*/
	public void AdjustFrequencyIncrementFromSlider(){
		frequencyIncrement = FrequencyIncrementSlider.value;
	}

	/*Adjust the frequency increment when the Frequency Increment Input Field is changed*/
	public void AdjustFrequencyIncrementFromInputField(){
		frequencyIncrement = float.Parse (FrequencyIncrementInputField.text);
	}

	/*Change the Frequency Increment Input Field text to match Frequency Increment Slider value when slider is moved*/
	public void OnFrequencyIncrementSliderChanged(){
		FrequencyIncrementInputField.text = frequencyIncrement.ToString();
	}

	/*Change the Frequency Increment Slider value to match Frequency Increment Input Field when input field is changed*/
	public void OnFrequencyIncrementInputFieldChanged(){
		FrequencyIncrementSlider.value = frequencyIncrement;
	}
	/****************************************************************************************************/


	/**************************************** Horizontal Steps *****************************************/
	/*Adjusts the horizontal steps when the Horizontal Steps Slider is moved*/
	public void AdjustHorizontalStepsFromSlider(){
		horizontalSteps = HorizontalStepsSlider.value;
	}

	/*Adjust the horizontal steps when the Horizontal Steps Input Field is changed*/
	public void AdjustHorizontalStepsFromInputField(){
		horizontalSteps = float.Parse (HorizontalStepsInputField.text);
	}

	/*Change the Horizontal Steps Input Field text to match Horizontal Steps Slider value when slider is moved*/
	public void OnHorizontalStepsSliderChanged(){
		HorizontalStepsInputField.text = horizontalSteps.ToString();
	}

	/*Change the Horizontal Steps Slider value to match Horizontal Steps Input Field when input field is changed*/
	public void OnHorizontalStepsInputFieldChanged(){
		HorizontalStepsSlider.value = horizontalSteps;
	}
	/****************************************************************************************************/


	/******************************************** Step Delay ********************************************/
	/*Adjusts the step delay when the Step Delay Slider is moved*/
	public void AdjustStepDelayFromSlider(){
		stepDelay = StepDelaySlider.value;
	}

	/*Adjust the step delay when the Step Delay Input Field is changed*/
	public void AdjustStepDelayFromInputField(){
		stepDelay = float.Parse (StepDelayInputField.text);
	}

	/*Change the step delay Input Field text to match Step Delay Slider value when slider is moved*/
	public void OnStepDelaySliderChanged(){
		StepDelayInputField.text = stepDelay.ToString();
	}

	/*Change the step delay Slider value to match Step Delay Input Field when input field is changed*/
	public void OnStepDelayInputFieldChanged(){
		StepDelaySlider.value = stepDelay;
	}
	/****************************************************************************************************/


	/**************************************** Audio Spread Degree ***************************************/
	/*Adjusts the audio spread degree when the Audio Spread Degree Slider is moved*/
	public void AdjustAudioSpreadDegreeFromSlider(){
		audioSpreadDegree = AudioSpreadDegreeSlider.value;
	}

	/*Adjust the audio spread degree when the Audio Spread Degree Input Field is changed*/
	public void AdjustAudioSpreadDegreeFromInputField(){
		audioSpreadDegree = float.Parse (AudioSpreadDegreeInputField.text);
	}

	/*Change the audio spread degree Input Field text to match Audio Spread Degree Slider value when slider is moved*/
	public void OnAudioSpreadDegreeSliderChanged(){
		AudioSpreadDegreeInputField.text = audioSpreadDegree.ToString();
	}

	/*Change the audio spread degree Slider value to match Audio Spread Degree Input Field when input field is changed*/
	public void OnAudioSpreadDegreeInputFieldChanged(){
		AudioSpreadDegreeSlider.value = audioSpreadDegree;
	}
	/****************************************************************************************************/


	/*************************************** Audio Volume Roll-off **************************************/
	/*Adjusts the audio volume roll-off when the Audio Volume Roll-off Slider is moved*/
	public void AdjustAudioVolumeRollOffFromSlider(){
		audioVolumeRollOff = AudioVolumeRollOffSlider.value;
	}

	/*Adjust the audio volume roll-off when the Audio Volume Roll-off Input Field is changed*/
	public void AdjustAudioVolumeRollOffFromInputField(){
		audioVolumeRollOff = float.Parse (AudioVolumeRollOffInputField.text);
	}

	/*Change the audio volume roll-off Input Field text to match Audio Volume Roll-off Slider value when slider is moved*/
	public void OnAudioVolumeRollOffSliderChanged(){
		AudioVolumeRollOffInputField.text = audioVolumeRollOff.ToString();
	}

	/*Change the audio volume roll-off Slider value to match Audio Volume Roll-off Input Field when input field is changed*/
	public void OnAudioVolumeRollOffInputFieldChanged(){
		AudioVolumeRollOffSlider.value = audioVolumeRollOff;
	}
	/****************************************************************************************************/
}
