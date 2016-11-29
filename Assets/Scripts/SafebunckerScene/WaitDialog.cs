using UnityEngine;
using System.Collections;

public class WaitDialog : MonoBehaviour
{
	public Texture endingTexture;
	// Use this for initialization
	void Start ()
	{
		StartCoroutine("WaitToReadDialog");
	}

	// Update is called once per frame
	void Update ()
	{

	}

	private IEnumerator WaitToReadDialog()
	{
		PersistentData.current.ResetDialog();					//next level now
		yield return new WaitForSeconds(2.5f);
		if(PersistentData.current.place[0] < PersistentData.current.levels.Count)
		{
			Application.LoadLevel("RunningScene");
		}
		else
		{
			ShowEndingDialog();
			yield return new WaitForSeconds(6);
			Application.LoadLevel("GameStarter");
		}
	}

	private void ShowEndingDialog()
	{
		guiTexture.texture = endingTexture;
		PersistentData.current.ResetLevel();			//restart game;
	}
}

