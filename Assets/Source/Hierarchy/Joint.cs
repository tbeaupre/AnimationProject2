using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Joints contain the data for the local transformations of a link
public class Joint {
	Vector3 translation = new Vector3(0, 0, 0); // The change in the link's translation
	Vector3 rotation = new Vector3(0, 0, 0); // The change in the link's rotation
	JointAnim anim; // The animation which controls the joint

	public Joint (JointAnim anim)
	{
		this.anim = anim;
	}

	// Updates the link's transformations based on the animation
	public void Update () {
		this.rotation = new Vector3(0, 0, 20);
		// FOR TESTING PURPOSES
		// this.rotation = anim.GetRotation();
		this.translation = anim.GetTranslation();
	}

	public Vector3 GetTranslation()
	{
		return this.translation;
	}

	public Vector3 GetRotation()
	{
		return this.rotation;
	}
}
