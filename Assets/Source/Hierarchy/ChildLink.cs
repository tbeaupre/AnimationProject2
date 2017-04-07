using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A link which is affected by a parent
public class ChildLink : Link {
	[SerializeField] Joint joint; // The joint which affects this link
	[SerializeField] JointAnim anim; // The animation that will affect this link

	// Use this for initialization
	void Start() {
	}
	
	// Update is called once per frame
	void Update() {
	}

	// Initializes the link based on information about its parent
	protected override void Init(Vector3 parentPos, Vector3 parentRot)
	{
		this.modelRotation = transform.eulerAngles - parentRot; // This is the base rotation for this link's model
		this.joint = new Joint((transform.position + modelOrigin) - parentPos, this.anim); // Accounts for model origin and finds offset from parent
		base.Init(parentPos, parentRot); // Initializes children
	}

	// Updates the child's transforms based on joint's transformation
	public override void UpdateLocalTransforms()
	{
		joint.Update(); // Since the joint isn't a MonoBehavior and doesn't get updated automatically

		// Complete local transformation (rotation first, translation second)
		RotateAround(modelOrigin, joint.GetRotation());
		Translate(joint.GetTranslation());
	}

	// Rotates the model around a point in space using euler angles. Uses ZXY order
	public void RotateAround(Vector3 point, Vector3 euler)
	{
		transform.RotateAround(point, new Vector3(0, 0, 1), euler.z);
		transform.RotateAround(point, new Vector3(1, 0, 0), euler.x);
		transform.RotateAround(point, new Vector3(0, 1, 0), euler.y);
	}
}
