using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
		public GameObject player;
		public GameObject item;
		public GameObject brute;
		public GameObject grunt;
		public GameObject butterfly;
		public GameObject wasp;
		public GameObject goblin;
		public GameObject scarab;

		//Here is a private reference only this class can access
		private static Spawn _instance;
	
		//This is the public reference that other classes will use
		public static Spawn enemy {
				get {
						//If _instance hasn't been set yet, we grab it from the scene!
						//This will only happen the first time this reference is used.
						if (_instance == null)
								_instance = GameObject.FindObjectOfType<Spawn> ();
						return _instance;
				}
		}

		GameObject InitializeParameters (GameObject enemy)
		{
				enemy.SetActive (true);
				enemy.SendMessage ("SetPlayer", player);
				return enemy;
		}

		/**
		 * This is useful for spawners
		 */
		public GameObject ByReference (GameObject gameObject, Vector2 position, Quaternion rotation)
		{
				return InitializeParameters (ObjectPool.pool.Pull (gameObject, position, rotation));
		}

		public GameObject Item (Vector2 position, Quaternion rotation)
		{
				return InitializeParameters (ObjectPool.pool.Pull (item, position, rotation));
		}

		public GameObject Brute (Vector2 position, Quaternion rotation)
		{
				return InitializeParameters (ObjectPool.pool.Pull (brute, position, rotation));
		}

		public GameObject Grunt (Vector2 position, Quaternion rotation)
		{
				return InitializeParameters (ObjectPool.pool.Pull (grunt, position, rotation));
		}

		public GameObject Butterfly (Vector2 position, Quaternion rotation)
		{
				return InitializeParameters (ObjectPool.pool.Pull (butterfly, position, rotation));
		}

		public GameObject Wasp (Vector2 position, Quaternion rotation)
		{
				return InitializeParameters (ObjectPool.pool.Pull (wasp, position, rotation));
		}
	
		public GameObject Goblin (Vector2 position, Quaternion rotation)
		{
				return InitializeParameters (ObjectPool.pool.Pull (goblin, position, rotation));
		}
	
		public GameObject Scarab (Vector2 position, Quaternion rotation)
		{
				return InitializeParameters (ObjectPool.pool.Pull (scarab, position, rotation));
		}

		public GameObject AtRandom (Vector2 position, Quaternion rotation)
		{
				int enemyTypes = 6;
				int random = Random.Range (0, 500) % enemyTypes;
				switch (random) {
				case 0:
						return Brute (position, rotation);
				case 1:
						return Grunt (position, rotation);
				case 2:
						return Butterfly (position, rotation);
				case 3:
						return Wasp (position, rotation);
				case 4:
						return Goblin (position, rotation);
				case 5:
						return Scarab (position, rotation);
				}
				return Goblin (position, rotation);
		}
}
