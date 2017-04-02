using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public static bool created;

	public static bool init = false;
	public PlayerInfo realPlayer;
	public int MaxStamina = 100;

	public void SaveData() {
		PlayerPrefs.Save ();

	}

	public void updateData() {
		PlayerPrefs.SetString ("Name", realPlayer.Name);
		PlayerPrefs.SetInt ("ID", realPlayer.ID);
		PlayerPrefs.SetInt ("Level", realPlayer.Level);
		PlayerPrefs.SetInt ("Exp", realPlayer.Exp);
		PlayerPrefs.SetInt ("Stamina", realPlayer.Stamina);
		PlayerPrefs.SetInt ("Currency", realPlayer.Currency);
		PlayerPrefs.SetInt ("Agent1", realPlayer.Agent1);
		PlayerPrefs.SetInt ("Agent2", realPlayer.Agent2);
		PlayerPrefs.SetInt ("Agent3", realPlayer.Agent3);
		PlayerPrefs.SetInt ("Agent4", realPlayer.Agent4);
		PlayerPrefs.SetInt ("Active1", realPlayer.Ability1);
		PlayerPrefs.SetInt ("Active2", realPlayer.Ability2);
		PlayerPrefs.SetInt ("Active3", realPlayer.Ability3);
		PlayerPrefs.SetInt ("Active4", realPlayer.Ability4);
		PlayerPrefs.SetInt ("Passive1", realPlayer.Passive1);
		PlayerPrefs.SetInt ("Passive2", realPlayer.Passive2);
		PlayerPrefs.SetInt ("Passive3", realPlayer.Passive3);
		PlayerPrefs.SetInt ("Passive4", realPlayer.Passive4);
		PlayerPrefs.SetInt ("init", 1);
		Debug.Log("Updating....");
		SaveData ();
	}

	public void getData() {
		
		realPlayer.Name = PlayerPrefs.GetString ("Name");
		realPlayer.ID = PlayerPrefs.GetInt ("ID");
		realPlayer.Level = PlayerPrefs.GetInt ("Level");
		realPlayer.Exp = PlayerPrefs.GetInt ("Exp");
		realPlayer.Stamina = PlayerPrefs.GetInt ("Stamina");
		realPlayer.Currency = PlayerPrefs.GetInt ("Currency");
		realPlayer.Agent1 = PlayerPrefs.GetInt ("Agent1");
		realPlayer.Agent2 = PlayerPrefs.GetInt ("Agent2");
		realPlayer.Agent3 = PlayerPrefs.GetInt ("Agent3");
		realPlayer.Agent4 = PlayerPrefs.GetInt ("Agent4");
		realPlayer.Ability1 = PlayerPrefs.GetInt ("Ability1");
		realPlayer.Ability2 = PlayerPrefs.GetInt ("Ability2");
		realPlayer.Ability3 = PlayerPrefs.GetInt ("Ability3");
		realPlayer.Ability4 = PlayerPrefs.GetInt ("Ability4");
		realPlayer.Passive1 = PlayerPrefs.GetInt ("Passive1");
		realPlayer.Passive2 = PlayerPrefs.GetInt ("Passive2");
		realPlayer.Passive3 = PlayerPrefs.GetInt ("Passive3");
		realPlayer.Passive4 = PlayerPrefs.GetInt ("Passive4");
	}
		
	// Use this for initialization
	void Start ()
	{
		created = false;
		//PlayerPrefs.DeleteAll ();
		DontDestroyOnLoad (gameObject.transform);
		int initialized = PlayerPrefs.GetInt ("init");
		if (initialized == 0) {
			PlayerPrefs.DeleteAll ();
			PlayerInfo p = new PlayerInfo ();
			float r = Random.Range (0, 100000.0f);
			p.Name = "" + r;
			p.ID = 1;
			p.Level = 1;
			p.Exp = 0;
			p.Stamina = 50;
			p.Currency = 500;
			p.Agent1 = 2;
			p.Agent2 = 1;
			p.Agent3 = 1;
			p.Agent4 = 1;
			p.Ability1 = 1;
			p.Ability2 = 1;
			p.Ability3 = 1;
			p.Ability4 = 1;
			p.Passive1 = 1;
			p.Passive2 = 1;
			p.Passive3 = 1;
			p.Passive4 = 1;
			CloudDataRetrieve.SavePlayer (p);
			realPlayer = p;
			updateData ();
			created = true;
			init = true;
		} else { 
			init = true;
			getData ();
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}
}
	