using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingMenu : MonoBehaviour, IDragHandler, IEndDragHandler {
	float speed = 10f;
	public GameObject building;
	Builder currentBuilding;
	public Camera PlayerCamera;
	public int cost = 0;
	bool buildingProgress = false;
	bool built = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


	}

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		Vector3 target = PlayerCamera.ScreenToWorldPoint(Input.mousePosition);
		target.z = 0;
		if (buildingProgress == false) {
			GameObject clone = Instantiate (building, target, Quaternion.identity);
			clone.transform.parent = GameObject.Find ("Buildings").transform;
			currentBuilding = clone.GetComponent<Builder> ();
			buildingProgress = true;
		}
	}

	#endregion
//
//	void OnDrag() {
//		
//	}

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		Vector3 target = PlayerCamera.ScreenToWorldPoint (Input.mousePosition);
		target.z = 0;
		if (cost <= GameObject.Find ("GameController").GetComponent<GameHandler> ().coins) {
			if (target.x >= -8.5 && target.x <= -6.5) {
				if (target.y >= -.5 && target.y <= 3.5) {
					buildingProgress = false;
					currentBuilding.StopBuilding();
					built = true;
				}

			} else if (target.x >= -4.5 && target.x <= -2.5) {
				if (target.y >= -1.5 && target.y <= 2.5) {
					buildingProgress = false;
					currentBuilding.StopBuilding();
					built = true;
				}
			} else if (target.x >= -.5 && target.x <= 1.5) {
				if (target.y >= -.5 && target.y <= 3.5) {
					buildingProgress = false;
					currentBuilding.StopBuilding();
					built = true;
				}
			} else if (target.x >= 3.5 && target.x <= 5.5) {
				if (target.y >= -1.5 && target.y <= 2.5) {
					buildingProgress = false;	 
					currentBuilding.StopBuilding();
					built = true;
				}
			} else {
				buildingProgress = false;
				currentBuilding.StopBuilding();
				Debug.Log ("Can't build here");
				Destroy (currentBuilding.gameObject);
			}
		} else {
			buildingProgress = false;
			currentBuilding.building = false;
			Debug.Log ("Not enough coins");
			Destroy (currentBuilding.gameObject);
		}
		if (built == true) {
			GameObject.Find ("GameController").GetComponent<GameHandler> ().coinChange (0 - cost);
			currentBuilding = null;
			built = false;
		} else {
			Destroy (currentBuilding.gameObject);
			buildingProgress = false;
			built = false;
		}
	}

	#endregion

//	void OnMouseUp() {
//			
//
//	}
}
