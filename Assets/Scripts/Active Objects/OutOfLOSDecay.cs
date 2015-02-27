using UnityEngine;
using System.Collections;

public class OutOfLOSDecay : MonoBehaviour
{

		public float time = 2.0f;

		void OnBecameInvisible ()
		{
				Invoke ("Deactivate", time);
		}
	
		void OnBecameVisible ()
		{
				CancelInvoke ();
		}

		void Deactivate ()
		{
				gameObject.SetActive (false);
		}

		void OnDisable ()
		{
				CancelInvoke ();
		}
}
