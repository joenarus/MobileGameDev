using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

	public static bool init = false;
	public PlayerInfo realPlayer;

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
		PlayerPrefs.SetInt ("init", 1);
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
	}
		
	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad (gameObject.transform);
		int initialized = PlayerPrefs.GetInt ("init");
		if (initialized == 0) {
			PlayerPrefs.DeleteAll ();
			PlayerInfo p = new PlayerInfo ();
			p.Name = "Madi";
			p.ID = 4;
			p.Level = 50;
			p.Exp = 0;
			p.Stamina = 50;
			p.Currency = 200;
			p.Agent1 = 2;
			p.Agent2 = 3;
			p.Agent3 = 4;
			p.Agent4 = 1;
			CloudDataRetrieve.SavePlayer (p);
			realPlayer = p;
			updateData ();
			init = true;

		} else { 
			getData ();
			init = true;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (!init) {
			if (CloudDataRetrieve.playerloaded) {
				realPlayer = CloudDataRetrieve.player;
				init = true;
			}
		}
	}
}
	