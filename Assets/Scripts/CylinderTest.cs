using UnityEngine;
using System.Collections;

public class CylinderTest : MonoBehaviour {

	private Rigidbody thisRigid;

	// Use this for initialization
	void Awake () {
		thisRigid = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Launch () {
		thisRigid.AddRelativeForce (0, 1000.0f, 0);
		Debug.Log ("Liftoff");
	}
}
