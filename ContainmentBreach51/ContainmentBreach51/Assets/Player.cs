using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

	[System.Serializable]
	public struct PlayerInfo
	{
		public string Name;
		public int ID;
		public int Level;
		public int Exp;
		public int Stamina;
		public int Currency;
		public int TowerN;
		public int TowerF;
		public int TowerS;
	}

	public static PlayerInfo player;
	private static string playerInfoTable = "PlayerInfo";
	public static bool loading = true;
	public bool loaded = false;
	private bool init = false;
	public PlayerInfo realPlayer;
	public Button Enter;
	public Text loadingText;

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
		PlayerPrefs.SetInt ("TowerN", realPlayer.TowerN);
		PlayerPrefs.SetInt ("TowerF", realPlayer.TowerF);
		PlayerPrefs.SetInt ("TowerS", realPlayer.TowerS);
		SaveData ();
	}

	public void getData() {
		realPlayer.Name = PlayerPrefs.GetString ("Name");
		realPlayer.ID = PlayerPrefs.GetInt ("ID");
		realPlayer.Level = PlayerPrefs.GetInt ("Level");
		realPlayer.Exp = PlayerPrefs.GetInt ("Exp");
		realPlayer.Stamina = PlayerPrefs.GetInt ("Stamina");
		realPlayer.Currency = PlayerPrefs.GetInt ("Currency");
		realPlayer.TowerN = PlayerPrefs.GetInt ("TowerN");
		realPlayer.TowerF = PlayerPrefs.GetInt ("TowerF");
		realPlayer.TowerS = PlayerPrefs.GetInt ("TowerS");
	}




	// Use this for initialization
	void Start ()
	{
		loading = true;
		Enter.interactable = false;
		DontDestroyOnLoad (gameObject.transform);
		PlayerPrefs.DeleteAll ();
		int x = PlayerPrefs.GetInt ("init");
		Debug.Log (x);
		if (x == 0) {
			CloudConnectorCore.processedResponseCallback.AddListener (ParseData);
			CloudConnectorCore.GetObjectsByField (playerInfoTable, "Name", "Joe", true);
			PlayerPrefs.SetInt ("init", 1);
		} 

		else {
			//GRAB PLAYER PREFS
			getData();
			loaded = true;
			Enter.interactable = true;
			loadingText.gameObject.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (!loaded) {
			//Play loading animation

			if (!loading) { 
				loaded = true; 
				realPlayer = player;
				Enter.interactable = true;
				loadingText.gameObject.SetActive (false);
				updateData ();

			}
		}
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
			if (string.Compare (objTypeNames [0], playerInfoTable) == 0) {
				// Parse from json to the desired object type.
				PlayerInfo[] players = GSFUJsonHelper.JsonArray<PlayerInfo> (jsonData [0]);
				player = players [0];

				Debug.Log ("<color=yellow>Object retrieved from the cloud and parsed: \n</color>" +
				"Name: " + player.Name + "\n" +
				"Level: " + player.Level + "\n" +
				"EXP: " + player.Exp + "\n" +
				"Stamina: " + player.Stamina + "\n");
			}
		}

		// First check the type of answer.
		if (query == CloudConnectorCore.QueryType.getTable) {
			// Check if the type is correct.
			if (string.Compare (objTypeNames [0], playerInfoTable) == 0) {
				// Parse from json to the desired object type.
				PlayerInfo[] players = GSFUJsonHelper.JsonArray<PlayerInfo> (jsonData [0]);

				string logMsg = "<color=yellow>" + players.Length.ToString () + " objects retrieved from the cloud and parsed:</color>";
				for (int i = 0; i < players.Length; i++) {
					logMsg += "\n" +
					"<color=blue>Name: " + players [i].Name + "</color>\n" +
					"Level: " + players [i].Level + "\n" +
					"EXP: " + players [i].Exp + "\n" +
					"Stamina: " + players [i].Stamina + "\n";				
				}
				Debug.Log (logMsg);
			}
		}

		// First check the type of answer.
		if (query == CloudConnectorCore.QueryType.getAllTables) {
			// Just dump all content to the console, sorted by table name.
			string logMsg = "<color=yellow>All data tables retrieved from the cloud.\n</color>";
			for (int i = 0; i < objTypeNames.Count; i++) {
				logMsg += "<color=blue>Table Name: " + objTypeNames [i] + "</color>\n"
				+ jsonData [i] + "\n";
			}
			Debug.Log (logMsg);
		}
		loading = false;
	}
}

// Helper class: because UnityEngine.JsonUtility does not support deserializing an array...
// http://forum.unity3d.com/threads/how-to-load-an-array-with-jsonutility.375735/
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
