using UnityEngine;
using System.Collections;

public class PositionDisplay : MonoBehaviour
{
		public GameObject player;
		public string levelName;
		public Vector2 position;
		public bool displayPosition = true;

		void Update ()
		{
				levelName = GameState.GetLevelName () + "\n";
				if (player) {
						guiText.text = GameState.GetLevel () + ": " + levelName;
						if (displayPosition) {
								guiText.text += (int)player.transform.position.x / 20 + " : " + (int)player.transform.position.y / 20;
						} else {
								guiText.text += "N/A";
						}
				} else {
						guiText.text = levelName + "N/A";
				}
		}
}
