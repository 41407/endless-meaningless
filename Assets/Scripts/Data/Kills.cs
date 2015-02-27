using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Kills
{
		public static SortedDictionary<string, int> kills = new SortedDictionary<string, int> ();
		public static int numberOfKills = 0;

		public static void Reset ()
		{	
				kills = new SortedDictionary<string, int> ();
				numberOfKills = 0;
		}

		public static void Add (string killName)
		{
				numberOfKills++;
				int count = 0;
				if (kills.ContainsKey (killName)) {
						count = kills [killName];
						kills.Remove (killName);
				}
				kills.Add (killName, count + 1);
		}

		public static string toString ()
		{
				string returnValue = "";
				if (kills.Count > 0) {
						foreach (KeyValuePair<string, int> entry in kills) {
								returnValue = returnValue + entry.Value + " " + entry.Key;
								if (entry.Value > 1) {
										returnValue += "s";
								}
								returnValue += "\n";
						}
						return returnValue.Remove (returnValue.Length - 1);
				} else {
						return "None";
				}
		}
}
