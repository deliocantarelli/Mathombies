using UnityEngine;
using System.Collections;

public class ShowDialog : MonoBehaviour
{
	public GUITexture background;
	public float fadingSpeed;

	private int dialogToShow;
	private bool backgroundFading;
	private Texture[] dialogs;

	void Start ()
	{
		if(PersistentData.current.place[1] == 0 && !PersistentData.current.WasDialogShowed())
		{
			PersistentData.current.DialogShowed();
			PersistentData.current.PauseGame();
			//set black on the background
			Rect screenSize = new Rect(-Screen.width/2, -Screen.height/2, Screen.width, Screen.height);

			background.pixelInset = screenSize;

			Color newColor = background.color;
			newColor.a = 0.1f;
			background.color = newColor;




			//set the dialogs

			
			Rect newPixelInset = guiTexture.pixelInset;
			newPixelInset.width = 0.8f* Screen.width;
			newPixelInset.height = 0.3f * Screen.height;
			newPixelInset.x = -0.4f*Screen.width;
			guiTexture.pixelInset = newPixelInset;


			dialogToShow = 0;
			if(PersistentData.current.place[0] == 0)			//shows history
			{
				dialogs = PersistentData.current.dialogHistory;
			}
			else 												//shows only the start dialog
			{
				dialogs = PersistentData.current.startDialog;
			}
			guiTexture.texture = dialogs[dialogToShow];
		}
		else
		{
			Destroy(background.gameObject);
			Destroy(gameObject);
		}

	}

	void Update ()
	{
		if(PersistentData.current.IsGamePaused() && Input.GetKeyDown(KeyCode.Return))
		{
			dialogToShow ++;
			if(dialogToShow < dialogs.Length)
			{
				NextDialog();
			}
			else
			{
				EraseDialog();
				backgroundFading = true;
			}
		}
		if(backgroundFading)
		{
			if(background.color.a > 0)
			{
				FadeBackground();
			}
			else
			{
				PersistentData.current.UnpauseGame();
				Destroy(background.gameObject);
				Destroy(gameObject);
			}
		}
	}

	private void NextDialog()
	{
		guiTexture.texture = dialogs[dialogToShow];
	}
	private void EraseDialog()
	{
		Color newColor = guiTexture.color;
		newColor.a = 0;
		guiTexture.color = newColor;
	}
	private void FadeBackground()
	{
		Color newColor = background.guiTexture.color;
		newColor.a -= fadingSpeed;
		background.guiTexture.color = newColor;
	}
}

