using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomHallwayMenuUI : MonoBehaviour {
	
	public static bool EscapeMenuIsOpen = false;
	public GameObject MenuUI;

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
		SceneManager.LoadScene ("Main Menu", LoadSceneMode.Single);
	}
	/*****************************************************************************************************/
}
