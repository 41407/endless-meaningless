using UnityEngine;
using System.Collections;

public class PlayerFiring : MonoBehaviour
{
		public bool firing = false;
		
		void Update ()
		{
				if (Input.GetMouseButtonDown (0)) {
						firing = true;
				}
				if (Input.GetMouseButtonUp (0)) {
						firing = false;
				}
		}
}
