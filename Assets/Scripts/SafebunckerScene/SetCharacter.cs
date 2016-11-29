using UnityEngine;
using System.Collections;

public class SetCharacter : MonoBehaviour
{
	void Start ()
	{
		renderer.material.mainTexture = PersistentData.current.charactersSafebuncker[PersistentData.current.place[0] - 1]; //has already changed
	}
}

