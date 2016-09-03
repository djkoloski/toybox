using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour {

	//References to other objects
	[Header("References")]
	[SerializeField]
	private Interactable _switchTarget;

	//Public variable
	public bool IsOn
	{
		get { return isOn; }
	}

	//Component references
	private Animator _animator;

	//Private variables
	private bool isOn = false;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

	}

	//Toggle the switch
	public void Toggle () {
		if (isOn)
			TurnOff ();
		else
			TurnOn ();
	}

	public void TurnOn () {
		isOn = true;
		_switchTarget.Interact ();
		_animator.SetBool ("Switched",true);
		Debug.Log (isOn);

	}

	public void TurnOff () {
		isOn = false;
		_switchTarget.Interact ();
		_animator.SetBool ("Switched",false);
		Debug.Log (isOn);
	}
}