using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZones : MonoBehaviour {
	public static BoxCollider2D bounds;
	public static GameObject zone;

	// Use this for initialization
	void Start () {
		bounds = gameObject.GetComponent<BoxCollider2D> ();
		zone = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void spawnEnemy(GameObject t) {
		
		Vector3 size = randomLocation ();
		GameObject clone = Instantiate (t,size , Quaternion.identity);
		clone.transform.parent = GameObject.Find ("Enemies").transform;
	}

	public static Vector3 randomLocation() {
		float x = bounds.size.x;
		float x_pos = zone.transform.position.x;

		float ending_x = Random.Range (x_pos - bounds.size.x / 2, x_pos + bounds.size.x / 2);


		return new Vector3 (ending_x,zone.transform.position.y);
	}
}
