using UnityEngine;
using System.Collections;

public class InventoryDisplay : MonoBehaviour
{

		public GameObject player;

		void UpdateDisplay (string text)
		{
				guiText.text = "Inventory:\n";
				guiText.text += text;
		}
}
