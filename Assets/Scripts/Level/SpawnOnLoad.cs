using UnityEngine;
using System.Collections;

public class SpawnOnLoad : MonoBehaviour
{
		public GameObject objectToSpawn;
		public bool pooledObject = false;
		public bool monster = false;
		public int poolSize = 0;

		void Start ()
		{
				if (monster) {
						Spawn.enemy.ByReference (objectToSpawn, transform.position, transform.rotation);
				} else if (pooledObject) {
						ObjectPool.pool.Initialize (objectToSpawn, poolSize);
						ObjectPool.pool.Pull (objectToSpawn, transform.position, transform.rotation);
				} else {
						Instantiate (objectToSpawn, transform.position, transform.rotation);
				}
				Destroy (gameObject);
		}
}
