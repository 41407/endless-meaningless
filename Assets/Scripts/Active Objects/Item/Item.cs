using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
		public string itemName;
		public float gracePeriod = 2.0f;
		public Sprite sprite;
		public PropertyValue[] properties;

		private bool gracePeriodOff;
	
		void OnEnable ()
		{
				gameObject.GetComponent<SpriteRenderer> ().sprite = sprite;
				gracePeriodOff = false;
				Invoke ("EndGracePeriod", gracePeriod);
		}

		void EndGracePeriod ()
		{
				gracePeriodOff = true;
		}

		void OnDisable ()
		{
				CancelInvoke ();
		}

		void OnCollisionEnter2D (Collision2D coll)
		{
				if (coll.gameObject.tag == "Player" && gracePeriodOff) {
						coll.gameObject.SendMessage ("PickUp", gameObject);
				}
		}
}
