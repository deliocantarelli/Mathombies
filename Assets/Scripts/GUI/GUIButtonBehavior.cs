using UnityEngine;
using System.Collections;

public class GUIButtonBehavior : MonoBehaviour {
	private int counter;
	public float multiplierConstant;
	
	private Rect originalSize;
	
	public delegate void ClickFunction();
	private ClickFunction clickFunction;
	
	public bool canPress = true;
	
	public void Initialize(ClickFunction clickFunction)
	{
		originalSize = guiTexture.pixelInset;
		this.clickFunction = clickFunction;
		counter = 0;
	}
	
	// Update is called once per frame
	void OnMouseOver()
	{
		if(counter < 5)													//animaćao
		{
			counter ++;
			float newWidth = guiTexture.pixelInset.width + (guiTexture.pixelInset.width * multiplierConstant);
			float newHeight = guiTexture.pixelInset.height + (guiTexture.pixelInset.height * multiplierConstant);
			guiTexture.pixelInset = new Rect(guiTexture.pixelInset.x - (newWidth - guiTexture.pixelInset.width)/2, guiTexture.pixelInset.y - (newHeight - guiTexture.pixelInset.height)/2, newWidth, newHeight);
		}
	}
	void OnMouseExit()
	{
		ReturnToNormal();
	}

	void OnMouseUpAsButton()
	{
		ReturnToNormal();
		clickFunction();
	}

	
	void ReturnToNormal()
	{
		counter = 0;
		guiTexture.pixelInset = originalSize;
	}
}
