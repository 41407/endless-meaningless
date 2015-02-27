using UnityEngine;
using System.Collections;

public class EtherealPlane : MonoBehaviour
{
		public Color starColor;
		public GameObject player;
		public GameObject[] obstacle;
		public GameObject exit;
		public float spawnTime;
		public string levelAchievement;

		void Start ()
		{

				Camera[] cameras = FindObjectsOfType (typeof(Camera)) as Camera[];
				foreach (Camera camera in cameras) {
						if (camera.name.StartsWith ("GUI")) {
								camera.GetComponentInChildren<PositionDisplay> ().displayPosition = false;
						}
						if (camera.name.Equals ("Minimap")) {
								camera.enabled = false;
						}
						if (camera.name.StartsWith ("Game")) {
								camera.GetComponentInChildren<ParticleSystem> ().startColor = starColor;
								
						}
				}
		}

		void Update ()
		{
				if (!IsInvoking () && player) {
						int randomVariable = Random.Range (0, 100);
						if (randomVariable < 90) {
								Invoke ("SpawnRandomMonster", spawnTime);
						} else if (randomVariable < 97) {
								Invoke ("SpawnObstacle", spawnTime);
						} else {
								print ("Exit spawned'!");
								Invoke ("SpawnExit", spawnTime);
						}	
				}
		}

		void SpawnRandomMonster ()
		{
				GameObject enemy = Spawn.enemy.AtRandom (player.transform.position - Vector3.left * 50, Quaternion.identity);
				enemy.transform.position = Quaternion.AngleAxis (Random.Range (0, 360), Vector3.forward) * Vector3.up * 50 + player.transform.position;
				enemy.AddComponent<OutOfLOSDecay> ().time = 1;
		}

		void SpawnObstacle ()
		{
				GameObject newObstacle = (GameObject)Instantiate (obstacle [Random.Range (0, obstacle.Length)], player.transform.position - Vector3.left * 80, Quaternion.identity);
				newObstacle.transform.position = Quaternion.AngleAxis (Random.Range (0, 360), Vector3.forward) * Vector3.up * 50 + player.transform.position;
				newObstacle.AddComponent<OutOfLOSDecay> ().time = 1;
		}

		void SpawnExit ()
		{
				GameObject newExit = (GameObject)Instantiate (exit, player.transform.position - Vector3.left * 80, Quaternion.identity);
				newExit.transform.position = Quaternion.AngleAxis (Random.Range (0, 360), Vector3.forward) * Vector3.up * 50 + player.transform.position;
				newExit.AddComponent<OutOfLOSDecay> ().time = 1;
				newExit.GetComponent<StairsDown> ().achievement = levelAchievement;
				newExit.GetComponent<StairsDown> ().specialLevel = false;
		}
}
