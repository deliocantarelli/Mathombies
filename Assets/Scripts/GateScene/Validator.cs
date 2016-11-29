using UnityEngine;
using System.Collections;

public class Validator : MonoBehaviour
{
	public EquationMaker equationMaker;
	public PlayerAnswer playerAnswer;
	public Texture openLockTexture;
	public GameObject lockObject;
	public GameObject banner;
	public Transform timebar;

	private int timeLimit;
	private float currentTime;
	private Vector3 timebarOriginalSize;

	private bool answered;

	// Use this for initialization
	void Awake ()
	{
		answered = false;
		timeLimit = 10;
		timebarOriginalSize = timebar.localScale;


		StartCoroutine("Wait15SecondsToLose");
	}

	// Update is called once per frame
	void Update ()
	{
		if(!answered)
		{
			UpdateTimebar();
		}
		if(Input.GetKeyDown(KeyCode.Return))
		{
			if(!answered)
			{
				Validate();
			}
		}
	}

	private void Validate()
	{
		answered = true;
		audio.Stop();
		if(playerAnswer.GetAnswer() == equationMaker.GetAnswer())
		{
			lockObject.renderer.material.mainTexture = openLockTexture;
			StartCoroutine("WinWait2Seconds");
		}
		else
		{
			StartCoroutine("LoseWait2Seconds");
		}
	}

	private IEnumerator WinWait2Seconds()
	{
		yield return new WaitForSeconds(1.3f);
		PersistentData.current.nextMap();
		//if(PersistentData.current.nextMap() == 1)
		{
			if(PersistentData.current.place[1] == 0)		//means that a level was complete
			{
				Application.LoadLevel("SafebunckerScene");
			}
			else
			{
				Application.LoadLevel("RunningScene");
			}
		}/*
		else
		{
			Application.LoadLevel("EndingScene");
		}*/
	}
	
	private IEnumerator LoseWait2Seconds()
	{
		if(PersistentData.current.SubtractLife() > 0)
		{
			yield return new WaitForSeconds(1.3f);
			Application.LoadLevel("RunningScene");
		}
		else
		{
			PersistentData.current.ResetLevel();
			Application.LoadLevel("GameOver");
		}
	}

	private IEnumerator Wait15SecondsToLose()
	{
		StartTimer();
		yield return new WaitForSeconds(timeLimit);
		if(!answered)
		{
			if(PersistentData.current.SubtractLife() > 0)
			{
				Application.LoadLevel("RunningScene");
			}
			else
			{
				PersistentData.current.ResetLevel();
				Application.LoadLevel("GameOver");
			}
		}
	}

	private void StartTimer()
	{
		currentTime = timeLimit;
	}

	private void UpdateTimebar()
	{
		currentTime -= Time.deltaTime;

		//resize timebar here!!
		Vector3 timebarNewSize = new Vector3(timebarOriginalSize.x, timebarOriginalSize.y * (currentTime / timeLimit), timebarOriginalSize.z);
		timebar.localScale = timebarNewSize;
	}
}

