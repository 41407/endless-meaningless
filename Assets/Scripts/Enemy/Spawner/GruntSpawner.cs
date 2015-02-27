using UnityEngine;
using System.Collections;

public class GruntSpawner : MonoBehaviour
{
		public float spawnInterval;

		void OnTriggerEnter2D (Collider2D coll)
		{
				if (coll.gameObject.tag == "Player") {
						InvokeRepeating ("SpawnEnemy", spawnInterval, spawnInterval);
				}
		}
	
		void OnTriggerExit2D (Collider2D coll)
		{
				if (coll.gameObject.tag == "Player") {
						CancelInvoke ();
				}
		}

		void SpawnEnemy ()
		{
				Physics2D.IgnoreCollision ((Spawn.enemy.Grunt (transform.position, transform.rotation)).collider2D, transform.parent.gameObject.collider2D);
		}
}
