using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienHordeBehavior : MonoBehaviour {
	public int hordeSize;
	public int numberSpawned;
	public GameObject alien;
	public GameHandler handler;
	bool waveEnd;
	public Button StartWave;
	public int number_dead;
	// Use this for initialization
	void Start () {
		waveEnd = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (numberSpawned == hordeSize) {
			endWave ();
		}

		if (transform.childCount == 0 && waveEnd) {
			handler.newWave ();
			waveEnd = false;
			StartWave.gameObject.SetActive (true);
		}
	}

	public void startWave() {
		startWave (hordeSize);
		StartWave.gameObject.SetActive (false);
		number_dead = 0;
	}


	public void startWave(int size) {
		numberSpawned = 0;
		hordeSize = size;
		InvokeRepeating ("SpawnAlien", 1,1);

	}

	void SpawnAlien() {
		GameObject clone = Instantiate (alien, gameObject.transform.position, Quaternion.identity) as GameObject;
		clone.transform.parent = transform;
		numberSpawned++;
	}

	public void endWave() {
		CancelInvoke ();
		hordeSize += hordeSize - 1;
		waveEnd = true;
	}

}
