using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour {

	private PlayerController pc;
	
	void Start()
	{
		pc = GetComponent<PlayerController>();
	}

	void FixedUpdate () 
	{
		if(RuneInputSystem.Input.Instance.GetKey("Move Left"))
		{
			pc.HorizontalMovement.MoveLeft();
		}
		if(RuneInputSystem.Input.Instance.GetKey("Move Right"))
		{
			pc.HorizontalMovement.MoveRight();
		}
	}

	void Update()
	{
		if(RuneInputSystem.Input.Instance.GetKeyDown("Jump"))
		{
			pc.Jump.JumpAction();
		}
	}

}
