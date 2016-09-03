using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

	[Header("References")]
	[SerializeField]
	private ButtonTriggerProxy _triggerProxy;
	[SerializeField]
	private Interactable _buttonTarget;

	public bool IsOn
	{
		get { return isOn; }
	}

	private bool isOn = false;

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TurnOn () {
		isOn = true;
		_buttonTarget.Interact ();
	}

	public void TurnOff () {
		isOn = false;
		_buttonTarget.Interact ();
	}
}
