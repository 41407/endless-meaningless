using UnityEngine;
using System.Collections;

public class LevelInfo : MonoBehaviour
{
		public string levelName;
		[TextArea(3,10)]
		public string message;

		void Start ()
		{
				GameState.SetLevelName (levelName);
				GameState.SetLevelMessage (message);
		}
}
