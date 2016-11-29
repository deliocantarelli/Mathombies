using UnityEngine;
using System.Collections;

public class CharacterBehavior : MonoBehaviour {

	Animator animator;

	void Start()
	{
		animator = this.GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		if(!PersistentData.current.IsGamePaused())
		{
			if(Input.GetKey("right"))
			{
				animator.SetBool("running", true);
				transform.position += Vector3.right * 0.17f;
			}
			else
			{
				animator.SetBool("running", false);
			}
		}
	}
}
