using UnityEngine;
using System.Collections;

public class LevelStructure
{
	public ArrayList maps;

	public GameObject character;
	public Texture background;

	public LevelStructure(ArrayList maps, GameObject character, Texture background)
	{
		this.maps = maps;
		this.character = character;
		this.background = background;
	}
}

