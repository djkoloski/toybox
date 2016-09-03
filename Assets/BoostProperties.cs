using UnityEngine;
using System.Collections;

public class BoostProperties : MonoBehaviour {

	Rigidbody2D boostRigid;

	public Vector2 boostDirection;
	public float boostForce;

	// Use this for initialization
	void Start () {
		boostRigid = GetComponent<Rigidbody2D> ();
		boostDirection = boostRigid.GetRelativeVector (Vector2.up);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
