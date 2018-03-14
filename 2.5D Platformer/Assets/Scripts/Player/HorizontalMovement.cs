using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HorizontalMovement : MonoBehaviour {
	[SerializeField]
	private float speed;
	private Rigidbody rb;

	private void Start() 
	{
		rb = GetComponent<Rigidbody>();
	}

	public void HorizontalMovementAction(string side)
	{
		Vector3 velocity = Vector3.zero;
		if(side.Equals("Right"))
		{
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90.0f, transform.eulerAngles.z);	
			velocity = Vector3.right * speed * Time.deltaTime;
		}	
		else if(side.Equals("Left"))
		{
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, -90.0f, transform.eulerAngles.z);	
			velocity = Vector3.left * speed * Time.deltaTime;
		}	
		rb.MovePosition(rb.position + velocity);
	}
}
