using UnityEngine;
using System.Collections;

public class MousePointer : MonoBehaviour
{
		public float z = -18;
		public bool showOSCursor;

		void Start ()
		{
				Screen.showCursor = showOSCursor;
		}

		void Update ()
		{
				Vector3 newPosition = CameraLogic.GetWorldPositionOnPlane (Input.mousePosition, 0);
				newPosition.z = z;
				transform.position = newPosition;
		}
}
