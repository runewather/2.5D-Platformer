using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentinelScript : MonoBehaviour {
	[SerializeField]
	private LayerMask mask;
	private Rigidbody rb;
	private Vector3 fwd;
	private bool isRight = true;
	private HorizontalMovement hm;

	void Start () 
	{
		fwd = transform.TransformDirection(Vector3.forward);
		hm = GetComponent<HorizontalMovement>();
	}
	
	void FixedUpdate () 
	{
		RaycastHit hit;
		if(Physics.Raycast(transform.position, fwd, out hit , 1.0f, mask))
		{
			print(hit.collider.tag);
			if(hit.collider.tag == "Player")
			{
				print("PLAYER TOOK DAMAGE!");
			}
			if(hit.collider.tag == "Obstacle")
			{
				transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y * -1, transform.eulerAngles.z);
				fwd = transform.TransformDirection(Vector3.forward);
				isRight = !isRight;
			}
		}
		
		if(isRight)
		{
			hm.HorizontalMovementAction("Right");
		}
		else
		{
			hm.HorizontalMovementAction("Left");
		}		
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.collider.tag == "Player")
		{
			print("Colidiu!");
			other.collider.GetComponent<Health>().TakeDamage(1);
		}
	}

	private void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(transform.position, transform.position + fwd * 2);
	}

}
