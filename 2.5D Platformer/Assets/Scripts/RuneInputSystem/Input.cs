using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RuneInputSystem 
{
	public class Input : MonoBehaviour 
	{
		private static Input instance = null;
		public static Input Instance { get{ return instance; } }
		//private Axis axis;

		[SerializeField]
		private Key[] keys;

		void Awake()
		{
			if(instance == null)
			{
				instance = this;
			}
			else if(instance != this)
			{
				Destroy(gameObject);
			}
			DontDestroyOnLoad(gameObject);
		}

		public bool GetKey(string key)
		{
			foreach(Key k in keys)
			{
				if(k.name == key)
				{
					return UnityEngine.Input.GetKey(k.key) || UnityEngine.Input.GetKey(k.altKey);
				}
			}
			return false;
		}

		public bool GetKeyDown(string key)
		{
			foreach(Key k in keys)
			{
				if(k.name == key)
				{
					return UnityEngine.Input.GetKeyDown(k.key) || UnityEngine.Input.GetKeyDown(k.altKey);
				}
			}
			return false;
		} 

		public bool GetKeyUp(string key)
		{
			foreach(Key k in keys)
			{
				if(k.name == key)
				{
					return UnityEngine.Input.GetKeyUp(k.key) || UnityEngine.Input.GetKeyUp(k.altKey);
				}
			}
			return false;
		}
	}
}
