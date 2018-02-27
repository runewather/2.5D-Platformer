using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RuneInputSystem
{
	public class CommandRow : MonoBehaviour 
	{
		[SerializeField]
		private Text commandLabel = null;
		public Text CommandLabel { get { return commandLabel;}}
		[SerializeField]
		private Button button = null;
		public Button Button {get { return button;}}
		[SerializeField]
		private Text buttonText = null;
		public Text ButtonText { get {return buttonText;}}
		[SerializeField]
		private Button altButton = null;
		public Button AltButton {get { return altButton;} }	
		[SerializeField]
		private Text altButtonText = null;
		public Text AltButtonText { get{ return altButtonText;}}
		private Key key;
		
		public void SelectedButton(bool isAlt)
		{
			if(!isAlt)
			{
				button.image.color = Color.blue;
			}
			else
			{
				altButton.image.color = Color.blue;
			}
		}

		public void DeselectButton(bool isAlt)
		{
			if(!isAlt)
			{
				button.image.color = Color.white;
			}
			else
			{
				altButton.image.color = Color.white;
			}
		}

		public void OnClickBtn()
		{
			Input.Instance.SelectKey(key, this, false);
		}

		public void OnClickAltBtn()
		{
			Input.Instance.SelectKey(key, this, true);
		}

		public void BindKeyToButton(Key k)
		{
			commandLabel.text = k.name;
			buttonText.text = k.key.ToString();
			altButtonText.text = k.altKey.ToString();	
			key = k;
			button.onClick.AddListener(OnClickBtn);
			altButton.onClick.AddListener(OnClickAltBtn);				
		}
	}
}
