using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour {

	SpringJoint thisSpring;

	Vector3 initialPosition;
	public bool isOn = false;

	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		thisSpring = GetComponent<SpringJoint> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((initialPosition - transform.position).magnitude > 0.4)
			isOn = true;
		else
			isOn = false;
	}
}
