using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoHolder : MonoBehaviour {
	public bool created = false;
	public Dictionary<string, Ability> abilities;
	public Dictionary<string, Tower> towers;
	public Dictionary<string, Enemy> enemies;
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
						           CloudDataRetrieve.abilities [i].AoE);
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
						         CloudDataRetrieve.enemies [j].speed);
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
						         CloudDataRetrieve.towers [k].speed);
					towers.Add (t.entity_name, t); 
				}
			}
		}
	}
}
