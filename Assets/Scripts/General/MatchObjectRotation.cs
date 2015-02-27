using UnityEngine;
using System.Collections;

public class MatchObjectRotation : MonoBehaviour
{

		public GameObject objectToMatch;

		void Update ()
		{
				transform.rotation = objectToMatch.transform.rotation;
		}
}
