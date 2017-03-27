using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alien : MonoBehaviour {
	public Enemy information;
	public Vector3 final;
	bool taunted = false;
	bool attacking = false;
	public Vector3 target;
	public Transform currentTarget;
	public Image healthbar;
	public int maxHealth;
	public List<Hero> heroes;
	public GameObject Range;

	// Use this for initialization
	void Start () {
		heroes = new List<Hero> ();
		if (tag.Equals ("NormalAlien")) {
			GameObject.Find ("InfoHolder").GetComponent<InfoHolder>().enemies.TryGetValue("Normal", out information);
		}
		else if (tag.Equals ("FastAlien")) {
			GameObject.Find ("InfoHolder").GetComponent<InfoHolder>().enemies.TryGetValue("Fast", out information);
		}
		else if (tag.Equals ("SlowAlien")) {
			GameObject.Find ("InfoHolder").GetComponent<InfoHolder>().enemies.TryGetValue("Slow", out information);
		}
		else if (tag.Equals ("ArmorAlien")) {
			GameObject.Find ("InfoHolder").GetComponent<InfoHolder>().enemies.TryGetValue("Armor", out information);
		}
		else if (tag.Equals ("BossAlien")) {
			GameObject.Find ("InfoHolder").GetComponent<InfoHolder>().enemies.TryGetValue("Boss", out information);
		}
		maxHealth = information.health;

		final = new Vector3 (transform.position.x, -6, 0);

		if (information.passive != null) {
			Range.GetComponent<CapsuleCollider> ().radius = (information.range + information.passive.Range);
		} else {
			Range.GetComponent<CapsuleCollider> ().radius = (information.range);
		}

	}
	
	// Update is called once per frame
	void Update () {
		float step = information.speed * Time.deltaTime;
		if (!taunted) {
			transform.position = Vector3.MoveTowards (transform.position, final, step);
		} else {

			transform.position = Vector3.MoveTowards (transform.position, target, step);
		}

		if (!attacking && currentTarget != null) {
			attacking = true;
			Invoke ("Attack", information.attackSpeed);
		}
	}


	public void LoseHealth(int damage, Transform t) {
		information.TakeDamage (damage);
		healthbar.fillAmount = (float)information.health / (float)maxHealth;
		if (information.health <= 0) {
			Die (t);
		}
		taunted = true;
	}

	public void changeTarget(Transform _target) {
		if (target != null) {
			currentTarget = _target;
			target = _target.position;
			information.currentTarget = _target.gameObject.GetComponent<Hero> ().information;
			taunted = true;
		}
	}

	public void Target(Transform _target) {
		heroes.Add (_target.GetComponent<Hero> ());
		for (int i = 0; i < heroes.Count; i++) {
			if (heroes [i] != null) {
				currentTarget = heroes [i].transform;
				target = currentTarget.position;
				taunted = true;
				break;
			}
		}
	}

	public void ChangeTarget() {
		for (int i = 0; i < heroes.Count; i++) {
			if (heroes [i] != null) {
				Debug.Log ("HERE");
				currentTarget = heroes [i].transform;
				target = currentTarget.position;
				taunted = true;
				break;
			} else {
				if (i == heroes.Count) {
					taunted = false;
				}
			}
		}
	}


	public void Attack() {
		if (currentTarget != null) {
			currentTarget.gameObject.GetComponent<Hero> ().LoseHealth (information.attackPower);
			attacking = false;
		} else {
			taunted = false;
		}
	}

	public void Die(Transform t) {
		t.gameObject.GetComponent<Hero> ().ChangeTarget ();
		Destroy (gameObject);
	}

}
