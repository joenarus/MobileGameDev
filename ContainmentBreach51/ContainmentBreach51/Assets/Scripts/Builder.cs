using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Builder : MonoBehaviour, IPointerClickHandler {
	public bool building = false;
	public int cost;
	public Camera PlayerCamera;
	public Building turret;
	GameObject reloadValue;
	Reload r;
	bool activated = false;

	// Use this for initialization
	void Start () {
		building = true;
		PlayerCamera = GameObject.Find ("Main Camera").GetComponent<Camera>();
		reloadValue = transform.Find("Reloader").gameObject;
		r = reloadValue.GetComponent<Reload> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (building) {
			Vector3 target = PlayerCamera.ScreenToWorldPoint (Input.mousePosition);
			target.z = 0;
			transform.position = target;
		} 
		else { 
			if (!activated) {
				r.ActivateReload ();
				activated = true;
			}

		}


	}

	public void StopBuilding() {
		building = false;
		turret.built = true;
	}

	#region IPointerClickHandler implementation
	public void OnPointerClick (PointerEventData eventData)
	{
		if (r.activate) {
			if (reloadValue.transform.localScale.x >= (r.targetScale.x * 3 / 4) && reloadValue.transform.localScale.x < (r.perfectScale.x - 1.0f)) { // If it hits the normal range
				r.Normal ();
			} else if (reloadValue.transform.localScale.x >= (r.perfectScale.x - 1.0f)) {
				r.Perfect ();
			}
			else { //Jam
				r.Jam();
			}
		}
	}
	#endregion

}
