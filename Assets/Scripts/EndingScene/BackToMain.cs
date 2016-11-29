using UnityEngine;
using System.Collections;

public class BackToMain : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		StartCoroutine("Wait5Seconds");
	}

	private IEnumerator Wait5Seconds()
	{
		yield return new WaitForSeconds(5);
		Application.LoadLevel("GameStarter");
	}
}

