using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class RandomHallwayMenuUI : MonoBehaviour {

	public static bool EscapeMenuIsOpen;
	public static bool TestCompleteMenuIsOpen;
	public GameObject MenuUI;
	public GameObject TestCompleteMenuUI;
	public Transform FPSControllerObject;

	void Start(){
		EscapeMenuIsOpen = false;
		TestCompleteMenuIsOpen = false;
		CloseEscapeMenu ();
		CloseTestCompleteMenu ();
	}

	// Update is called once per frame
	void Update () {
		/* Open/Close SNAP Sub Menu when Escape is pressed */
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!TestCompleteMenuIsOpen) {
				if (EscapeMenuIsOpen) {
					CloseEscapeMenu ();
				} else {
					OpenEscapeMenu ();
				}
			}
		}
	}

	/********************************* Open/Close SNAP Sub Menu ******************************************/
	public void CloseEscapeMenu(){
		MenuUI.SetActive (false);
		Time.timeScale = 1f;
		EscapeMenuIsOpen = false;
		/*Activate the FPS Controller*/
		FPSControllerObject.GetComponent<FirstPersonController> ().enabled = true;
	}

	public void OpenEscapeMenu(){
		MenuUI.SetActive (true);
		Time.timeScale = 0f;
		EscapeMenuIsOpen = true;
		/*Disable the FPS Controller so we can use the menu without moving in the environment*/
		FPSControllerObject.GetComponent<FirstPersonController> ().enabled = false;
		/*Makes the cursor visible after pausing the test*/
		Cursor.visible = true;
		/*Unlocks the cursor from the FPS Controller so the cursor can move around in our menu*/
		Cursor.lockState = CursorLockMode.None;
	}

	/*Resume Button*/
	public void OnSNAPResumeButtonClicked(){
		CloseEscapeMenu ();
	}

	/*Quit Test Button Clicked*/
	public void OnSNAPQuitButtonClicked(){
		LoadMainMenu ();
	}
	/*****************************************************************************************************/


	/************************************* Test Complete Menu ********************************************/
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

	public void CloseTestCompleteMenu(){
		TestCompleteMenuUI.SetActive (false);
		Time.timeScale = 1f;
		TestCompleteMenuIsOpen = false;
	}

	public void OnMainMenuButtonClicked(){
		LoadMainMenu ();
	}

	public void OnNewTestButtonClicked(){
		ReloadHallwayRandomObjectsScene ();
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
	public void ReloadHallwayRandomObjectsScene(){
		/*Readloads the "Random Hallway Map" scene. (Assets->Scenes->Random Hallway Map)*/
		SceneManager.LoadScene ("Random Hallway Map", LoadSceneMode.Single);
	}
	/*****************************************************************************************************/
}
