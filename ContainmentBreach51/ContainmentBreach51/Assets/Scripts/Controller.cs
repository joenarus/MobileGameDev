using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

	public Dictionary<string,int> UnlockedTowers; //Stores Towers available to the player and their level
	public List<Canvas> canvases; 
	public Text Level;
	public Text Currency;
	public Text Stamina;
	public Text Exp;
	public Text LevelText;
	public bool init = false;
	bool updated = false;
	GameObject player;
	private int active_agent;

	// Use this for initialization
	void Start () {
		active_agent = 0;
		player = GameObject.Find ("PlayerInfo");
		LevelText.text = "" + player.GetComponent<Player> ().realPlayer.Agent1;
		if (!init) {
			init = true;
			updated = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (updated) {
			Level.text = "Level: " + player.GetComponent<Player> ().realPlayer.Level;
			Currency.text = "Gold: " + player.GetComponent<Player> ().realPlayer.Currency;
			Stamina.text = "Stamina: " + player.GetComponent<Player> ().realPlayer.Stamina;
			Exp.text = "Exp: " + player.GetComponent<Player> ().realPlayer.Exp;
			LevelText.text = "" + player.GetComponent<Player> ().realPlayer.Agent1;
			player.GetComponent<Player> ().updateData ();
			updated = false;
		}
	}

	public void activateShop() {
		foreach (Canvas c in canvases) {
			if (c.name != "TowerCanvas") {
				c.gameObject.SetActive (false);
			} else {
				c.gameObject.SetActive (true);
			}
		}
	}

	public void activateUpgradeMenu(int x) {
		
		foreach (Canvas c in canvases) {
			if (c.name != "UpgradeCanvas") {
				c.gameObject.SetActive (false);
			} else {
				c.gameObject.SetActive (true);
			}
		}


		if (x == 1) {
			LevelText.text = "" + player.GetComponent<Player> ().realPlayer.Agent1;
			active_agent = 1;
		}
		else if(x == 2) {
			LevelText.text = "" + player.GetComponent<Player> ().realPlayer.Agent2;
			active_agent = 2;
		}

		else if(x == 3) {
			LevelText.text = "" + player.GetComponent<Player> ().realPlayer.Agent3;
			active_agent = 3;
		}

		else if(x == 4) {
			LevelText.text = "" + player.GetComponent<Player> ().realPlayer.Agent4;
			active_agent = 4;
		}
	}

	public void activateBattleMenu() {
		foreach (Canvas c in canvases) {
			if (c.name != "BattleCanvas") {
				c.gameObject.SetActive (false);
			} else {
				c.gameObject.SetActive (true);
			}
		}
	}
	public void Battle() {
		player.GetComponent<Player> ().realPlayer.Stamina--;
		updated = true;
		DontDestroyOnLoad (gameObject);
		SceneManager.LoadSceneAsync (2);
	}

	public void UpgradeTower(string x) {
		if (player.GetComponent<Player> ().realPlayer.Currency >= 5) {
//			
			player.GetComponent<Player> ().realPlayer.Currency -= 5;
		}
	}
}
