using UnityEngine;
using System.Collections.Generic;

public class GrabbableController : MonoBehaviour
{
    // User-facing variables
    [SerializeField]
    private float _acceleration;
    [SerializeField]
    private float _maxAcceleration;
    [SerializeField]
    private float _maxVelocity;
    [SerializeField]
    private float _timeToReach;
    [SerializeField]
    private Vector3 _offset;

    // Private variables
    private Rigidbody _rigidbody;
    private bool _isGrabbed;

    // Initialization
    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _isGrabbed = false;
    }

    // Public interface
    public void Grab()
    {
        _rigidbody.useGravity = false;
        _isGrabbed = true;
    }
    public void Release()
    {
        _rigidbody.useGravity = true;
        _isGrabbed = false;
    }
    public void ToggleGrabbed()
    {
        if (_isGrabbed)
            Release();
        else
            Grab();
    }

    // Update
    public void Update()
    {
        if (_isGrabbed)
        {
            MoveUtil.AccelerateClampedToward(
                _rigidbody,
                PlayerController.instance.transform.TransformPoint(_offset),
                _acceleration,
                _maxAcceleration,
                _maxVelocity,
                _timeToReach);
        }
    }
}