using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GSFU_Demo_Utils
{
	[System.Serializable]
	public struct PlayerInfo
	{
		public string name; 
		public int level; 
		public float health;
		public string role;
	}
	
	private static PlayerInfo player;
	private static string tableName;
	
	static GSFU_Demo_Utils()
	{
		// Create an example object.
		player = new PlayerInfo();
		player.name = "Mithrandir";
		player.level = 99;
		player.health = 98.6f;
		player.role = "Wizzard";
		
		tableName = "PlayerInfo";
	}

	// Create a table in the cloud to store objects of type PlayerInfo.
	public static void CreatePlayerTable(bool runtime)
	{
		Debug.Log("<color=yellow>Creating a table in the cloud for players data.</color>");
		
		// Creting an string array for field (table headers) names.
		string[] fieldNames = new string[4];
		fieldNames[0] = "name";
		fieldNames[1] = "level";
		fieldNames[2] = "health";
		fieldNames[3] = "role";
		
		// Request for the table to be created on the cloud.
		CloudConnectorCore.CreateTable(fieldNames, tableName, runtime);
	}
	
	// Persist the example object in the cloud.
	public static void SaveGandalf(bool runtime)
	{
		// Get the json string of the object.
		string jsonPlayer = JsonUtility.ToJson(player);
		
		Debug.Log("<color=yellow>Sending following player to the cloud: \n</color>" + jsonPlayer);
		
		// Save the object on the cloud, in a table called like the object type.
		CloudConnectorCore.CreateObject(jsonPlayer, tableName, runtime);
	}
	
	// Update persisted objects fields on the cloud.
	public static void UpdateGandalf(bool runtime)
	{
		Debug.Log("<color=yellow>Updating cloud data: player called Mithrandir will be level 100.</color>");
		
		// Look in the 'PlayerInfo' table, for an object of name 'Mithrandir', and set its level to 100.
		CloudConnectorCore.UpdateObjects(tableName, "name", "Mithrandir", "level", "100", runtime);
	}
	
	// Get a player object from the cloud.
	public static void RetrieveGandalf(bool runtime)
	{
		Debug.Log("<color=yellow>Retrieving player of name Mithrandir from the Cloud.</color>");
		
		// Get any objects from table 'PlayerInfo' with value 'Mithrandir' in the field called 'name'.
		CloudConnectorCore.GetObjectsByField(tableName, "name", "Mithrandir", runtime);
	}
	
	// Get all player objects from the cloud.
	public static void GetAllPlayers(bool runtime)
	{
		Debug.Log("<color=yellow>Retrieving all players from the Cloud.</color>");
		
		// Get all objects from table 'PlayerInfo'.
		CloudConnectorCore.GetTable(tableName, runtime);
	}
	
	// Get all data tables from the cloud.
	public static void GetAllTables(bool runtime)
	{
		Debug.Log("<color=yellow>Retrieving all data tables from the Cloud.</color>");
		
		// Get all objects from table 'PlayerInfo'.
		CloudConnectorCore.GetAllTables(runtime);
	}
	
	// Parse data received from the cloud.
	public static void ParseData(CloudConnectorCore.QueryType query, List<string> objTypeNames, List<string> jsonData)
	{
		for (int i = 0; i < objTypeNames.Count; i++)
		{
			Debug.Log("Data type/table: " + objTypeNames[i]);
		}
		
		// First check the type of answer.
		if (query == CloudConnectorCore.QueryType.getObjects)
		{
			// In the example we will use only the first, thus '[0]',
			// but may return several objects depending the query parameters.
			
			// Check if the type is correct.
			if (string.Compare(objTypeNames[0], tableName) == 0)
			{
				// Parse from json to the desired object type.
				PlayerInfo[] players = GSFUJsonHelper.JsonArray<PlayerInfo>(jsonData[0]);
				player = players[0];
				
				Debug.Log("<color=yellow>Object retrieved from the cloud and parsed: \n</color>" + 
					"Name: " + player.name + "\n" +
					"Level: " + player.level + "\n" +
					"Health: " + player.health + "\n" +
					"Role: " + player.role + "\n");
			}
		}
		
		// First check the type of answer.
		if (query == CloudConnectorCore.QueryType.getTable)
		{
			// Check if the type is correct.
			if (string.Compare(objTypeNames[0], tableName) == 0)
			{
				// Parse from json to the desired object type.
				PlayerInfo[] players = GSFUJsonHelper.JsonArray<PlayerInfo>(jsonData[0]);
				
				string logMsg = "<color=yellow>" + players.Length.ToString() + " objects retrieved from the cloud and parsed:</color>";
				for (int i = 0; i < players.Length; i++)
				{
					logMsg += "\n" +
						"<color=blue>Name: " + players[i].name + "</color>\n" +
						"Level: " + players[i].level + "\n" +
						"Health: " + players[i].health + "\n" +
						"Role: " + players[i].role + "\n";				
				}
				Debug.Log(logMsg);
			}
		}
		
		// First check the type of answer.
		if (query == CloudConnectorCore.QueryType.getAllTables)
		{
			// Just dump all content to the console, sorted by table name.
			string logMsg = "<color=yellow>All data tables retrieved from the cloud.\n</color>";
			for (int i = 0; i < objTypeNames.Count; i++)
			{
				logMsg += "<color=blue>Table Name: " + objTypeNames[i] + "</color>\n"
					+ jsonData[i] + "\n";
			}
			Debug.Log(logMsg);
		}
	}
}

// Helper class: because UnityEngine.JsonUtility does not support deserializing an array...
// http://forum.unity3d.com/threads/how-to-load-an-array-with-jsonutility.375735/
//public class GSFUJsonHelper
//{
//	public static T[] JsonArray<T>(string json)
//	{
//		string newJson = "{ \"array\": " + json + "}";
//		Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
//		return wrapper.array;
//	}
// 
//	[System.Serializable]
//	private class Wrapper<T>
//	{
//		public T[] array = new T[] { };
//	}
//}
