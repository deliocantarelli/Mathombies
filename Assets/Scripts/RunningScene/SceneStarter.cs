using UnityEngine;
using System.Collections;

public class SceneStarter : MonoBehaviour {
	public GUITexture[] background;

	//public GUITexture outerBackground;
	void Awake () {
		background[0].texture = PersistentData.current.GetCurrentBackground();

		foreach(GUITexture guiTexture in background)
		{
			guiTexture.pixelInset = new Rect(-Screen.width/2 - 10,-Screen.height/2 - 10,Screen.width + 10, Screen.height + 10);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
