using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
	// Static variables
	public static PlayerController instance;

	// Public variables
	[Header("Movement")]
	[SerializeField]
	private float _speed;
	[SerializeField]
	private float _turnSpeed;
	[SerializeField]
	private float _gravity;
	[SerializeField]
	private float _jumpVelocity;

	[Header("References")]
	[SerializeField]
	private CameraController _cameraController;

	// System variables
	public float CurrentPitch
	{
		get { return _cameraController.CurrentPitch; }
	}
	public bool IsLookingAtInteractable
	{
		get { return _isLookingAtInteractable; }
	}

	// Private variables
	private CharacterController _characterController;
	private float _verticalVelocity;
	private bool _isLookingAtInteractable;

	// Initialization
	public void Awake()
	{
		instance = this;
		_characterController = GetComponent<CharacterController>();
		_verticalVelocity = 0.0f;
		_isLookingAtInteractable = false;
	}

	// Update
	public void Update()
	{
		Vector2 movementInput = InputManager.GetFirstPersonMovement();
		Vector2 cameraInput = InputManager.GetCameraMovement();

		// Turn by horizontal
		float turnAmount = cameraInput.x * _turnSpeed * Time.deltaTime;
		transform.Rotate(Vector3.up, turnAmount);

		// Pitch by vertical
		_cameraController.Pitch(-cameraInput.y);

		// Move relative to orientation
		Vector3 movement = (transform.right * movementInput.x + transform.forward * movementInput.y) * _speed;
		if (_characterController.isGrounded)
		{
			_verticalVelocity = 0.0f;
			if (Input.GetButton("Jump"))
			{
				_verticalVelocity = _jumpVelocity;
			}
		}
		_verticalVelocity += _gravity * Time.deltaTime;
		movement.y = _verticalVelocity;
		_characterController.Move(movement * Time.deltaTime);

		// Update interactables
		Interactable interactable = LookForInteractable();
		_isLookingAtInteractable = (interactable != null);
		if (_isLookingAtInteractable && InputManager.GetInteract())
			interactable.Interact();
	}

	// Public interface
	public bool CanSee(Vector3 point)
	{
		return _cameraController.CanSee(point);
	}

	// Private interface
	private Interactable LookForInteractable()
	{
		RaycastHit hit;
		if (Physics.Raycast(_cameraController.transform.position, _cameraController.transform.forward, out hit, 100.0f, ~LayerMasks.IgnoreRaycast))
		{
			Interactable interactable = hit.collider.GetComponent<Interactable>();
			if (interactable == null)
				return null;

			Vector3 toInteractable = _cameraController.transform.position - interactable.transform.position;
			float distanceToInteractable = Vector3.ProjectOnPlane(toInteractable, Vector3.up).magnitude;
			if (distanceToInteractable < interactable.interactableDistance)
				return interactable;
		}

		return null;
	}
}