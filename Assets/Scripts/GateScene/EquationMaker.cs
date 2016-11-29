using UnityEngine;
using System.Collections;

public struct Equation
{
	string Challenge;
	int answer;
}

public enum Level
{
	veryEasy = 2,
	easy = 4,
	lessThanMedium = 7,
	medium = 10,
	hard = 12,
	veryHard = 14,
	impossible = 18,
	giveUp = 24
}

public enum Probability
{
	never = 0,
	veryRarely = 1,
	rarely = 2,
	normal = 3
}

public enum Operation
{
	addition,
	subtraction,
	multiplication,
	division
}

public class EquationMaker : MonoBehaviour {

	Level difficult;
	Operation operations;
	Queue equation;
	string textEquation;
	public ArrayList probabilityVector = new ArrayList();
	ArrayList primeNumbers = new ArrayList();
	private int answer;

	void Start () {
		(this.GetComponent(typeof(TextMesh)) as TextMesh).text = GetEquation(PersistentData.current.GetEquationLevel(), PersistentData.current.GetEquationNumberParenthesis(), PersistentData.current.GetEquationOperation());
		//this.guiText.text = GetEquation(PersistentData.current.GetEquationLevel(), PersistentData.current.GetEquationNumberParenthesis(), PersistentData.current.GetEquationOperation());

		int[] primeNumber = {7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97};

		for (int i = 0; i < 22; i ++)
		{
			primeNumbers.Add(primeNumber[i]);
		}
	}


	string GetEquation(Level difficult, int numberOfParenthesis, Operation operations)
	{
		this.difficult = difficult;
		this.operations = operations;
		this.equation = new Queue();

		float depth = 0;		//depth is the first number of chances to make a parenthesis in this depth
		float range = 50;

		CreateProbabilityVector(numberOfParenthesis);

		int[] value = GetNumbers(operations);
		answer = value[2];

		getNextCharacter(depth, range, value[0]);

		addToEquation(getOperation(operations));
		
		getNextCharacter(depth + range, range, value[1]);

		return textEquation; 
	}

	void MakeEquation(Operation operation, float firstDepth, float range, int value)
	{
		Operation randomOperation = (Operation)Random.Range(0, (int)operation + 1);

		int[] values = GetNumbers(randomOperation, value);

		range = range / 2;				//just need this, so there is no need to make divisions every time

		getNextCharacter(firstDepth, range, values[0]);

		addToEquation(getOperation(randomOperation));

		getNextCharacter(firstDepth + range, range, values[1]);

	}


	void getNextCharacter (float depth, float range, int value)
	{
		float probability2 = 1;
		float probability = 0;

		if (probabilityVector.Count > 0)
		{
			probability = (int)probabilityVector[0];

			probability2 = probability - (depth + range);
		}
		if (probability2 < 0)
		{
			probabilityVector.RemoveAt(0);

			addToEquation("(");
			MakeEquation(operations, probability, range + depth - probability, value);
			addToEquation(")");
		}
		else
		{
			addToEquation("" + value);
		}
	}

	string getOperation(Operation operation)
	{
		if(operation == Operation.addition)
		{
			return "+";
		}
		else if(operation == Operation.subtraction)
		{
			return "-";
		}
		else if(operation == Operation.multiplication)
		{
			return "*";
		}
		else if(operation == Operation.division)
		{
			return "/";
		}
		return "";
	}

	private int[] GetNumbers(Operation operation)
	{
		int[] results = {0,0,0};
		if(Operation.addition == operation)
		{
			results[0] = Random.Range((int)difficult, (int) difficult * 3);
			results[1] = Random.Range((int)difficult, (int) difficult * 3);
			results[2] = results[0] + results[1];
		}
		else if(Operation.subtraction == operation)
		{
			results[0] = Random.Range((int)difficult, (int) difficult * 3);
			results[1] = Random.Range(1, results[0]);
			results[2] = results[0] - results[1];
		}
		else if(Operation.multiplication == operation)
		{
			bool goodNumber = true;
			while(goodNumber)
			{
				results[0] = Random.Range(1, (int) difficult);
				results[1] = Random.Range(1, (int) difficult);
				results[2] = results[0] * results[1];
				
				if(!primeNumbers.Contains(results[0]) && !primeNumbers.Contains(results[1]))
				{
					goodNumber = false;
				}
			}
		}
		else if(Operation.division == operation)
		{
			bool goodNumber = true;
			while(goodNumber)
			{
				results[1] = Random.Range(1, (int) difficult + 1);
				results[2] = Random.Range(1, (int) difficult + 1);
				results[0] = results[1] * results[2];	
				if(!primeNumbers.Contains(results[0]) && !primeNumbers.Contains(results[1]))
				{
					goodNumber = false;
				}
			}
				
		}
		return results;
	}


	private int[] GetNumbers(Operation operation, int value)
	{
		int[] results = {0,0,0};
		int order = Random.Range(0,1);
		results[2] = value;

		if(Operation.addition == operation)
		{
			int number = Random.Range(1, value);

			if(order == 0)
			{
				results[0] = number;
				results[1] = value - number;
			}
			else
			{
				results[1] = number;
				results[0] = value - number;
			}
		}
		else if(Operation.subtraction == operation)
		{
			int number = Random.Range((int)difficult, (int) difficult * 3);

			results[0] = value + number;
			results[1] = number;
		}
		else if(Operation.multiplication == operation)
		{

			int number = GetRandomFactor(value);

			if(order == 0)
			{
				results[0] = number;
				results[1] = value / number;
			}
			else
			{
				results[1] = number;
				results[0] = value / number;
			}
		}
		else if(Operation.division == operation)
		{
			//bool numberIsNotOk = true;
			int maxValue = (int) difficult + 1;
			//while(numberIsNotOk)		to see if shit is going to happen
			//{
			results[1] = Random.Range(1, maxValue);
			results[0] = results[1] * value;
			//}
		}
		return results;
	}


	private void CreateProbabilityVector(int numberOfParenthesis)
	{
		for (int i = 0; i < numberOfParenthesis; i ++)
		{
			probabilityVector.Add(Random.Range(0,100));
		}
		probabilityVector.Sort();
	}

	private void addToEquation(string character)
	{
		equation.Enqueue(character);
		textEquation += " " + character;
	}


	private int GetRandomFactor(int numberToBeFactored) {

		ArrayList listOfFactors = new ArrayList();

		for(int factor = 1; factor*factor <= numberToBeFactored; factor++)
		{
			if(numberToBeFactored % factor == 0) 
			{
				listOfFactors.Add(factor);
				if(factor != numberToBeFactored/factor) 
				{
					listOfFactors.Add(numberToBeFactored/factor);
				}
			}
		}
		return (int) listOfFactors[(Random.Range(0, listOfFactors.Count - 1))];
	}

	public int GetAnswer()
	{
		return answer;
	}
}
