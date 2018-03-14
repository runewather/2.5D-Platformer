using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {

	private HorizontalMovement hm;
	private Jump jump;
	private Dash dash;
	private GravityInversion gi;
	private Health health;
	private string lastSide = "Right";

	void Start()
	{
		hm = GetComponent<HorizontalMovement>();
		dash = GetComponent<Dash>();
		jump = GetComponent<Jump>();
		gi = GetComponent<GravityInversion>();
		health = GetComponent<Health>();
	}

	public void HorizontalMove(string side)
	{
		if(!dash.IsDashing)
		{
			lastSide = side;
			hm.HorizontalMovementAction(side);
		}
	}

	public void Dash()
	{
		dash.DashAction(lastSide);
		StartCoroutine(Invunerable());
	}

	public void Jump()
	{
		if(!dash.IsDashing)
		{
			jump.JumpAction();
		}
	}

	public void InvertGravity()
	{
		if(!dash.IsDashing)
		{			
			gi.InvertGravity();
			jump.InvertForce();
		}
	}
	
	IEnumerator Invunerable()
	{
		health.SetInvunerable(true);
		while(dash.IsDashing)
		{
			yield return null;
		}
		health.SetInvunerable(false);
	}

}
