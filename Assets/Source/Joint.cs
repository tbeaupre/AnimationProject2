using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint {
	Vector3 posOffset; // The link origin's positional offset from the parent
	Vector3 translation = new Vector3(0, 0, 0); // The change in the link's translation
	Vector3 rotation = new Vector3(0, 0, 0); // The change in the link's rotation
	JointAnim anim;

	public Joint (Vector3 posOffset, JointAnim anim)
	{
		this.posOffset = posOffset;
		this.anim = anim;
	}

	public void Update () {
		this.rotation = anim.GetRotation();
	}

	public Vector3 GetTranslation()
	{
		return (this.posOffset + this.translation);
	}

	public Vector3 GetRotation()
	{
		return this.rotation;
	}
}
