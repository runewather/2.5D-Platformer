using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour {
	public UnityAction OnDie;
	[SerializeField]
	private int health;
	private bool isInvunerable = false;
	public bool IsInvunerable { get { return isInvunerable; } }

	public int HealthPoints { get{ return health; } }

	public void SetInvunerable(bool b)
	{
		isInvunerable = b;
	}

	public void TakeDamage(int dmg)
	{
		if(!isInvunerable)
		{
			health -= dmg;
		}
		if(health <= 0)
		{
			OnDie();
		}
	}

}
