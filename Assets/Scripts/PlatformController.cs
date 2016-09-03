using UnityEngine;
using System.Collections.Generic;

public class PlatformController : MonoBehaviour
{
	// User-facing variables
	[SerializeField]
	private Vector3 _endOffset;
	[SerializeField]
	private bool _startActive;
	[SerializeField]
	private float _movementTime;

	// Private variables
	private Vector3 _startPosition;
	private bool _active;
	private float _movementDirection;
	private float _distance;

	// Initialization
	public void Awake()
	{
		_startPosition = transform.position;
		_active = _startActive;
		_movementDirection = 1.0f;
		_distance = 0.0f;
	}

	// Update
	public void Update()
	{
		if (_active)
		{
			_distance += _movementDirection * Time.deltaTime;

			if ((_distance >= _movementTime && _movementDirection > 0.0f) || (_distance <= 0.0f && _movementDirection < 0.0f))
			{
				_distance = Mathf.Clamp(_distance, 0.0f, _movementTime);
				_movementDirection = -_movementDirection;
			}
		}

		float t = Ease(_distance, 0.0f, 1.0f, _movementTime);
		transform.position = Vector3.Lerp(_startPosition, _startPosition + _endOffset, t);
	}

	// Private interface
	private float Ease(float t, float b, float c, float d)
	{
		// Cubic ease in/out
		t /= d / 2.0f;
		if (t < 1.0f)
			return c / 2.0f * t * t * t + b;
		t -= 2.0f;
		return c / 2.0f * (t * t * t + 2) + b;
	}

	// Gizmos
	public void OnDrawGizmos()
	{
		Color backupColor = Gizmos.color;

		Gizmos.color = Color.white;
		Vector3[] corners = new Vector3[]
		{
			new Vector3(-3.0f, 0.0f, -3.0f),
			new Vector3(3.0f, 0.0f, -3.0f),
			new Vector3(-3.0f, 0.0f, 3.0f),
			new Vector3(3.0f, 0.0f, 3.0f)
		};
		foreach (Vector3 corner in corners)
			Gizmos.DrawLine(transform.position + corner, transform.position + _endOffset + corner);

		Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position, 0.2f);
		Gizmos.DrawWireCube(transform.position, new Vector3(6.0f, 0.125f, 6.0f));

		Gizmos.color = Color.green;
		Gizmos.DrawSphere(transform.position + _endOffset, 0.2f);
		Gizmos.DrawWireCube(transform.position + _endOffset, new Vector3(6.0f, 0.125f, 6.0f));

		Gizmos.color = backupColor;
	}
}