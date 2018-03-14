using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityInversion : MonoBehaviour {	
	[SerializeField]
	private Transform pivot;
	private bool isGravityInversed = false;
	public bool IsGravityInversed { get{ return isGravityInversed; } }
	public void InvertGravity()
	{
		isGravityInversed = !isGravityInversed;
		pivot.eulerAngles = new Vector3(pivot.eulerAngles.x, pivot.eulerAngles.y, (pivot.eulerAngles.z + 180) % 360);
		Physics.gravity *= -1;
	}
}
