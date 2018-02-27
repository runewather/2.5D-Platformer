using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class HorizontalMovement : MonoBehaviour {

	private PlayerController pc;
	[SerializeField]
	private float speed;
	public float Speed { get { return speed; } }

	void Start()
	{
		pc = GetComponent<PlayerController>();
	}

	public void MoveRight()
	{
		pc.Rb.MovePosition(pc.Rb.position + (Vector3.right * speed * Time.deltaTime));
	}
	public  void MoveLeft()
	{
		pc.Rb.MovePosition(pc.Rb.position + (Vector3.right * -speed * Time.deltaTime));
	}
}
