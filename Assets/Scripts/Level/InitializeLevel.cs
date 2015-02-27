using UnityEngine;
using System.Collections;

public class InitializeLevel : MonoBehaviour
{
		public GameObject[] levels;
		public GameObject player;

		void Start ()
		{
				print ("hello world " + GameState.GetLevel () + " !");
				GameObject level = (GameObject)Instantiate (levels [Random.Range (0, levels.Length)], Vector3.zero, Quaternion.identity);
				if (level.GetComponent<EtherealPlane> ()) {
						level.GetComponent<EtherealPlane> ().player = player;
				}
				if (level.GetComponent<GlitchCave> ()) {
						level.GetComponent<GlitchCave> ().player = player;
				}

		}

		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.F)) {
						Spawn.enemy.Wasp (Camera.main.transform.position, Quaternion.identity);
				}
				if (Input.GetKeyDown (KeyCode.G)) {
						Spawn.enemy.Butterfly (Camera.main.transform.position, Quaternion.identity);
				}
				if (Input.GetKeyDown (KeyCode.E)) {
						Spawn.enemy.Grunt (Camera.main.transform.position, Quaternion.identity);
				}
				if (Input.GetKeyDown (KeyCode.R)) {
						Spawn.enemy.Brute (Camera.main.transform.position, Quaternion.identity);
				}
		}
}
