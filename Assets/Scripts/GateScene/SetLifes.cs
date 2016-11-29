using UnityEngine;
using System.Collections;

public class SetLifes : MonoBehaviour
{
	void Start ()
	{
		this.renderer.material.mainTexture = PersistentData.current.heart[PersistentData.current.lifes - 1];
	}
}

