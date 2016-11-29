using UnityEngine;
using System.Collections;

public class SetBackground : MonoBehaviour
{
	public GUITexture background;
	// Use this for initialization
	void Start ()
	{
		background.pixelInset = new Rect(-Screen.width/2 - 10,-Screen.height/2 - 10,Screen.width + 10, Screen.height + 10);
	}

	// Update is called once per frame
	void Update ()
	{

	}
}

