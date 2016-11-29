using UnityEngine;
using System.Collections;

public class ZombieRunning : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if(!PersistentData.current.IsGamePaused())
		{
			transform.position += Vector3.right * 0.17f;
		}
	}
}

