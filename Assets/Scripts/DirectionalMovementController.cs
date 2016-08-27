using UnityEngine;
using System.Collections.Generic;

public class DirectionalMovementController : MonoBehaviour
{
	// Types
	private enum MovementType
	{
		OneDimensional,
		TwoDimensional
	}

	// User-facing variables
	[SerializeField]
	private float _acceleration;
	[SerializeField]
	private float _maxAcceleration;
	[SerializeField]
	private float _maxVelocity;

	// Private variables
	private Rigidbody2D _rigidbody2d;
	private MovementType _movementType;
	private Vector2 _movementInput;

	// Initialization
	public void Awake()
	{
		_rigidbody2d = GetComponent<Rigidbody2D>();
		_movementType = MovementType.OneDimensional;
		_movementInput = Vector2.zero;
	}

	// Public interface
	public void Move1D(float direction)
	{
		_movementType = MovementType.OneDimensional;
		_movementInput.x = direction;
	}
	public void Move2D(Vector2 direction)
	{
		_movementType = MovementType.TwoDimensional;
		_movementInput = direction;
	}

	// Update
	public void Update()
	{
		switch (_movementType)
		{
			case MovementType.OneDimensional:
				MoveUtil.AccelerateClamped1D(_rigidbody2d, _movementInput.x * _maxVelocity, _acceleration, _maxAcceleration);
				MoveUtil.ClampVelocity1D(_rigidbody2d, _maxVelocity);
				break;
			case MovementType.TwoDimensional:
				MoveUtil.AccelerateClamped2D(_rigidbody2d, _movementInput * _maxVelocity, _acceleration, _maxAcceleration);
				MoveUtil.ClampVelocity2D(_rigidbody2d, _maxVelocity);
				break;
			default:
				throw new System.InvalidOperationException();
		}
	}
}