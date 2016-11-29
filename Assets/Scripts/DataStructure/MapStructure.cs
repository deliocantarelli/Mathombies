using UnityEngine;
using System.Collections;

public class MapStructure
{
	public Level level;
	public Operation operation;
	public int numberParenthesis;
	public Texture secondBackground;

	public MapStructure(Level level, Operation operation, int numberParenthesis)
	{
		this.level = level;
		this.operation = operation;
		this.numberParenthesis = numberParenthesis;
	}
}

