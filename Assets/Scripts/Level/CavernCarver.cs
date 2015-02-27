using UnityEngine;
using System.Collections;

public class CavernCarver : MonoBehaviour
{
		public GameObject obstacle;
		public float xOffset = -100;
		public float yOffset = -100;
		public int gridDimensionX = 30;
		public int gridDimensionY = 30;
		public int[,] grid = new int[30, 30];

		void Start ()
		{
				for (int j = 0; j<grid.GetLength(0); j++) {
						for (int i = 0; i < grid.GetLength(1); i++) {
								grid [i, j] = Random.Range (0, 2);
								if (i == 0 || i == gridDimensionX-1 || j == 0 || j == gridDimensionY-1) {
										grid [i, j] = 1;
								} else if (i == 5 || j == 5) {
										grid [i, j] = 0;
								}
						}
				}
				for (int j = 0; j<grid.GetLength(0); j++) {
						for (int i = 0; i < grid.GetLength(1); i++) {
								if (grid [i, j] > 0) {
										Instantiate (obstacle, transform.rotation * new Vector3 (i * 20 + xOffset, j * 20 + yOffset, 0), transform.rotation);
								}
						}
				}
		}
}
