using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	//References to components
	Rigidbody2D CarRigidbody;

	//Lap

	// Use this for initialization
	void Start () {
		//Set the reference to the rigid body physics component.
		CarRigidbody = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		Vector2 wheelDirection = new Vector2 (Mathf.Cos ((Mathf.PI / 4) * -Input.GetAxis ("Horizontal") + (Mathf.PI / 2)),
			                         Mathf.Sin ((Mathf.PI / 4) * -Input.GetAxis ("Horizontal") + (Mathf.PI / 2)));
		Vector2 wheelPerpDirection = new Vector2 (wheelDirection.y, -wheelDirection.x);
		if (Input.GetAxis ("Vertical") > 0.2f) {
			
			CarRigidbody.AddRelativeForce (wheelDirection * 1000.0f * Time.fixedDeltaTime);
		}
		/*
		//Turning left
		if (Input.GetAxis ("Horizontal") > 0.1f)
			CarRigidbody.AddTorque (Mathf.Clamp(-100.0f * CarRigidbody.velocity.magnitude * Time.fixedDeltaTime,-20.0f,0.0f));
		//Turning right
		else if (Input.GetAxis ("Horizontal") < -0.1f)
			CarRigidbody.AddTorque (Mathf.Clamp(100.0f * CarRigidbody.velocity.magnitude * Time.fixedDeltaTime,0.0f,20.0f));
		*/
		if (!Input.GetButton ("Fire3")) {
			Vector2 opposingForce = Vector2.Dot (CarRigidbody.velocity, wheelPerpDirection) / Vector2.Dot (wheelPerpDirection, wheelPerpDirection) * wheelPerpDirection;
			opposingForce = opposingForce * (float)(0.5 * CarRigidbody.mass / Time.fixedDeltaTime);
			CarRigidbody.AddRelativeForce (opposingForce);
		}

		/*
		//Check if breaking first
		if (Input.GetButton ("Fire")) {

		}
			//CarRigidbody.velocity = Vector2.Scale(CarRigidbody.velocity, new Vector2(1.0f - 0.75f * Time.fixedDeltaTime,1.0f - 0.75f * Time.fixedDeltaTime));
		//Check if driving forward
		else {	
			if (Input.GetAxis ("Vertical") > 0.1f)
				CarRigidbody.AddForce (700.0f * Time.fixedDeltaTime * CarRigidbody.GetRelativeVector(Vector2.up));
			
		}
		//Turning left
		if (Input.GetAxis ("Horizontal") > 0.1f)
			CarRigidbody.AddTorque (Mathf.Clamp(-100.0f * CarRigidbody.velocity.magnitude * Time.fixedDeltaTime,-15.0f,0.0f));
		//Turning right
		else if (Input.GetAxis ("Horizontal") < -0.1f)
			CarRigidbody.AddTorque (Mathf.Clamp(100.0f * CarRigidbody.velocity.magnitude * Time.fixedDeltaTime,0.0f,15.0f));
		*/
		//Center the camera on the car.
		Camera.main.transform.position = transform.position - new Vector3(0,0,10.0f);
	}

	void OnTriggerEnter2D(Collider2D other) {
		BoostProperties otherBoost = other.GetComponent<BoostProperties> ();
		float boostForce = Vector2.Dot (CarRigidbody.GetRelativeVector (Vector2.up), otherBoost.boostDirection)
		                   * otherBoost.boostForce;
		if (boostForce > 0.01f)
			CarRigidbody.AddForce (Mathf.Clamp(boostForce,0,otherBoost.boostForce)
								   * CarRigidbody.GetRelativeVector(Vector2.up));
	}
}