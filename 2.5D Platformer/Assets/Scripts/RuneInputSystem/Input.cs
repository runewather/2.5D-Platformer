using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RuneInputSystem 
{
	public class Input : MonoBehaviour 
	{
		private static Input instance = null;
		public static Input Instance { get{ return instance; } }

		[Header("Key Binding GUI")]
		[SerializeField]
		private bool InitKeyBindingGUI = false;
		[SerializeField]
		private CommandRow[] CommandRows;
		private Key selectedKey = null;
		private CommandRow selectedCommand;
		private bool isAlt = false;

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

		private void KeyBindingGUI()
		{
			int count = 0;
			foreach(CommandRow c in CommandRows)
			{
				c.BindKeyToButton(keys[count]);
				count++;
			}
		}

		private void Start() 
		{
			if(InitKeyBindingGUI)
			{
				KeyBindingGUI();
			}
		}

		public float GetJoystickHorizontalAxis()
		{
			return UnityEngine.Input.GetAxisRaw("Horizontal");
		}

		public float GetJoystickVerticalAxis()
		{
			return UnityEngine.Input.GetAxisRaw("Vertical");
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

		void OnGUI()
		{
			if(selectedKey != null)
			{
				Event e = Event.current;
				if(e.isKey)
				{					
					if(!isAlt)
					{
						selectedKey.key = e.keyCode;
					}
					else
					{
						selectedKey.altKey = e.keyCode;
					}
					selectedCommand.BindKeyToButton(selectedKey);
					selectedCommand.DeselectButton(isAlt);
					selectedCommand = null;
					selectedKey = null;					
				}				
			}
		}

		public void SelectKey(Key k, CommandRow c , bool isAlt)
		{
			if(selectedCommand != null)
			{
				selectedCommand.DeselectButton(this.isAlt);
			}
			selectedKey = null;
			selectedCommand = null;
			
			selectedKey = k;
			selectedCommand = c;
			this.isAlt = isAlt;
			c.SelectedButton(isAlt);
		}
	}
}
