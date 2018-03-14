using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour {
	private PlayerController pc;
	[SerializeField]
	private Transform groundCollisor;
	[SerializeField]
	private LayerMask groundLayer;
	[SerializeField]
	private float jumpForce;
	private bool invertForce = false;
	public float JumpForce { get {return jumpForce;} }
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	public void InvertForce()
	{
		invertForce = !invertForce;
	}
	public void JumpAction()
	{
		if(groundCollisor)
		{
			if(Physics.CheckSphere(groundCollisor.position, 0.3f, groundLayer))
			{				
				if(!invertForce)
				{
					rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
				}
				else
				{
					rb.AddForce(Vector3.up * -jumpForce, ForceMode.Impulse);
				}
			}
		}	
	}

	void OnDrawGizmosSelected()
	{
		if(groundCollisor)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(groundCollisor.position, 0.3f);
		}
	}

}
