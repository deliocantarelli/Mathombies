using UnityEngine;
using System.Collections;

public class LoadBeginning : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		GUIButtonBehavior guiButton = this.GetComponent("GUIButtonBehavior") as GUIButtonBehavior;
		guiButton.Initialize(NextLevel);
	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void NextLevel()
	{
		Application.LoadLevel("RunningScene");
	}
}

