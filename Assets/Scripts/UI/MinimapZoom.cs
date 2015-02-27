using UnityEngine;
using System.Collections;

public class MinimapZoom : MonoBehaviour
{
		void Update ()
		{
				float zoomAmount = Input.GetAxisRaw ("Mouse ScrollWheel") * -50;
				gameObject.camera.orthographicSize = Mathf.Clamp (gameObject.camera.orthographicSize + zoomAmount, 200f, 800f);
		}
}
