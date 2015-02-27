using UnityEngine;
using System.Collections;

public class RandomRotationOnLoad : MonoBehaviour
{
		public float min = 0;
		public float max = 360;

		void Start ()
		{
				transform.Rotate (Vector3.forward, Random.Range (min, max));
		}
}
