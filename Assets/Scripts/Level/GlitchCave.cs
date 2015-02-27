using UnityEngine;
using System.Collections;

public class GlitchCave : MonoBehaviour
{
		public GameObject monster;
		public Sprite[] monsterSprites;
		public GameObject player;

		void Start ()
		{
		
				Camera[] cameras = FindObjectsOfType (typeof(Camera)) as Camera[];
				foreach (Camera camera in cameras) {
						if (camera.name.StartsWith ("GUI")) {
								camera.GetComponentInChildren<HealthDisplay> ().glitch = true;
						}
				}
				InvokeRepeating ("ChangeTimescale", 2, 2);
				InvokeRepeating ("SpawnRandomMonster", 2, 2);
		}

		void Update ()
		{
				if (Time.timeScale > 1) {
						Time.timeScale -= 0.2f;
				} else if (Time.timeScale < 0.9f) {
						Time.timeScale += 0.1f;
				}
		}

		void SpawnRandomMonster ()
		{
				GameObject enemy = ObjectPool.pool.Pull (monster, player.transform.position - Vector3.left * 50, Quaternion.identity);
				enemy.SetActive (true);
				enemy.GetComponent<SpriteRenderer> ().sprite = monsterSprites [Random.Range (0, monsterSprites.Length)];
				enemy.transform.localScale = Vector3.one * 2;
				enemy.GetComponent<GlitchEnemy> ().player = player;
				enemy.transform.position = Quaternion.AngleAxis (Random.Range (0, 360), Vector3.forward) * Vector3.up * 50 + player.transform.position;
		}

		void ChangeTimescale ()
		{
				Time.timeScale = Random.Range (0.1f, 3.5f);
		}
}
