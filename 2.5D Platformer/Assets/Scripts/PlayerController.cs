﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(RuneInputSystem.Input.Instance.GetKey("MoveLeft"))
		{
			rb.MovePosition(rb.position + Vector3.right * -3.0f * Time.deltaTime);
		}
		if(RuneInputSystem.Input.Instance.GetKey("MoveRight"))
		{
			rb.MovePosition(rb.position + Vector3.right * 3.0f * Time.deltaTime);
		}
	}
}