using UnityEngine;
using System.Collections;

public class RandomTexture : MonoBehaviour
{

		public Texture[] sprites;

		void OnEnable ()
		{
				RandomizeTexture ();
		}

		void RandomizeTexture ()
		{
				renderer.material.mainTexture = sprites [Random.Range (0, sprites.Length)];
				transform.Rotate (Vector3.forward, 90);
		}

		void OnCollisionEnter2D (Collision2D c)
		{
				if (Random.value > 0.800f) {
						RandomizeTexture ();
				}
		}
}
