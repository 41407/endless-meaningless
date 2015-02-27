using UnityEngine;
using System.Collections;

public class GlitchEnemy : MonoBehaviour
{
		public GameObject player;
		public float turningSpeed;
		public float moveSpeed;
		public float bulletVelocity;
		public float glitchTimeMin = 1;
		public float glitchTimeMax = 5;
	
		void Update ()
		{
				if (player) {
						TurnTowardsPlayer ();
				}
				if (!IsInvoking ()) {
						Invoke ("Glitch", Random.Range (glitchTimeMin, glitchTimeMax));
				}
				rigidbody2D.AddForce (transform.rotation * Vector2.up * moveSpeed * Time.deltaTime);
		}
	
		public void SetPlayer (GameObject player)
		{
				this.player = player;
		}

		void Glitch ()
		{
				transform.Translate (Random.Range (-5, 5), Random.Range (-5, 5), 0);
				transform.rotation = Quaternion.AngleAxis (Random.Range (0, 360), Vector3.forward);
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
				if (angleBetween - angle > 0) {
						gameObject.transform.Rotate (new Vector3 (0, 0, turningSpeed * Time.deltaTime));
				} else {
						gameObject.transform.Rotate (new Vector3 (0, 0, -turningSpeed * Time.deltaTime));
				}	
		}
	
		void ZeroHealth ()
		{
				FireBulletsInPlusShapeFormat ();
		}
	
		void FireBulletsInPlusShapeFormat ()
		{
				float angle = 0;
				Vector3 axis = Vector3.forward;
				transform.rotation.ToAngleAxis (out angle, out axis);
				for (int i = 0; i<Random.Range(1,10); i++) {
						Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
						angle += Random.Range (0, 360);
						GameObject newBullet = Fire.bullet.EnemyBullet (transform.position, Quaternion.identity);
						newBullet.SetActive (true);
						newBullet.rigidbody2D.velocity = gameObject.rigidbody2D.velocity;
						newBullet.rigidbody2D.AddForce (rotation * Vector2.up * bulletVelocity);
				}
		}
}
