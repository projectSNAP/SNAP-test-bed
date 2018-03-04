using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class DynamicMapMenuUI : MonoBehaviour {

	public static bool EscapeMenuIsOpen;
	public GameObject MenuUI;
	public static bool TestCompleteMenuIsOpen;
	public GameObject TestCompleteMenuUI;
	public GameObject FPSControllerObject;

	void Start(){
		EscapeMenuIsOpen = false;
		TestCompleteMenuIsOpen = false;
		CloseEscapeMenu ();
	}

	// Update is called once per frame
	void Update () {
		/* Open/Close SNAP Sub Menu when Escape is pressed */
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (EscapeMenuIsOpen) {
				CloseEscapeMenu ();
			} else {
				OpenEscapeMenu ();
			}
		}
	}

	/********************************* Open/Close SNAP Sub Menu ******************************************/
	public void CloseEscapeMenu(){
		MenuUI.SetActive (false);
		Time.timeScale = 1f;
		EscapeMenuIsOpen = false;
	}

	public void OpenEscapeMenu(){
		MenuUI.SetActive (true);
		Time.timeScale = 0f;
		EscapeMenuIsOpen = true;
	}

	/*Resume Button*/
	public void OnSNAPResumeButtonClicked(){
		CloseEscapeMenu ();
	}

	/*Quit Test Button Clicked*/
	public void OnSNAPQuitButtonClicked(){
		/*Changes to "Main Menu" Scene. (Assets -> Scenes -> Main Menu)*/
		EscapeMenuIsOpen = false;
		//MenuUI.SetActive (false);
		SceneManager.LoadScene ("Main Menu", LoadSceneMode.Single);
	}
	/*****************************************************************************************************/



	/************************************** Test Complete Menu ******************************************/

	public void CloseTestCompleteMenu(){
		TestCompleteMenuUI.SetActive (false);
		Time.timeScale = 1f;
		TestCompleteMenuIsOpen = false;
	}

	public void OpenTestCompleteMenu(){
		TestCompleteMenuUI.SetActive (true);
		Time.timeScale = 0f;
		TestCompleteMenuIsOpen = true;
		/*Disables the FPS Controller so we can use our Test Complete Menu without moving around in the environment*/
		FPSControllerObject.GetComponent<FirstPersonController> ().enabled = false;
		/*Makes the cursor visible*/
		Cursor.visible = true;
		/*Unlocks the cursor from the FPS Controller so the cursor can move around in our menu*/
		Cursor.lockState = CursorLockMode.None;
	}

	public void OnMainMenuButtonClicked(){
		LoadMainMenu ();
	}

	public void OnNewTestButtonClicked(){
		ReloadHallwayDynamicScene ();
	}
	/*****************************************************************************************************/


	/***************************************** Load Main Menu ********************************************/
	public void LoadMainMenu(){
		/*Changes to "Main Menu" Scene. (Assets -> Scenes -> Main Menu)*/
		TestCompleteMenuIsOpen = false;
		EscapeMenuIsOpen = false;
		SceneManager.LoadScene ("Main Menu", LoadSceneMode.Single);
	}
	/*****************************************************************************************************/



	/****************************************** Reload Scene *********************************************/
	public void ReloadHallwayDynamicScene(){
		/*Readloads the "Dynamic Map" scene. (Assets->Scenes->Dynamic Map)*/
		SceneManager.LoadScene ("Dynamic Map", LoadSceneMode.Single);
	}
	/*****************************************************************************************************/
}
