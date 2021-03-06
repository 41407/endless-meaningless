﻿using UnityEngine;
using System.Collections;

public class Wasp : MonoBehaviour
{
		public GameObject player;
		public float turningSpeed;
		public float moveSpeed;
		public float bulletVelocity;
		public float firingWindup = 1;
		public float rateOfFire = 1;
		public float range = 20;
		public float bulletOffset = 1;
		public float stalkDistance = 10;

		void Update ()
		{
				if (player) {
						TurnTowardsPlayer ();
						if (Vector2.Distance (player.transform.position, transform.position) > stalkDistance) {
								rigidbody2D.AddForce (transform.rotation * Vector2.up * moveSpeed * Time.deltaTime);
						} else {
								rigidbody2D.AddForce (transform.rotation * Vector2.up * - 2 * moveSpeed * Time.deltaTime);
						}
				} else {
						CancelInvoke ();
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
				if (Mathf.Abs (angleBetween - angle) < 10 && Vector3.Distance (transform.position, player.transform.position) < range) {
						if (!IsInvoking ()) {
								InvokeRepeating ("Shoot", firingWindup, rateOfFire);
						}
				} else {
						CancelInvoke ();		
				}
				if (angleBetween - angle > 0) {
						gameObject.transform.Rotate (new Vector3 (0, 0, turningSpeed * Time.deltaTime));
				} else {
						gameObject.transform.Rotate (new Vector3 (0, 0, -turningSpeed * Time.deltaTime));
				}	
		}

		void Shoot ()
		{
				
				GameObject newBullet = Fire.bullet.EnemyBullet (transform.position + transform.rotation * Vector3.up * bulletOffset, transform.rotation);
				newBullet.SetActive (true);		
				newBullet.rigidbody2D.velocity = gameObject.rigidbody2D.velocity;
				newBullet.rigidbody2D.AddForce (transform.rotation * Vector2.up * bulletVelocity);
				newBullet.rigidbody2D.AddForce (player.rigidbody2D.velocity);
				
		}

		void OnDisable ()
		{
				CancelInvoke ();
		}

		void ZeroHealth ()
		{
		}

		
}
