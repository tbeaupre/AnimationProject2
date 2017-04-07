using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingAnim : JointAnim {
	[SerializeField] bool pos = true; // Whether the change in rotation is positive or not.
	[SerializeField] Vector3 rotVel = new Vector3(0, 0, 0); // The current rotational velocity which the joint should apply
	[SerializeField] Vector3 rotAccel = new Vector3(0, 0, 0.1f); // The change to make to the rotVel each update
	[SerializeField] Vector3 maxRotVel = new Vector3(0, 0, 20); // The maximum angle which the animation will reach before reversing

	// Calculates the rotational velocity which should be applied by the joint
	public override Vector3 GetRotation()
	{
		if (pos) // inverts calculation if the angle should be decreasing
		{
			rotVel += rotAccel;
			if (rotVel.x > maxRotVel.x || rotVel.y > maxRotVel.y || rotVel.z > maxRotVel.z)
			{
				pos = false;
			}
		} else
		{
			rotVel -= rotAccel;
			if (rotVel.x < -maxRotVel.x || rotVel.y < -maxRotVel.y || rotVel.z < -maxRotVel.z)
			{
				pos = true;
			}
		}
		return rotVel;
	}
}
