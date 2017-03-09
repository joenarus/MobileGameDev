using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

	public Canvas credits;
	public Canvas main;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}


	public void newGame() {
		SceneManager.LoadSceneAsync (1);
	}

	public void activateCredits() {
		main.gameObject.SetActive (false);
		credits.gameObject.SetActive (true);
	}

	public void activateMain() {
		main.gameObject.SetActive (true);
		credits.gameObject.SetActive (false);
	}

}



