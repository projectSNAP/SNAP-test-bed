using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomHallwayMenuUI : MonoBehaviour {

	public static bool EscapeMenuIsOpen;
	public static bool TestCompleteMenuIsOpen;
	public GameObject MenuUI;
	public GameObject TestCompleteMenuUI;

	void Start(){
		EscapeMenuIsOpen = false;
		TestCompleteMenuIsOpen = false;
		CloseEscapeMenu ();
	}

	// Update is called once per frame
	void Update () {
		/* Open/Close SNAP Sub Menu when Escape is pressed */
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!TestCompleteMenuIsOpen) {
				if (EscapeMenuIsOpen) {
					CloseEscapeMenu ();
					Cursor.visible = false;
				} else {
					OpenEscapeMenu ();
					Cursor.visible = true;
				}
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
		LoadMainMenu ();
	}
	/*****************************************************************************************************/


	/************************************* Test Complete Menu ********************************************/
	public void OpenTestCompleteMenu(){
		TestCompleteMenuUI.SetActive (true);
		Time.timeScale = 0f;
		TestCompleteMenuIsOpen = true;
	}

	public void CloseTestCompleteMenu(){
		TestCompleteMenuUI.SetActive (false);
		Time.timeScale = 1f;
		TestCompleteMenuIsOpen = false;
	}

	public void OnMainMenuButtonClicked(){
		LoadMainMenu ();
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
}
