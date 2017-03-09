using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Reload : MonoBehaviour {


	private float speed = 1.5f;
	private float timeToNextReload = 2.0f;


	public Vector3 targetScale;
	public Vector3 baseScale;
	public Vector3 perfectScale;
	public int startSize = 1;
	public int currScale;

	public bool jam = false;
	public bool perfect = false;
	public bool normal = false;
	public bool activate = false;
	public int time; //time it takes to reload


	// Use this for initialization
	void Start () {
		baseScale = transform.localScale;
		transform.localScale = baseScale * startSize;
		currScale = startSize;
	}
	
	// Update is called once per frame
	void Update () {
		if (activate == true) {

			transform.localScale = Vector3.Lerp (transform.localScale, targetScale, speed * Time.deltaTime);
			if (transform.localScale.x >= perfectScale.x) { // If it hits the max range
				
				transform.localScale = baseScale;
				Invoke ("Jam", 0f);
			} 
		}
	}
		
	public void ActivateReload() {
		activate = true;
		transform.localScale = baseScale;
		CancelInvoke ();
	}

	public void DeactivateReload() {
		activate = false;
		transform.localScale = baseScale;
		Invoke ("ActivateReload", timeToNextReload);
	}

	public void Jam() {
		jam = true;
		timeToNextReload = 2.0f;
		DeactivateReload ();
		Debug.Log ("Jammmmmmed");

	}

	public void Perfect() {
		perfect = true;
		timeToNextReload = 3.0f; 
		Debug.Log ("Nailed it");
		DeactivateReload ();
	}

	public void Normal() {
		normal = true;
		timeToNextReload = 1.5f;
		Debug.Log ("Norm");
		DeactivateReload ();
	}
}
