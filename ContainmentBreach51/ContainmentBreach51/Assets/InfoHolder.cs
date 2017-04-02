using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoHolder : MonoBehaviour {
	public bool created = false;
	public Dictionary<string, Ability> abilities;
	public Dictionary<string, Tower> towers;
	public Dictionary<string, Enemy> enemies;
	public Sprite[] towerSprites;


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		abilities = new Dictionary<string, Ability> ();
		towers = new Dictionary<string, Tower> ();
		enemies = new Dictionary<string, Enemy> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (CloudDataRetrieve.startcreating && !created) {
			if (CloudDataRetrieve.abilities != null) {
				created = true;
				for (int i = 0; i < CloudDataRetrieve.abilities.Length; i++) {
					Ability a = new Ability (CloudDataRetrieve.abilities [i].name, 
						           CloudDataRetrieve.abilities [i].attackPower,
						           CloudDataRetrieve.abilities [i].healPower,
						           CloudDataRetrieve.abilities [i].range,
						           CloudDataRetrieve.abilities [i].taunt,
						CloudDataRetrieve.abilities [i].AoE, CloudDataRetrieve.abilities[i].info, 1);
					abilities.Add (a.Ability_name, a);
				}
				for (int j = 0; j < CloudDataRetrieve.enemies.Length; j++) {
					Enemy e = new Enemy (CloudDataRetrieve.enemies [j].health,
						         CloudDataRetrieve.enemies [j].armor, 
						         1, 
						         CloudDataRetrieve.enemies [j].name, 
						         CloudDataRetrieve.enemies [j].attackRange, 
						         CloudDataRetrieve.enemies [j].attackSpeed, 
						         CloudDataRetrieve.enemies [j].attackPower, 
						         CloudDataRetrieve.enemies [j].taunt,
						         CloudDataRetrieve.enemies [j].speed, 
						CloudDataRetrieve.enemies [j].value, 
						CloudDataRetrieve.enemies [j].maxAttack,
						CloudDataRetrieve.enemies [j].maxRange,
						CloudDataRetrieve.enemies [j].MaxSpeed);
					enemies.Add (e.entity_name, e); 

				}
				for (int k = 0; k < CloudDataRetrieve.towers.Length; k++) {
					Tower t = new Tower (CloudDataRetrieve.towers [k].health,
						         CloudDataRetrieve.towers [k].armor, 
						         1, 
						         CloudDataRetrieve.towers [k].name, 
						         CloudDataRetrieve.towers [k].attackRange, 
						         CloudDataRetrieve.towers [k].attackSpeed, 
						         CloudDataRetrieve.towers [k].attackPower, 
						         CloudDataRetrieve.towers [k].taunt,
						         CloudDataRetrieve.towers [k].speed,
						CloudDataRetrieve.towers [k].maxAttack,
						CloudDataRetrieve.towers [k].maxRange,
						CloudDataRetrieve.towers [k].MaxSpeed);
					Debug.Log (t.entity_name);
					towers.Add (t.entity_name, t); 
					if (k == 0) {
						t.level = GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Agent1;
						t.addAbility (abilities["Armor Piercing"], GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Ability1);
						t.addPassive (abilities["Range+"], GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Passive1);
					} else if (k == 1) {
						t.level = GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Agent2;
						t.addAbility (abilities ["Armor Piercing"], GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Ability2);
						t.addPassive (abilities ["Range+"], GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Passive2);
					} else if (k == 2) {
						t.level = GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Agent3;
						t.addAbility (abilities ["Armor Piercing"], GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Ability3);
						t.addPassive (abilities ["Range+"], GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Passive3);
					} else if (k == 3) {
						t.level = GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Agent4;
						t.addAbility (abilities ["Armor Piercing"], GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Ability4);
						t.addPassive (abilities ["Range+"], GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Passive4);
					}
				}

			}
		}
	}

//	public void LevelUp(Tower t) {
//		t.level++;
//		if (t.entity_name.Equals ("Agent1")) {
//			GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Agent1++;
//		}
//		else if (t.entity_name.Equals ("Agent2")) {
//			GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Agent2++;
//		}
//		else if (t.entity_name.Equals ("Agent3")) {
//			GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Agent3++;
//		}
//		else if (t.entity_name.Equals ("Agent4")) {
//			GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Agent4++;
//		}
//		GameObject.Find ("PlayerInfo").GetComponent<Player> ().updateData ();
//
//	}
//	public void AbilityUp(Tower t) {
//		if (t.entity_name.Equals ("Agent1")) {
//			GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Ability1++;
//		}
//		else if (t.entity_name.Equals ("Agent2")) {
//			GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Ability2++;
//		}
//		else if (t.entity_name.Equals ("Agent3")) {
//			GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Ability3++;
//		}
//		else if (t.entity_name.Equals ("Agent4")) {
//			GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Ability4++;
//		}
//		GameObject.Find ("PlayerInfo").GetComponent<Player> ().updateData ();
//	}
//	public void PassiveUp(Tower t) {
//		if (t.entity_name.Equals ("Agent1")) {
//			GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Passive1++;
//		}
//		else if (t.entity_name.Equals ("Agent2")) {
//			GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Passive2++;
//		}
//		else if (t.entity_name.Equals ("Agent3")) {
//			GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Passive3++;
//		}
//		else if (t.entity_name.Equals ("Agent4")) {
//			GameObject.Find ("PlayerInfo").GetComponent<Player> ().realPlayer.Passive4++;
//		}
//		GameObject.Find ("PlayerInfo").GetComponent<Player> ().updateData ();
//
//	}

}
