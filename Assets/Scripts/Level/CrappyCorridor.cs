using UnityEngine;
using System.Collections;

public class CrappyCorridor : MonoBehaviour
{
		public GameObject[] nextRoom;
		public float minAngle = 0;
		public float maxAngle = 0;

		void Update ()
		{
				Instantiate (nextRoom [Random.Range (0, nextRoom.Length)],
			                      transform.position,
			                      transform.rotation * Quaternion.AngleAxis (Random.Range (minAngle, maxAngle),
			                      Vector3.forward));
				Destroy (gameObject);
		}
}
