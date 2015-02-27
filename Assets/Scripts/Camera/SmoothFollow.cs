using UnityEngine;
using System.Collections;
using System;

public class SmoothFollow : MonoBehaviour
{

		public GameObject player;
		public float z;

		void Update ()
		{
				if (player) {
						gameObject.transform.position = player.transform.position;
						transform.position = new Vector3 (transform.position.x, transform.position.y, z);
				}
		}
}
