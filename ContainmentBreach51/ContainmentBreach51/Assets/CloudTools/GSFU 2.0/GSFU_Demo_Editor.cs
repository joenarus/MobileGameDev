#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class GSFU_Demo_Editor : Editor
{
	/* Menu Items Follow */
	
	[MenuItem ("Tools/Google Sheets For Unity/Create Table")]
	static void CreatePlayerTable()
	{
		GSFU_Demo_Utils.CreatePlayerTable(false);
	}
	
	[MenuItem ("Tools/Google Sheets For Unity/Create Player")]
	static void SaveGandalf()
	{
		GSFU_Demo_Utils.SaveGandalf(false);
	}
	
	[MenuItem ("Tools/Google Sheets For Unity/Update Player")]
	static void UpdateGandalf()
	{
		GSFU_Demo_Utils.UpdateGandalf(false);
	}
	
	[MenuItem ("Tools/Google Sheets For Unity/Retrieve Player")]
	static void RetrieveGandalf()
	{
		GSFU_Demo_Utils.RetrieveGandalf(false);
	}
	
	[MenuItem ("Tools/Google Sheets For Unity/Retrieve All Players")]
	static void GetAllPlayers()
	{
		GSFU_Demo_Utils.GetAllPlayers(false);
	}
	
	[MenuItem ("Tools/Google Sheets For Unity/Retrieve All Tables")]
	static void GetAllTables()
	{
		GSFU_Demo_Utils.GetAllTables(false);
	}
	
}
#endif
