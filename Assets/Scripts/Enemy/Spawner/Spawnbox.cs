using UnityEngine;
using System.Collections;

public class Spawnbox : MonoBehaviour
{
		void ZeroHealth ()
		{
				float angle = 0;
				Vector3 axis = Vector3.forward;
				transform.rotation.ToAngleAxis (out angle, out axis);
				for (int i = 0; i<16; i++) {
						Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
						angle += 22.5f;
						GameObject newBullet = Fire.bullet.EnemyBullet (transform.position, Quaternion.identity);
						newBullet.SetActive (true);
						newBullet.rigidbody2D.AddForce (rotation * Vector2.up * 200);
				}
		}
}
