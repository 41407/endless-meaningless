using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GameState
{
		private static int level;
		private static string levelName;
		private static string levelMessage;
		private static bool specialLevel;
		private static List<GameObject> playerInventory;

		public static void Reset ()
		{
				level = 0;
				levelName = "";
				levelMessage = "";
				specialLevel = false;
				playerInventory = new List<GameObject>();
		}

		public static int AdvanceLevel ()
		{
				return AdvanceLevel (1);
		}

		public static int AdvanceLevel (int amount)
		{
				level += amount;
				return level;
		}

		public static int GetLevel ()
		{
				return level;
		}

		public static void SetLevel (int newLevel)
		{
				level = newLevel;
		}

		public static void SetLevelName (string name)
		{
				levelName = name;
		}

		public static void SetLevelMessage (string message)
		{
				levelMessage = message;
		}

		public static string GetLevelName ()
		{
				return levelName;
		}
	
		public static string GetLevelMessage ()
		{
				return levelMessage;
		}

		public static bool GetSpecialLevel ()
		{
				return specialLevel;
		}

		public static void SetSpecialLevel (bool special)
		{
				specialLevel = special;
		}

		public static void SetInventory (List<GameObject> inventory)
		{
				playerInventory = inventory;
		}
		
		public static List<GameObject> GetInventory ()
		{
				return playerInventory;
		}
}
