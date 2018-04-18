using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class SubMenuUI : MonoBehaviour {

	public static bool EscapeMenuIsOpen;
	public static bool TestCompleteMenuIsOpen;
	public GameObject pauseMenu;
	public GameObject testCompleteMenuUI;
	public Transform FPSControllerObject;
	public string sceneName;

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
		pauseMenu.SetActive (false);
		Time.timeScale = 1f;
		EscapeMenuIsOpen = false;
		/*Activate the FPS Controller*/
		FPSControllerObject.GetComponent<FirstPersonController> ().enabled = true;
	}

	public void OpenEscapeMenu(){
		pauseMenu.SetActive (true);
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
		testCompleteMenuUI.SetActive (true);
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
		testCompleteMenuUI.SetActive (false);
		Time.timeScale = 1f;
		TestCompleteMenuIsOpen = false;
	}

	public void OnMainMenuButtonClicked(){
		LoadMainMenu ();
	}

	public void OnNewTestButtonClicked(){
		ReloadScene ();
	}
	/*****************************************************************************************************/


	/***************************************** Load Main Menu ********************************************/
	public void LoadMainMenu(){
		/*Changes to "Main Menu" Scene. (Assets -> Scenes -> Main Menu)*/
		TestCompleteMenuIsOpen = false;
		EscapeMenuIsOpen = false;
		SceneManager.LoadScene ("Menu/Main Menu", LoadSceneMode.Single);
	}
	/*****************************************************************************************************/



	/****************************************** Reload Scene *********************************************/
	public void ReloadScene(){
		SceneManager.LoadScene (sceneName, LoadSceneMode.Single);
	}
	/*****************************************************************************************************/
}
