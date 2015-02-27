using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Achievements
{
		public static ArrayList achievements = new ArrayList();

		public static void Reset ()
		{	
				Achievements.achievements = new ArrayList ();
		}

		public static void Add (string achievement)
		{
				if (!achievements.Contains (achievement)) {
						achievements.Add (achievement);
				}
		}

		public static string toString ()
		{
				string returnString = "";
				foreach (string achievement in achievements) {
						returnString += achievement;
						returnString += "\n";
				}
				return returnString;
		}
}
