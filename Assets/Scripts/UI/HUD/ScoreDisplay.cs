using UnityEngine;
using System.Collections;

public class ScoreDisplay : MonoBehaviour
{
		void Update ()
		{
				guiText.text = "$" + Score.GetScore ();
		}
}
