using UnityEngine;
using System.Collections.Generic;

public static class MoveUtil
{
	public static void AccelerateClamped1D(Rigidbody2D rb, float targetVelocity, float acceleration, float maxAcceleration)
	{
		float dv = targetVelocity - rb.velocity.x;
		dv = Mathf.Sign(dv) * Mathf.Min(Mathf.Abs(dv) * acceleration, maxAcceleration);
		rb.AddForce(Vector2.right * dv * rb.mass, ForceMode2D.Force);
	}
	public static void AccelerateClampedToward1D(Rigidbody2D rb, float target, float acceleration, float maxAcceleration, float maxVelocity, float timeToReach)
	{
		float targetVelocity = target - rb.position.x;
		targetVelocity = Mathf.Sign(targetVelocity) * Mathf.Min(Mathf.Abs(targetVelocity) / timeToReach, maxVelocity);
		AccelerateClamped1D(rb, targetVelocity, acceleration, maxAcceleration);
	}
	public static void ClampVelocity1D(Rigidbody2D rb, float maxVelocity)
	{
		rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity), rb.velocity.y);
	}

	public static void AccelerateClamped2D(Rigidbody2D rb, Vector2 targetVelocity, float acceleration, float maxAcceleration)
	{
		Vector2 dv = targetVelocity - rb.velocity;
		dv = dv.normalized * Mathf.Min(dv.magnitude * acceleration, maxAcceleration);
		rb.AddForce(dv * rb.mass, ForceMode2D.Force);
	}
	public static void AccelerateClampedToward2D(Rigidbody2D rb, Vector2 target, float acceleration, float maxAcceleration, float maxVelocity, float timeToReach)
	{
		Vector2 targetVelocity = target - rb.position;
		targetVelocity = targetVelocity.normalized * Mathf.Min(targetVelocity.magnitude / timeToReach, maxVelocity);
		AccelerateClamped2D(rb, targetVelocity, acceleration, maxAcceleration);
	}
	public static void ClampVelocity2D(Rigidbody2D rb, float maxVelocity)
	{
		rb.velocity = rb.velocity.normalized * Mathf.Min(rb.velocity.magnitude, maxVelocity);
	}
}