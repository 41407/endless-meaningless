using UnityEngine;
using System.Collections;

public class ConstantMotion : MonoBehaviour
{

		public Vector3 motion;

		void Update ()
		{
				transform.Translate (motion * Time.deltaTime);
		}
}
