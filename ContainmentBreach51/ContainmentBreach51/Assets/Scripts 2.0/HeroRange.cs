using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRange : MonoBehaviour {
	public Hero hero;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

//	void OnTriggerStay(Collider other) {
//		
//	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "NormalAlien" || other.tag == "FastAlien" || other.tag == "SlowAlien" || 
			other.tag == "ArmorAlien" || other.tag == "BossAlien" ) {
			hero.Target (other.transform);

		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "NormalAlien" || other.tag == "FastAlien" || other.tag == "SlowAlien" || 
			other.tag == "ArmorAlien" || other.tag == "BossAlien" ) {

		}

	}
}
