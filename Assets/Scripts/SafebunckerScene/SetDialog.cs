using UnityEngine;
using System.Collections;

public class SetDialog : MonoBehaviour
{

	void Start ()
	{
		Rect newPixelInset = guiTexture.pixelInset;
		newPixelInset.width = 0.8f* Screen.width;
		newPixelInset.height = 0.3f * Screen.height;
		newPixelInset.x = -0.4f*Screen.width;
		guiTexture.pixelInset = newPixelInset;
		guiTexture.texture = PersistentData.current.safebunckerDialogs[PersistentData.current.place[0] - 1];			//because it has already changed when calling it
	}

	void Update ()
	{

	}
}

