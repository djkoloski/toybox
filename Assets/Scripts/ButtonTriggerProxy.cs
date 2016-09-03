using UnityEngine;
using System.Collections;

//This component exists because there can only be one
//collider on a GameObject at one time, and so to use
//a trigger, it must be in a child object.

public class ButtonTriggerProxy : MonoBehaviour {

	//References to other objects
	[Header("References")]
	[SerializeField]
	private ButtonController _buttonController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//When the trigger is activated...
	void OnTriggerEnter(Collider other) {
		_buttonController.TurnOn ();
	}

	//When things leave the trigger...
	void OnTriggerExit(Collider other) {
		_buttonController.TurnOff ();
	}
}
