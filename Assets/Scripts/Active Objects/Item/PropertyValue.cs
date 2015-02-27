using UnityEngine;
using System.Collections;

[System.Serializable]
public class PropertyValue {
	public Property property;
	public float value;

	public PropertyValue(Property p, float v) {
		property = p;
		value = v;
	}
}
