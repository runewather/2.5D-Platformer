using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Jump : MonoBehaviour {
	private PlayerController pc;
	[SerializeField]
	private Transform groundCollisor;
	[SerializeField]
	private float jumpForce;
	public float JumpForce { get {return jumpForce;} }

	void Start()
	{
		pc = GetComponent<PlayerController>();
	}

	public void JumpAction()
	{
		/*
		if()
		{
			pc.Rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}
		 */		
	}

}
