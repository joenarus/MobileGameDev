using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillZones : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		Alien a = other.gameObject.GetComponent<Alien> ();
		if (a!=null) {
			GameObject.Destroy (other.gameObject);
			GameObject.Find ("GameHandler").GetComponent<GameHandlerN> ().loseLife ();
		}
	}
}
