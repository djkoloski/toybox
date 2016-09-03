using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour {

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

	//Called when the switch turns on
	public void TurnOn () {
		isOn = true;
		_animator.SetBool ("Switched", true);

	}

	//Called when the switch turns off
	public void TurnOff () {
		isOn = false;
		_animator.SetBool ("Switched",false);
	}
}