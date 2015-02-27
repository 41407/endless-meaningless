using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
		public GameObject objectToSpawn;
		public int poolSize = 10;
		public float spawnInterval;
		public bool applyChildSprite = true;

		void OnEnable ()
		{
				ObjectPool.pool.Initialize (objectToSpawn, poolSize);
				if (applyChildSprite) {
						gameObject.GetComponent<SpriteRenderer> ().sprite = objectToSpawn.GetComponent<SpriteRenderer> ().sprite;
				}
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
