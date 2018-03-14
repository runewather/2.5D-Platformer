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
			pc.HorizontalMove("Left");
		}
		if(RuneInputSystem.Input.Instance.GetKey("Move Right"))
		{
			pc.HorizontalMove("Right");
		}
	}

	void Update()
	{
		if(RuneInputSystem.Input.Instance.GetKeyDown("Jump"))
		{
			pc.Jump();
		}
		if(RuneInputSystem.Input.Instance.GetKeyDown("Dash"))
		{
			pc.Dash();
		}
		if(RuneInputSystem.Input.Instance.GetKeyDown("Gravity"))
		{
			pc.InvertGravity();
		}
	}

}
