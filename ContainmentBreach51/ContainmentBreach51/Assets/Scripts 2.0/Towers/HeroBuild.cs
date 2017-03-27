using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HeroBuild : MonoBehaviour, IDragHandler, IEndDragHandler {
	float speed = 10f;
	public Camera PlayerCamera;
	public GameObject building;
	public GameObject clone;
	bool buildingProgress = false;
	bool built = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (buildingProgress) {
			Vector3 target = PlayerCamera.ScreenToWorldPoint (Input.mousePosition);
			target.z = 0;
			clone.transform.position = target;
		} 
	}

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		Vector3 target = PlayerCamera.ScreenToWorldPoint(Input.mousePosition);
		target.z = 0;
		if (buildingProgress == false && !built) {
			clone = Instantiate (building, target, Quaternion.identity);
			clone.transform.parent = GameObject.Find ("Heroes").transform;
			buildingProgress = true;
		}
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		Vector3 target = PlayerCamera.ScreenToWorldPoint (Input.mousePosition);
		target.z = 0;
		buildingProgress = false;
		built = true;

	}

	#endregion

}
