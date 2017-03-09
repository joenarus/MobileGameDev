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
	public Text Tower1;
	public Text Tower2;
	public Text Tower3;
	public bool init = false;
	bool updated = false;
	GameObject player;

	// Use this for initialization
	void Start () {
		
		player = GameObject.Find ("PlayerInfo");
		Tower1.text = "" + player.GetComponent<Player> ().realPlayer.TowerN;
		Tower2.text = "" + player.GetComponent<Player> ().realPlayer.TowerS;
		Tower3.text = "" + player.GetComponent<Player> ().realPlayer.TowerF;
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
			Tower1.text = "" + player.GetComponent<Player> ().realPlayer.TowerN;
			Tower2.text = "" + player.GetComponent<Player> ().realPlayer.TowerS;
			Tower3.text = "" + player.GetComponent<Player> ().realPlayer.TowerF;
			player.GetComponent<Player> ().updateData ();
			updated = false;
		}
	}

	public void activateShop() {
		foreach (Canvas c in canvases) {
			if (c.name != "PurchaseCanvas") {
				c.gameObject.SetActive (false);
			} else {
				c.gameObject.SetActive (true);
			}
		}
	}

	public void activateUpgradeMenu() {
		foreach (Canvas c in canvases) {
			if (c.name != "UpgradeCanvas") {
				c.gameObject.SetActive (false);
			} else {
				c.gameObject.SetActive (true);
			}
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
			int temp = 0;
			if (x.Equals ("normal")) {
				player.GetComponent<Player> ().realPlayer.TowerN+=1;
				Tower1.text = ""+ player.GetComponent<Player> ().realPlayer.TowerN;
			
			} else if (x.Equals ("slow")) {
				player.GetComponent<Player> ().realPlayer.TowerS+=1;
				Tower2.text = ""+ player.GetComponent<Player> ().realPlayer.TowerS;
			} else if (x.Equals ("fast")) {
				player.GetComponent<Player> ().realPlayer.TowerF+=1;
				Tower3.text = ""+ player.GetComponent<Player> ().realPlayer.TowerF;
			}
			updated = true;
			player.GetComponent<Player> ().realPlayer.Currency -= 5;
		}
	}
}
