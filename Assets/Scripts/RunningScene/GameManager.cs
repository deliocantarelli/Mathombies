using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public GameObject character;
	public GameObject zombie;

	private bool loadRenderer;
	// Use this for initialization
	void Awake ()
	{
		loadRenderer = false;
		character = Instantiate(PersistentData.current.GetCurrentCharacter()) as GameObject;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if(!character.renderer.isVisible)
		{
			if(loadRenderer)
			{
				Application.LoadLevel("GateScene");
			}
			loadRenderer = true;
		}
		else if(zombie.renderer.bounds.max.x >= character.renderer.bounds.min.x + 0.4f)
		{
			PersistentData.current.ResetLevel();
			Application.LoadLevel("GameOver");
		}
	}
}

