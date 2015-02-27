using UnityEngine;
using System.Collections;

public class StairsDown : MonoBehaviour
{
		public string achievement;
		public bool specialLevel = false;

		void OnCollisionEnter2D (Collision2D coll)
		{
				if (coll.gameObject.tag == "Player") {
						if (achievement.Length > 0) {
								Achievements.Add (achievement);
						}
						GameState.SetInventory (coll.gameObject.GetComponent<Inventory>().items);
						GameState.SetSpecialLevel (specialLevel);
						GameState.AdvanceLevel ();
						Application.LoadLevel (0);
				}
		}
}
