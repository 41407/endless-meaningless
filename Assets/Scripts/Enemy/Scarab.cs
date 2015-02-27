using UnityEngine;
using System.Collections;

public class Scarab : MonoBehaviour
{
		public GameObject player;
		public float turningSpeed;
		public float moveSpeed;
		public float mineLayingFrequency;
	
		void Update ()
		{
				if (player) {
						TurnTowardsPlayer ();
				}
				rigidbody2D.AddForce (transform.rotation * Vector2.up * moveSpeed * Time.deltaTime);
				if (!IsInvoking ()) {
						InvokeRepeating ("LayMine", mineLayingFrequency, mineLayingFrequency);
				}
		}
	
		public void SetPlayer (GameObject player)
		{
				this.player = player;
		}
	
		void TurnTowardsPlayer ()
		{
				Vector2 heading = player.transform.position - transform.position;
				float angle = transform.rotation.eulerAngles.z;
				float angleBetween = Vector2.Angle (Vector2.up, heading);
				if (heading.x > 0) {
						angleBetween = 360 - angleBetween;
				}
				if (angleBetween - angle > 180) {
						angleBetween -= 360;	
				}
		
				if (angleBetween - angle < -180) {
						angleBetween += 360;	
				}
				if (angleBetween - angle > 90) {
						gameObject.transform.Rotate (new Vector3 (0, 0, turningSpeed * Time.deltaTime));
				} else {
						gameObject.transform.Rotate (new Vector3 (0, 0, -turningSpeed * Time.deltaTime));
				}	
		}
	
		void LayMine ()
		{
				Fire.bullet.EnemyBullet (transform.position, transform.rotation).SetActive (true);
		}
	
		void ZeroHealth ()
		{
				GameObject bullet = Fire.bullet.EnemyBullet (transform.position, transform.rotation);
				bullet.SetActive (true);
				Fire.bullet.EnemyBullet (transform.position, transform.rotation).rigidbody2D.velocity = rigidbody2D.velocity;
		}

		void OnDisable ()
		{	
				CancelInvoke ();
		}
}
