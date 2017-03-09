using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public GameObject target;
	private Transform targetTrans;
	int damage = 1;

	public float speed = 20f;
	// Use this for initialization
	void Start () {
		targetTrans = target.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			transform.position = Vector3.MoveTowards (transform.position, targetTrans.position, speed * Time.deltaTime);
		} else
			Destroy (gameObject);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject == target) {
			Debug.Log ("Hit");
			Destroy (gameObject);
			target.GetComponent<AlienBehavior> ().takeDamage (damage);
		}
	}
}
