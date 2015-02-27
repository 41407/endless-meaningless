using UnityEngine;
using System.Collections;

public class Decay : MonoBehaviour
{
		public float timeToLive;
		public bool pooledObject = false;

		void OnEnable ()
		{
				Invoke ("Destroy", timeToLive);
		}

		void Destroy ()
		{
				if (pooledObject) {
						gameObject.SetActive (false);
				} else {
						Destroy (gameObject);
				}
		}
		
		void OnDisable ()
		{
				CancelInvoke ();
		}
}
