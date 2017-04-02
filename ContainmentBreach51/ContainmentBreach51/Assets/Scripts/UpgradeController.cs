using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour {
	public InfoHolder holder;
	public Tower t;
	public Slider health;
	public Slider atk;
	public Slider speed;
	public Slider range;
	public Text tower_name;
	public Text ability_info;
	public Text passive_info;
	public Text level;
	public Text ability;
	public Text passive;

	public static bool towerUpdated;
	// Use this for initialization
	void Start () {
		holder = GameObject.Find ("InfoHolder").GetComponent<InfoHolder>();
		towerUpdated = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (towerUpdated) {
			updateTower (t);
		}
	}

	public void updateTower(Tower t) {
		tower_name.text = t.entity_name;
		ability_info.text = t.activateable.Ability_name + "\n" + t.activateable.Ability_info;
		passive_info.text = t.passive.Ability_name + "\n" + t.passive.Ability_info;
		level.text = "" + t.level;
		ability.text = "" + t.activateable.Level;
		passive.text = "" + t.passive.Level;
		towerUpdated = false;
		atk.value = (float)t.attackPower / (float)t.maxAttack * 100;
		speed.value = (float)t.MaxSpeed / (float)t.attackSpeed * 100;
		health.value = (float)t.health / (float)1000 * 100;
		range.value = (float)t.range / (float)t.maxRange * 100;

		Debug.Log (t.attackPower + " " + t.maxAttack);
	}


}
