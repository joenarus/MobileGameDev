using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct PlayerInfo
{
	public string Name;
	public int ID;
	public int Level;
	public int Exp;
	public int Stamina;
	public int Currency;
	public int Agent1;
	public int Agent2;
	public int Agent3;
	public int Agent4;
}


[System.Serializable]
public struct AbilityInfo
{
	public string name;	
	public int attackPower;	
	public float range;	
	public int healPower;	
	public int taunt;	
	public int AoE;
}

[System.Serializable]
public struct EntityInfo
{
	public string name;	
	public int health;
	public float attackSpeed;
	public float attackRange;
	public int attackPower;
	public int taunt;
	public int speed;
	public int armor;
}


public class CloudDataRetrieve : MonoBehaviour {
	private static string PLAYER = "PlayerInfo";
	private static string TOWERS = "HeroTower";
	private static string ENEMIES = "AlienInfo";
	private static string ABILITIES = "Abilities";


	public static PlayerInfo player;
	public static AbilityInfo[] abilities;
	public static EntityInfo[] enemies;
	public static EntityInfo[] towers; 

	public static bool finished1 = false;
	public static bool finished2 = false;
	public static bool finished3 = false;
	public static bool finished4 = false;
	public static bool loaded = false;
	public static bool startcreating = false;
	public static bool playerloaded = false;
	public static bool loadVal = true;
	public static int loadingbarVal = 0;
	public Button Enter;
	public Text loadingText;
	public Slider loadingSlider;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject.transform);			
		CloudConnectorCore.processedResponseCallback.AddListener (ParseData);

	}
	
	// Update is called once per frame
	void Update () {
		if (!finished4 && !playerloaded) {
			if (loadVal) {
				loadVal = false;
				if (finished3) {
					loadingbarVal = 75;
					grabPlayerData ();
				}
				else if (finished2) {
					loadingbarVal = 50;
					getAbilityData ();
				}
				else if (finished1) {
					loadingbarVal = 25;
					getTowerData ();
				}
				else if (!finished1) {
					loadingbarVal = 0;
					getEnemyData ();
				}
				loadingSlider.value = loadingbarVal;
			}
		}


		if (loaded) {
			//Play loading animation
			if (loadVal) { 
				loaded = false; 
				startcreating = true;
				Enter.interactable = true;
				loadingText.gameObject.SetActive (false);
				loadingSlider.gameObject.SetActive (false);
			}
		}
	}

	public static void getTowerData() {
		CloudConnectorCore.GetTable (TOWERS,true);
		finished2 = true;
	}
	public static void getEnemyData() {
		
		CloudConnectorCore.GetTable (ENEMIES, true);
		finished1 = true;
	}
	public static void getAbilityData() {
		CloudConnectorCore.GetTable (ABILITIES, true);
		finished3 = true;
	}

	public static void grabPlayerData() {
		if (!Player.init) {
			finished4 = true;
			CloudConnectorCore.GetObjectsByField (PLAYER, "Name", "Joe", true);
			loaded = true;
		} else {
			finished4 = true;
			loaded = true;
			loadVal = true;
		}

	}

	public static void updatePlayer(string field, string search, string field_to_change, string val) {
		CloudConnectorCore.UpdateObjects (PLAYER, field, search, field_to_change, val, true);
	}

	public static void SavePlayer(PlayerInfo _player) {
		string jsonPlayer = JsonUtility.ToJson (_player);
		CloudConnectorCore.CreateObject (jsonPlayer, PLAYER, true);
	}

	public static void ParseData (CloudConnectorCore.QueryType query, List<string> objTypeNames, List<string> jsonData)
	{
		for (int i = 0; i < objTypeNames.Count; i++) {
			Debug.Log ("Data type/table: " + objTypeNames [i]);
		}

		// First check the type of answer.
		if (query == CloudConnectorCore.QueryType.getObjects) {
			// In the example we will use only the first, thus '[0]',
			// but may return several objects depending the query parameters.

			// Check if the type is correct.
			if (string.Compare (objTypeNames [0], PLAYER) == 0) {
				// Parse from json to the desired object type.
				PlayerInfo[] players = GSFUJsonHelper.JsonArray<PlayerInfo> (jsonData [0]);
				player = players [0];
				playerloaded = true;
			}
		}

		// First check the type of answer.
		else if (query == CloudConnectorCore.QueryType.getTable) {
			
			// Check if the type is correct.
			if (string.Compare (objTypeNames [0], ABILITIES) == 0) {
				// Parse from json to the desired object type.
				abilities = GSFUJsonHelper.JsonArray<AbilityInfo> (jsonData [0]);

			}

			else if (string.Compare (objTypeNames [0], TOWERS) == 0) {
				// Parse from json to the desired object type.

				towers = GSFUJsonHelper.JsonArray<EntityInfo> (jsonData [0]);

			}

			else if (string.Compare (objTypeNames [0], ENEMIES) == 0) {
				// Parse from json to the desired object type.
				enemies = GSFUJsonHelper.JsonArray<EntityInfo> (jsonData [0]);
			
			}

		}

		// First check the type of answer.
		else if (query == CloudConnectorCore.QueryType.getAllTables) {
			// Just dump all content to the console, sorted by table name.
			string logMsg = "<color=yellow>All data tables retrieved from the cloud.\n</color>";
			for (int i = 0; i < objTypeNames.Count; i++) {
				logMsg += "<color=blue>Table Name: " + objTypeNames [i] + "</color>\n"
					+ jsonData [i] + "\n";
			}
			Debug.Log (logMsg);
		}
		loadVal = true;
	}
}



public class GSFUJsonHelper
{
	public static T[] JsonArray<T> (string json)
	{
		string newJson = "{ \"array\": " + json + "}";
		Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>> (newJson);
		return wrapper.array;
	}

	[System.Serializable]
	private class Wrapper<T>
	{
		public T[] array = new T[] { };
	}
}
