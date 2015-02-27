using UnityEngine;
using System.Collections;

public class BruteSpawner : MonoBehaviour
{
		public GameObject objectToSpawn;
		public int poolSize = 10;
		public float spawnInterval;

		void OnEnable ()
		{
				ObjectPool.pool.Initialize (objectToSpawn, poolSize);
		}

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
				Physics2D.IgnoreCollision ((Spawn.enemy.ByReference (objectToSpawn, transform.position, transform.rotation)).collider2D, transform.parent.gameObject.collider2D);
		}
}
