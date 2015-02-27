using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
		public float acceleration;
		public float maxSpeed;
		public bool relative;

		void FixedUpdate ()
		{
				if (Input.GetKeyDown (KeyCode.LeftShift)) {
						relative = true;
				}
				if (Input.GetKeyUp (KeyCode.LeftShift)) {
						relative = false;
				}
				Vector2 movementVector;
				movementVector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
				if (relative) {
						rigidbody2D.AddForce (transform.rotation * movementVector.normalized * acceleration);
				} else {
						rigidbody2D.AddForce (movementVector.normalized * acceleration);
				}
				LimitSpeed ();
		}

		void LimitSpeed ()
		{
				if (rigidbody2D.velocity.magnitude > maxSpeed) {
						rigidbody2D.velocity = rigidbody2D.velocity.normalized * maxSpeed;
				}
		}
}
