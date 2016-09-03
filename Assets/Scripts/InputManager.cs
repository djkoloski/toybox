using UnityEngine;
using System.Collections.Generic;

public class InputManager : MonoBehaviour
{
	// Types
	public enum State
	{
		Free,
		FirstPerson,
		GUI
	}

	// Static variables
	private static InputManager _instance;

	// Private variables
	private State _state;
	private State _lastNonFreeState;

	// Initialization
	public void Awake()
	{
		_instance = this;

		TransitionState(State.FirstPerson);
	}

	// State transitions
	private void TransitionState(State newState)
	{
		_state = newState;
		switch (_state)
		{
			case State.Free:
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				break;
			case State.FirstPerson:
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				_lastNonFreeState = _state;
				break;
			case State.GUI:
				Cursor.lockState = CursorLockMode.Confined;
				Cursor.visible = true;
				_lastNonFreeState = _state;
				break;
			default:
				throw new System.NotImplementedException();
		}
	}

	// Public interface
	public static Vector2 GetFirstPersonMovement()
	{
		switch (_instance._state)
		{
			case State.Free:
				return Vector2.zero;
			case State.FirstPerson:
				return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
			case State.GUI:
				return Vector2.zero;
			default:
				throw new System.NotImplementedException();
		}
	}
	public static Vector2 GetCameraMovement()
	{
		switch (_instance._state)
		{
			case State.Free:
				return Vector2.zero;
			case State.FirstPerson:
				return new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
			case State.GUI:
				return Vector2.zero;
			default:
				throw new System.NotImplementedException();
		}
	}
	public static bool GetJump()
	{
		switch (_instance._state)
		{
			case State.Free:
			case State.GUI:
				return false;
			case State.FirstPerson:
				return Input.GetKeyDown(KeyCode.Space);
			default:
				throw new System.NotImplementedException();
		}
	}
	public static bool GetInteract()
	{
		switch (_instance._state)
		{
			case State.Free:
			case State.GUI:
				return false;
			case State.FirstPerson:
				return Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0);
			default:
				throw new System.NotImplementedException();
		}
	}

	// Update
	public void Update()
	{
		switch (_state)
		{
			case State.Free:
				if (Input.GetMouseButtonDown(0))
					TransitionState(_lastNonFreeState);
				break;
			default:
				if (Input.GetKeyDown(KeyCode.Escape))
					TransitionState(State.Free);
				break;
		}
	}
}