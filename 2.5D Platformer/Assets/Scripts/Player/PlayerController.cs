using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	private HorizontalMovement horizontalMovement;
	public Rigidbody Rb { get { return rb;} }
	public HorizontalMovement HorizontalMovement { get {return horizontalMovement;}}
	private Jump jump;
	public Jump Jump { get { return jump; } }
	
	void Start () {
		rb = GetComponent<Rigidbody>();
		horizontalMovement = GetComponent<HorizontalMovement>();
		jump = GetComponent<Jump>();
	}
}
