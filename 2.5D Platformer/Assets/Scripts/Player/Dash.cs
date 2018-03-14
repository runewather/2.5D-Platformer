using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(Rigidbody))]
public class Dash : MonoBehaviour {
	public bool IsDashing { get { return isDashing;} }
	[SerializeField]
	private float dashCooldown;
	[SerializeField]
	private float dashDistance;
	[SerializeField]
	private float dashTime = 0.0f;
	private bool canDash = true;
	private float dashAcceleration = 0.0f;
	private float dashTimer = 0.0f;
	private Rigidbody rb;
	private Vector3 dashInitialPosition;
	private bool isDashing = false;
	private string dashSide;

	void FixedUpdate() 
	{
		if(isDashing)
		{
			Vector3 move = Vector3.zero;			
			if(dashSide.Equals("Right"))
			{
				move = Vector3.right * ((dashAcceleration * (dashTimer * dashTimer)) / 2);
			}
			else if(dashSide.Equals("Left"))
			{				
				move = Vector3.left * ((dashAcceleration * (dashTimer * dashTimer)) / 2);
			}	
			rb.MovePosition(dashInitialPosition + move);
		}
	}

	void Update()
	{
		if(isDashing)
		{
			dashTimer += Time.deltaTime;
		}
		if(dashTimer >= dashTime)
		{
			dashSide = null;
			isDashing = false;
			dashTimer = Mathf.Clamp(dashTimer, 0.0f, dashTime);
			dashTimer = 0.0f;			
		}
	}

	void Start()
	{		
		rb = GetComponent<Rigidbody>();
	}

	IEnumerator DashCooldown()
	{
		canDash = false;
		yield return new WaitForSeconds(dashCooldown);
		canDash = true;
	}

	public void DashAction(string side)
	{
		if(canDash)
		{
			dashSide = side;
			dashAcceleration = (2 * dashDistance)/(dashTime * dashTime);
			isDashing = true;	
			dashInitialPosition = rb.position;
			StartCoroutine(DashCooldown());
		}		
	}

}
