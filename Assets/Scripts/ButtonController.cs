using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

	//References to other objects
	[Header("References")]
	[SerializeField]
	private ButtonTriggerProxy _triggerProxy;

	//References to components
	private Animator _animator;
	private Interactable _interactable;

	//Public variables
	public bool IsOn
	{
		get { return isOn; }
	}

	//Private variables
	private bool isOn = false;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator> ();
		_interactable = GetComponent<Interactable> ();
	}

	// Update is called once per frame
	void Update () {

	}

	//Called when the button turns on
	public void TurnOn () {
		isOn = true;
		_interactable.Interact ();
		_animator.SetBool ("Pressed",true);

	}

	//Called when the button turns off
	public void TurnOff () {
		isOn = false;
		_interactable.Interact ();
		_animator.SetBool ("Pressed",false);
	}
}
