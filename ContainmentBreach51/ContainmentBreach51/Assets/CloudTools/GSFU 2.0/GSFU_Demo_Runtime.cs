using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GSFU_Demo_Runtime : MonoBehaviour
{
	void OnEnable()
	{
		// Suscribe for catching cloud responses.
		CloudConnectorCore.processedResponseCallback.AddListener(GSFU_Demo_Utils.ParseData);
	}
	
	void OnDisable()
	{
		// Remove listeners.
		CloudConnectorCore.processedResponseCallback.RemoveListener(GSFU_Demo_Utils.ParseData);
	}
	
	void OnGUI()
	{
		if (GUI.Button(new Rect(20, 20, 140, 25), "Create Table"))
			GSFU_Demo_Utils.CreatePlayerTable(true);

		if (GUI.Button(new Rect(20, 60, 140, 25), "Create Player"))
			GSFU_Demo_Utils.SaveGandalf(true);
		
		if (GUI.Button(new Rect(20, 100, 140, 25), "Update Player"))
			GSFU_Demo_Utils.UpdateGandalf(true);

		if (GUI.Button(new Rect(20, 140, 140, 25), "Retrieve Player"))
			GSFU_Demo_Utils.RetrieveGandalf(true);
		
		if (GUI.Button(new Rect(20, 180, 140, 25), "Retrieve All Players"))
			GSFU_Demo_Utils.GetAllPlayers(true);
		
		if (GUI.Button(new Rect(20, 220, 140, 25), "Retrieve All Tables"))
			GSFU_Demo_Utils.GetAllTables(true);
	}
	
	
}



