using UnityEngine;
using System.Collections;

public class ButtonTriggerProxy : MonoBehaviour {

	[Header("References")]
	[SerializeField]
	private ButtonController _buttonController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		_buttonController.TurnOn ();
	}

	void OnTriggerExit(Collider other) {
		_buttonController.TurnOff ();
	}
}
