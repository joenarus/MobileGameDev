using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBehavior : MonoBehaviour {

	public Transform target;		
	public float speed = 3;
	public GameObject[] pointOfInterest;
	public int index;
	public GameHandler handler;

	public int health;
	public int worth;

	// Use this for initialization
	void Start () {
		pointOfInterest = new GameObject[10];
		handler = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameHandler>();
		index = 0;
		speed = 3;
		health = 2;
		for (int i = 1; i <= 10; i++) {
			pointOfInterest [i - 1] = GameObject.Find ("PointOfInterest"+i);
		}
		//pointOfInterest = GameObject.FindGameObjectsWithTag ("POI"); 
	}
	
	// Update is called once per frame
	void Update() {
		target = pointOfInterest [index].transform;
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		if (transform.position == target.position && index < pointOfInterest.Length) {
			index++;
		}

		if (index == pointOfInterest.Length) { //Reaches the end
			Die();
			handler.livesChange (-1);
			handler.changed = true;
		}
	}

	public void Die() {
		Destroy (gameObject);
		handler.horde.number_dead++;
	}
	public void takeDamage(int x) {
		health -= x;
		if (health <= 0) {
			Die ();
			handler.score++;
			handler.coinChange (worth);
		}
	}

	
}
