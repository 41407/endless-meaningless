using UnityEngine;
using System.Collections;

public class SoundPitchRandomizer : MonoBehaviour
{

		public float pitchMin = 0.9f;
		public float pitchMax = 1.1f;
		public float volumeMin = 1.0f;
		public float volumeMax = 1.0f;

		void OnEnable ()
		{
				audio.pitch = Random.Range (pitchMin, pitchMax);
				audio.volume = Random.Range (volumeMin, volumeMax);
		}
}
