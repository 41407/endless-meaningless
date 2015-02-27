using UnityEngine;
using System.Collections;

public class HealthDisplay : MonoBehaviour
{
		public GameObject player;
		public string staticText;
		public bool glitch = false;
	
		void Start ()
		{
				if (staticText.Length > 0) {
						staticText += "\n";
				}
		}
	
		void Update ()
		{
				if (player) {
						if (glitch) {
								if (Time.frameCount % 30 == Random.Range (0,30)) {
										guiText.text = staticText + "0x" + Random.Range (16, 128).ToString ("X");
								}
						} else {
								int healthPercentage = (int)((float)player.GetComponent<Health> ().currentHealth / (float)player.GetComponent<Health> ().health * 100f);
								guiText.text = staticText + healthPercentage + "%";
						}
				} else {
						guiText.text = staticText + "0%";
				}
		}
}
