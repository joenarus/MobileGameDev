using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour {
	public Tower information;
	public Vector3 target;
	public GameObject Range;
	public List<Alien> enemies;
	public Transform currentTarget;
	public Image healthbar;
	public int maxHealth;

	bool attacking = false;
	// Use this for initialization
	void Start () {
		enemies = new List<Alien>();
		if (name.Equals ("Agent1(Clone)")) {
			GameObject.Find ("InfoHolder").GetComponent<InfoHolder>().towers.TryGetValue("Agent 1", out information);
		}
		else if (name.Equals ("Agent2(Clone)")) {
			GameObject.Find ("InfoHolder").GetComponent<InfoHolder>().towers.TryGetValue("Agent 2", out information);
		}
		else if (name.Equals ("Agent3(Clone)")) {
			GameObject.Find ("InfoHolder").GetComponent<InfoHolder>().towers.TryGetValue("Agent 3", out information);
		}
		else if (name.Equals ("Agent4(Clone)")) {
			GameObject.Find ("InfoHolder").GetComponent<InfoHolder>().towers.TryGetValue("Agent 4", out information);
		}
		if (information.passive != null) {
			Range.GetComponent<CapsuleCollider> ().radius = (information.range + information.passive.Range);
		} else {
			Range.GetComponent<CapsuleCollider> ().radius = (information.range);
		}
		maxHealth = information.health;
		healthbar.fillAmount = (float)information.health / (float)maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (!attacking && currentTarget != null) {
			attacking = true;
			Invoke ("Attack", information.attackSpeed);
		}
	}

	public void Target(Transform target) {
		enemies.Add (target.GetComponent<Alien> ());
		for (int i = 0; i < enemies.Count; i++) {
			if (enemies [i] != null) {
				currentTarget = enemies [i].transform;
				break;
			}
		}
	}

	public void ChangeTarget() {
		for (int i = 0; i < enemies.Count; i++) {
			if (enemies [i] != null) {
				currentTarget = enemies [i].transform;
				break;
			}
		}

	}

	public void Attack() {
		currentTarget.gameObject.GetComponent<Alien> ().LoseHealth (information.attackPower, transform);
		attacking = false;
	}

	public void LoseHealth(int damage) {
		information.TakeDamage (damage);
		healthbar.fillAmount = (float)information.health / (float)maxHealth;
		if (information.health <= 0) {
			Die ();
		}
	}

	public void Die() {
		CancelInvoke ();
		Destroy (gameObject);
	}
}
