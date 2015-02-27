using UnityEngine;
using System.Collections;

public class KillsDisplay : MonoBehaviour
{

		public bool kills = true;
		public bool achievements = true;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (kills) {
						guiText.text = "Kills:\n" + Kills.toString ();
				} 
				if (achievements) {
						guiText.text += "\n\nAchievements:\n" + Achievements.toString ();
				}
		}
}
