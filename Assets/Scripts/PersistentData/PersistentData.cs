using UnityEngine;
using System.Collections;

public class PersistentData : MonoBehaviour
{
	public static PersistentData current;
	
	public ArrayList levels;				//levelStructure

	public int lifes;
	public int[] place;				//place 0 is the character the 1 is the current level

	public Texture[] backgrounds;
	public Texture[] foregrounds;
	public GameObject[] characters;
	public Texture[] heart;
	public Texture[] safebunckerDialogs;
	public Texture[] charactersSafebuncker;
	public Texture[] dialogHistory;
	public Texture[] startDialog;

	private bool gamePaused;
	private bool dialogsShowed;





	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}







	private void SetLevels()
	{
		place = new int[2] {0,0};
		levels = new ArrayList();
		gamePaused = false;
		dialogsShowed = false;

		ArrayList creatingMaps = new ArrayList();
		creatingMaps.Add(new MapStructure(Level.veryEasy, Operation.addition,0));
		creatingMaps.Add(new MapStructure(Level.easy, Operation.addition,0));
		creatingMaps.Add(new MapStructure(Level.easy, Operation.addition,1));

		
		ArrayList creatingMaps2 = new ArrayList();
		creatingMaps2.Add(new MapStructure(Level.easy,Operation.subtraction,0));
		creatingMaps2.Add(new MapStructure(Level.medium,Operation.subtraction,0));
		creatingMaps2.Add(new MapStructure(Level.easy,Operation.subtraction,1));
		creatingMaps2.Add(new MapStructure(Level.medium,Operation.subtraction,1));
		
		ArrayList creatingMaps3 = new ArrayList();
		creatingMaps3.Add(new MapStructure(Level.lessThanMedium,Operation.multiplication,0));
		creatingMaps3.Add(new MapStructure(Level.lessThanMedium,Operation.multiplication,1));
		creatingMaps3.Add(new MapStructure(Level.medium,Operation.multiplication,1));
		creatingMaps3.Add(new MapStructure(Level.medium,Operation.multiplication,2));
		
		ArrayList creatingMaps4 = new ArrayList();
		creatingMaps4.Add(new MapStructure(Level.medium,Operation.division,1));
		creatingMaps4.Add(new MapStructure(Level.hard,Operation.multiplication,1));
		creatingMaps4.Add(new MapStructure(Level.hard,Operation.division,2));
		creatingMaps4.Add(new MapStructure(Level.veryHard,Operation.division,2));


		levels.Add(
			new LevelStructure(
				creatingMaps,
				characters[0],
				backgrounds[0]
			)
		);
		levels.Add(
			new LevelStructure(
				creatingMaps2,
				characters[1],
				backgrounds[1]
			)
		);
		
		levels.Add(
			new LevelStructure(
				creatingMaps3,
				characters[2],
				backgrounds[2]
			)
		);
		levels.Add(
			new LevelStructure(
				creatingMaps4,
				characters[3],
				backgrounds[3]
			)
		);
	}

	public Texture GetCurrentBackground()
	{
		return ((LevelStructure)levels[place[0]]).background;
	}
	public GameObject GetCurrentCharacter()
	{
		return ((LevelStructure)levels[place[0]]).character;
	}
	public Level GetEquationLevel()
	{
		return ((MapStructure)((LevelStructure)levels[place[0]]).maps[place[1]]).level;
	}
	public int GetEquationNumberParenthesis()
	{
		return ((MapStructure)((LevelStructure)levels[place[0]]).maps[place[1]]).numberParenthesis;
	}
	public Operation GetEquationOperation()
	{
		return ((MapStructure)((LevelStructure)levels[place[0]]).maps[place[1]]).operation;
	}

	public int nextMap()
	{
		place[1] ++;					//pass to next stage
		if(((LevelStructure)levels[place[0]]).maps.Count == place[1])			//if the level is over
		{
			place[0] ++;
			place[1] = 0;
		}
		if(levels.Count == place[0])
		{
			//Debug.Log("you have finished the game");
			//ResetLevel();
			return 0;
		}
		return 1;
	}

	public int SubtractLife()
	{
		lifes --;
		return lifes;
	}

	void Awake ()
	{
		if(current != null)
		{
			Destroy(gameObject);
		}
		else
		{
			SetLevels();
			DontDestroyOnLoad(gameObject);
			current = this;
		}
	}

	public void ResetLevel()
	{
		ResetDialog();
		place[0] = 0;
		place[1] = 0;
		lifes = 3;
	}

	public bool IsGamePaused()
	{
		return gamePaused;
	}

	public void UnpauseGame()
	{
		gamePaused = false;
	}
	public void PauseGame()
	{
		gamePaused = true;
	}
	public bool WasDialogShowed()
	{
		return dialogsShowed;
	}
	public void DialogShowed()
	{
		dialogsShowed = true;
	}
	public void ResetDialog()
	{
		dialogsShowed = false;
	}
}

