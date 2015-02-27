using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fire : MonoBehaviour
{
		public GameObject playerBullet;
		public int playerPoolSize;
		public GameObject enemyBullet;
		public int enemyPoolSize;

		//Here is a private reference only this class can access
		private static Fire _instance;
	
		//This is the public reference that other classes will use
		public static Fire bullet {
				get {
						//If _instance hasn't been set yet, we grab it from the scene!
						//This will only happen the first time this reference is used.
						if (_instance == null)
								_instance = GameObject.FindObjectOfType<Fire> ();
						return _instance;
				}
		}

		void OnEnable ()
		{
				ObjectPool.pool.Initialize (playerBullet, playerPoolSize);
				ObjectPool.pool.Initialize (enemyBullet, enemyPoolSize);
		}
	
		public GameObject PlayerBullet (Vector2 position, Quaternion rotation)
		{
				return ObjectPool.pool.Pull (playerBullet, position, rotation);
		}

		public GameObject EnemyBullet (Vector2 position, Quaternion rotation)
		{
				return ObjectPool.pool.Pull (enemyBullet, position, rotation);
		}
}
