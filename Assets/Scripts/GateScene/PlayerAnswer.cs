using UnityEngine;
using System.Collections;

public class PlayerAnswer : MonoBehaviour {
	private int forParse;
	private string playerAnswer;

	// Use this for initialization
	void Start () {
		playerAnswer = "0";
		RefreshAnswerText();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown)
		{
			foreach(char key in Input.inputString)
			{
				if(char.IsNumber(key))
				{
					AddToAnswer((int)char.GetNumericValue(key));
				}
				else if(key == '\b')
				{
					RemoveFromAnswer();
				}
			}
		}
	}

	private void AddToAnswer(int keyPressed)
	{
		if(playerAnswer.Length < 3)
		{
			if(playerAnswer.CompareTo("0") == 0)
			{
				playerAnswer = "";
			}
			playerAnswer += keyPressed;
			RefreshAnswerText();
		}
	}
	private void RemoveFromAnswer()
	{
		if(playerAnswer.Length > 0)
		{
			playerAnswer = playerAnswer.Remove(playerAnswer.Length - 1);
			if(playerAnswer.Length == 0)
			{
				playerAnswer = "0";
			}
			RefreshAnswerText();
		}
	}
	private void RefreshAnswerText()
	{
		(this.GetComponent(typeof(TextMesh)) as TextMesh).text = playerAnswer;
	}
	public int GetAnswer()
	{
		return int.Parse(playerAnswer);
	}
}

