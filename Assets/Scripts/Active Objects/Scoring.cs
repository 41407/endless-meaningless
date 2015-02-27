using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour
{
		public string enemyName;
		public int scoreOnDeath = 0;

		void ApplyScoring ()
		{
				Score.AddScore (scoreOnDeath);
				Kills.Add (enemyName);
		}
}
