using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{

		public List<GameObject> items;
		public GameObject display;

		void Start ()
		{
				if (GameState.GetInventory () != null) {
						items = GameState.GetInventory ();
				} else {
						Reset ();
				}
				UpdateInventory ();
		}

		private void UpdateInventory ()
		{
				display.SendMessage ("UpdateDisplay", InventoryToString ());
				gameObject.SendMessage ("ApplyInventory", items);
		}

		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.Alpha1)) {
						Drop (0);
				}
		}

		public void Reset ()
		{
				items = new List<GameObject> ();
		}

		public void PickUp (GameObject item)
		{
				items.Add (item);
				item.SetActive (false);
				UpdateInventory ();
		}

		public void Drop (GameObject item)
		{
				items.Remove (item);
				item.SetActive (true);
				item.transform.position = gameObject.transform.position;
				UpdateInventory ();
		}

		public void Drop (int slot)
		{
				Drop (items [slot]);
		}

		public string InventoryToString ()
		{
				if (items.Count == 0) {
						return "Empty\n";
				}
				string returnString = "";
				int i = 1;
				foreach (GameObject item  in items) {
						returnString = returnString + "" + i + ":";		
						returnString += item.GetComponent<Item> ().itemName;
						returnString += "\n";
				}
				return returnString;
		}
}
