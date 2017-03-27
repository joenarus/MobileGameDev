using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour {
	Alien a;
	int maxHealth;
	int healthPercent;

	public Texture2D barBG; //use Texture2D
	public Texture2D barFG;
	private Color highHealth = new Color(7.0f / 255.0f, 161.0f / 255.0f, 7.0f / 255.0f);
	private Color mediumHealth = new Color(161.0f / 255.0f, 157.0f / 255.0f, 7.0f / 255.0f);
	private Color lowHealth = new Color(161.0f / 255.0f, 42.0f / 255.0f, 7.0f / 255.0f);
	private Color barColor;

	// Use this for initialization
	void Start () {
		a = transform.parent.gameObject.GetComponent<Alien> ();
		maxHealth = a.information.health;
		healthPercent = a.information.health / maxHealth;
	}

	void setTarget(Transform _target) {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y, transform.position.z));

		healthPercent = a.information.health / maxHealth;
		if (healthPercent > 0.50f)
		{
			barColor = Color.Lerp(mediumHealth, highHealth, (healthPercent - 0.50f) / 0.50f); // want 1.00 to be 100%, want .50 to be 0%
		}
		else
		{
			barColor = Color.Lerp(lowHealth, mediumHealth, healthPercent / 0.50f); // want .50 to be 100%, want 0.00 to be 0%
		}

	}

	void OnGUI() {
		//First draw background of bar
		GUI.color = Color.white; //resset gui color
		GUI.DrawTexture(new Rect(transform.position.x - 80/2, transform.position.y, 80, 40), barBG, ScaleMode.StretchToFill);
		//Second draw fill bar, but draw in group
		GUI.BeginGroup(new Rect(transform.position.x - 80/2, transform.position.y, 80 * (a.information.health/maxHealth), 40));
		//Apply color
		GUI.color = barColor;
		//Draw bar or him part
		GUI.DrawTexture(new Rect(0, 0, 80, 40), barFG, ScaleMode.StretchToFill);
		GUI.EndGroup();
	}
}
