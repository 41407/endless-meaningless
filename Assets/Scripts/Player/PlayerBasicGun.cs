using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBasicGun : MonoBehaviour
{
		public float bulletYOffset;
		public List<PropertyValue> defaultProperties;
		public List<PropertyValue> properties;
		private float shotCooldown;

		void Start ()
		{
				ApplyInventory (null);
		}

		void Update ()
		{
				shotCooldown -= Time.deltaTime;
				if (gameObject.GetComponent<PlayerFiring> ().firing && shotCooldown <= 0) {
						Shoot ();
						shotCooldown = GetPropertyValue (Property.RateOfFire);
				}
		}

		private void Shoot ()
		{
				GameObject newBullet = Fire.bullet.PlayerBullet (transform.position + transform.rotation * Vector2.up * bulletYOffset, transform.rotation);

				// Activate pooled object
				newBullet.SetActive (true);

				newBullet.GetComponent<BulletStats> ().maxRicochets = Mathf.FloorToInt (GetPropertyValue (Property.BouncesOffWalls));
				newBullet.GetComponent<DamageDealer> ().damage = (Mathf.FloorToInt (GetPropertyValue (Property.Damage)));
				
				// Inherit parent object's velocity
				newBullet.rigidbody2D.velocity = rigidbody2D.velocity;
				newBullet.rigidbody2D.AddForce (transform.rotation * Vector2.up * GetPropertyValue (Property.BulletVelocity));
		}

		public void ApplyInventory (List<GameObject> items)
		{
				properties.Clear ();
				foreach (PropertyValue p in defaultProperties) {
						properties.Add (new PropertyValue (p.property, p.value));
				}
				if (items != null) {
						foreach (GameObject g in items) {
								PropertyValue[] itemProperties = g.GetComponent<Item> ().properties;
								for (int i = 0; i < itemProperties.Length; i++) {
										AdjustValue (itemProperties [i].property, itemProperties [i].value);
								}
						}
				}
		}

		private float GetPropertyValue (Property p)
		{
				return FindProperty (p) < properties.Count ? properties [FindProperty (p)].value : 0;
		}

		private void AdjustValue (Property property, float value)
		{
				
				int i = FindProperty (property);
				if (i >= properties.Count) {
						properties.Add (new PropertyValue (property, value));
				} else {
						properties [i].value += value;
				}
		}

		private int FindProperty (Property property)
		{
				int i;
				for (i = 0; i < properties.Count; i++) {
						if (properties [i].property == property) {
								return i;
						}
				}
				return properties.Count;
		}
}
