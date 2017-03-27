using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienRange : MonoBehaviour {
	public Alien a;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Agent" ) {
			a.Target (other.transform);

		}
	}
}
