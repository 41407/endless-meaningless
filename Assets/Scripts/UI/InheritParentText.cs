using UnityEngine;
using System.Collections;

public class InheritParentText : MonoBehaviour
{

		void Update ()
		{
				guiText.text = transform.parent.GetComponent<GUIText> ().text;
				Color newColor = guiText.color;
				newColor.a = transform.parent.GetComponent<GUIText> ().color.a;
				guiText.color = newColor;
		}
}
