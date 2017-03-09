using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

	private int level;

	private AlienBehavior temp;
	public GameObject projectile;
	public float fireRate;
	public int damage;
	bool attacking;
	public bool built = false;
	List <AlienBehavior> enemies = new List<AlienBehavior>();
	int CurrentAttackingIndex = 0;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other) {
		if (other.tag == "alien") {
			if (!attacking && built) {
				attacking = true;
				temp = other.GetComponent<AlienBehavior> ();
				InvokeRepeating ("Attack",.01f, fireRate);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		temp = other.GetComponent<AlienBehavior> ();
		enemies.Add(temp);
	}

	void OnTriggerExit(Collider other) {
		enemies.Remove (enemies [CurrentAttackingIndex]);
		attacking = false;

	}

		
	void Attack() {
		if (enemies [CurrentAttackingIndex] != null) {

			GameObject clone = Instantiate (projectile, transform.position, Quaternion.identity);
			clone.GetComponent<Projectile> ().target = enemies [CurrentAttackingIndex].gameObject;
		}
		if (enemies[CurrentAttackingIndex].health <= 0) {
			enemies.Remove (enemies [CurrentAttackingIndex]);
		}

		if (CurrentAttackingIndex > enemies.Count - 1) {
			CancelInvoke ();
			attacking = false;
		}
		int counter = 0;
		for (int i = 0; i < enemies.Count; i++) {
			if (enemies [i].health == 0)
				counter++;
		}
		if (counter == enemies.Count) {
			CancelInvoke ();
		}
	}
}
