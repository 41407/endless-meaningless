using UnityEngine;
using System.Collections;

public class BulletStats : MonoBehaviour
{
		public int maxRicochets;
		private int currentRicochets;
		public GameObject explosion;
		public GameObject ricochet;
		public string enemyString = "Enemy";

		void OnEnable ()
		{
				if (explosion) {
						ObjectPool.pool.Initialize (explosion);
				}
				if (ricochet) {
						ObjectPool.pool.Initialize (ricochet);
				}
				currentRicochets = 0;
		}

		void OnCollisionEnter2D (Collision2D coll)
		{
				currentRicochets ++;
				
				if (ricochet) {
						// Instantiate (ricochet, transform.position, transform.rotation);
						ObjectPool.pool.Pull (ricochet, transform.position, transform.rotation).SetActive (true);
				}
				CheckHealth ();
		}

		void CheckHealth ()
		{
				if (currentRicochets > maxRicochets) {
						if (explosion) {
								//							Instantiate (explosion, transform.position, transform.rotation);
								ObjectPool.pool.Pull (explosion, transform.position, transform.rotation).SetActive (true);
						}
						gameObject.SetActive (false);
				}
		}
}
