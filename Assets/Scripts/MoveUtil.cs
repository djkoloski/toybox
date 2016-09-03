using UnityEngine;
using System.Collections.Generic;

public static class MoveUtil
{
    public static void AccelerateClamped2D(Rigidbody rb, Vector2 targetVelocity, float acceleration, float maxAcceleration)
    {
        Vector2 dv = targetVelocity - new Vector2(rb.velocity.x, rb.velocity.z);
        dv = dv.normalized * Mathf.Min(dv.magnitude * acceleration, maxAcceleration);
        rb.AddForce(new Vector3(dv.x, 0.0f, dv.y), ForceMode.Acceleration);
    }

    public static void AccelerateClamped(Rigidbody rb, Vector3 targetVelocity, float acceleration, float maxAcceleration, bool debug = false)
    {
        Vector3 dv = targetVelocity - rb.velocity;
        dv = dv.normalized * Mathf.Min(dv.magnitude * acceleration, maxAcceleration);
        rb.AddForce(dv, ForceMode.Acceleration);
    }

    public static void AccelerateClampedToward(Rigidbody rb, Vector3 target, float acceleration, float maxAcceleration, float maxVelocity, float timeToReach)
    {
        Vector3 targetVelocity = target - rb.transform.position;
        targetVelocity = targetVelocity.normalized * Mathf.Min(targetVelocity.magnitude / timeToReach, maxVelocity);
        AccelerateClamped(rb, targetVelocity, acceleration, maxAcceleration, true);
    }

    public static void ClampVelocity2D(Rigidbody rb, float maxVelocity)
    {
        Vector3 velocity = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z);
        velocity = velocity.normalized * Mathf.Min(velocity.magnitude, maxVelocity);
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }

    public static void ClampVelocity(Rigidbody rb, float maxVelocity)
    {
        rb.velocity = rb.velocity.normalized * Mathf.Min(rb.velocity.magnitude, maxVelocity);
    }
}
