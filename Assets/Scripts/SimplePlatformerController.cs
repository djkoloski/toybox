using UnityEngine;
using System.Collections.Generic;

public class SimplePlatformerController : MonoBehaviour
{
	// User-facing variables
	[SerializeField]
	private float _jumpForce;
	[SerializeField]
	private float _jumpCooldown;

	// Private variables
	private Rigidbody2D _rigidbody2d;
	private DirectionalMovementController _movementController;

	private bool _isGrounded;
	private float _jumpTimer;

	// Initialization
	public void Awake()
	{
		_rigidbody2d = GetComponent<Rigidbody2D>();
		_movementController = GetComponent<DirectionalMovementController>();

		_isGrounded = false;
		_jumpTimer = 0.0f;
	}

	// Update
	public void Update()
	{
		_movementController.Move1D(Input.GetAxis("Horizontal"));

		UpdateGrounded();

		if (_jumpTimer <= 0.0f)
		{
			const float k_jumpTolerance = 0.05f;

			if (_isGrounded && Input.GetAxis("Vertical") > k_jumpTolerance)
			{
				_rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, 0.0f);
				_rigidbody2d.AddForce(_jumpForce * Vector2.up);
				_jumpTimer = _jumpCooldown;
			}
		}
		else
			_jumpTimer = Mathf.Max(0.0f, _jumpTimer - Time.deltaTime);
	}

	// Private interface
	private void UpdateGrounded()
	{
		const float k_groundedDistance = 0.1f;
		if (Physics2D.Raycast(transform.position, Vector2.down, k_groundedDistance, LayerMasks.World))
			_isGrounded = true;
		else
			_isGrounded = false;
	}
}