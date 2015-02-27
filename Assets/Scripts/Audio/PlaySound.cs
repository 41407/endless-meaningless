using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour
{

		public bool onEnable = true;

		void OnEnable ()
		{
				if (onEnable) {
						audio.Play ();
				}
		}
}
