using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class Controller : MonoBehaviour {

	public List<Canvas> canvases; 
	public Text Level;
	public Text Currency;
	public Text Stamina;
	public Text Exp;
	public Text LevelText;
	public Text StaminaTime;
	public Slider expSlider;
	public Slider staminaSlider;
	public Button LevelTower;
	public Button LevelAbility;
	public Button LevelPassive;
	public UpgradeController upgrader;
	Tower activeTower;
	public InfoHolder holder;
	public bool init = false;
	bool updated = false;
	public static bool towerUpdate = false;
	GameObject player;
	private int active_agent;
	long lockTime = 0;

	bool staminaUsed = false; 
	// Use this for initialization
	void Start () {
		active_agent = 0;
		holder = GameObject.Find ("InfoHolder").GetComponent<InfoHolder> ();
		player = GameObject.Find ("PlayerInfo");
		if (!init) {
			init = true;
			updated = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (updated) {
			Level.text = "" + player.GetComponent<Player> ().realPlayer.Level;
			Currency.text = "" + player.GetComponent<Player> ().realPlayer.Currency;
			Stamina.text = "" + player.GetComponent<Player> ().realPlayer.Stamina + " / " + player.GetComponent<Player> ().MaxStamina;
			staminaSlider.maxValue = player.GetComponent<Player> ().MaxStamina;
			staminaSlider.value = player.GetComponent<Player> ().realPlayer.Stamina;
			Exp.text = "" + player.GetComponent<Player> ().realPlayer.Exp + " / 100";
			expSlider.value =  player.GetComponent<Player> ().realPlayer.Exp;
			updated = false;
			if (player.GetComponent<Player> ().realPlayer.Exp >= 100) {
				LevelUp ();
			}
		}
	}

	public bool useStamina()
	{
		if (player.GetComponent<Player> ().realPlayer.Stamina > 0) {
			staminaUsed = true;
			lockTime = System.DateTime.Now.Ticks;
			player.GetComponent<Player> ().realPlayer.Stamina--;
			return true;
		} else {
			player.GetComponent<Player> ().realPlayer.Stamina = player.GetComponent<Player> ().MaxStamina;
		}
		return false;
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
			activeTower = holder.towers ["Agent 1"];

			active_agent = 1;
		}
		else if(x == 2) {
			activeTower = holder.towers ["Agent 2"];
			active_agent = 2;
		}

		else if(x == 3) {
			activeTower = holder.towers ["Agent 3"];
			active_agent = 3;
		}

		else if(x == 4) {
			activeTower = holder.towers ["Agent 4"];
			active_agent = 4;
		}
		upgrader.updateTower (activeTower);
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
		if (useStamina()) {

			updated = true;
			SceneManager.LoadSceneAsync (2);
		} else {
			//Do shit
			return;
		}
	}

	public void UpgradeTower(string x) {

		if (x.Equals ("level")) {
			activeTower.level++;
			if(activeTower.entity_name.Equals("Agent 1")) {
				player.GetComponent<Player> ().realPlayer.Agent1++;
			}
			else if(activeTower.entity_name.Equals("Agent 2")) {
				player.GetComponent<Player> ().realPlayer.Agent2++;
			}
			else if(activeTower.entity_name.Equals("Agent 3")) {
				player.GetComponent<Player> ().realPlayer.Agent3++;
			}
			else if(activeTower.entity_name.Equals("Agent 4")) {
				player.GetComponent<Player> ().realPlayer.Agent4++;
			}
		}
		else if (x.Equals ("passive")) {
			activeTower.passive.Level++;
			if(activeTower.entity_name.Equals("Agent 1")) {
				player.GetComponent<Player> ().realPlayer.Passive1++;
			}
			else if(activeTower.entity_name.Equals("Agent 2")) {
				player.GetComponent<Player> ().realPlayer.Passive2++;
			}
			else if(activeTower.entity_name.Equals("Agent 3")) {
				player.GetComponent<Player> ().realPlayer.Passive3++;
			}
			else if(activeTower.entity_name.Equals("Agent 4")) {
				player.GetComponent<Player> ().realPlayer.Passive4++;
			}
		}
		else if (x.Equals ("ability")) {
			activeTower.activateable.Level++;
			if(activeTower.entity_name.Equals("Agent 1")) {
				player.GetComponent<Player> ().realPlayer.Ability1++;
			}
			else if(activeTower.entity_name.Equals("Agent 2")) {
				player.GetComponent<Player> ().realPlayer.Ability2++;
			}
			else if(activeTower.entity_name.Equals("Agent 3")) {
				player.GetComponent<Player> ().realPlayer.Ability3++;
			}
			else if(activeTower.entity_name.Equals("Agent 4")) {
				player.GetComponent<Player> ().realPlayer.Ability4++;
			}
		}

		upgrader.updateTower (activeTower);
		GameObject.Find ("PlayerInfo").GetComponent<Player> ().updateData ();
	}
	public void LevelUp() {
		player.GetComponent<Player> ().realPlayer.Level++;
		player.GetComponent<Player> ().realPlayer.Exp = 0;
		player.GetComponent<Player> ().MaxStamina++;
		player.GetComponent<Player> ().realPlayer.Stamina = player.GetComponent<Player> ().MaxStamina;
		updated = true;
	}
}
