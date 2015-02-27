using UnityEngine;
using System.Collections;

public class LevelMessage : MonoBehaviour
{

		public string message;
		public int lineWidth = 32;
		public float timeBetweenCharacters = 0.016f;
		public float timeSinceLastCharacter = 0;
		public int charactersInLine = 0;
		public int currentCharacter = 0;
		public float decayTime = 5.0f;
		public float currentTime = 0f;

		void Start ()
		{
				guiText.text = "";
				currentCharacter = 0;
		}

		void Update ()
		{
	
				message = GameState.GetLevelMessage ();
						
				if (currentCharacter < message.Length) {
						printCharacters ();
				} else {
						fadeText ();
				}

		}

		void printCharacters ()
		{
				timeSinceLastCharacter += Time.deltaTime;
				if (timeSinceLastCharacter > timeBetweenCharacters) {
						timeSinceLastCharacter = 0;
						if (currentCharacter < message.Length) {
								guiText.text += message [currentCharacter];
								if (message [currentCharacter] == ' ' && charactersInLine > lineWidth) {
										guiText.text += "\n";
										charactersInLine = 0;
								}
								charactersInLine++;
								currentCharacter++;
						}
				}
		}

		void fadeText ()
		{
				currentTime += Time.deltaTime;
				if (currentTime >= decayTime) {
						Color newColor = guiText.color;
						newColor.a -= Time.deltaTime;
						guiText.color = newColor;
				}
				if (guiText.color.a <= 0) {
						Destroy (gameObject);
				}
		}
}
