using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandlerN : MonoBehaviour {
	public int lives;
	public GameObject Normal;
	public GameObject Fast;
	public GameObject Slow;
	public GameObject Armor;
	public GameObject Boss;
	// Use this for initialization
	void Start () {
		lives = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startRound() {
		InvokeRepeating("SpawnEnemy", 0, 1);
	}

	void SpawnEnemy() {
		SpawnZones.spawnEnemy (Normal);
	}

	public void loseLife() {
		lives--;
		GameObject.Find ("Lives").GetComponent<Text> ().text = "Lives: " + lives;
		if (lives == 0) {
			GameOver ();
		}
	}

	public void GameOver() {
		SceneManager.LoadSceneAsync (1);
	}
}
