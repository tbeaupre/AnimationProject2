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
	public void Init(Vector3 parentPos, Vector3 parentRot)
	{
		this.modelRotation = transform.eulerAngles - parentRot; // This is the base rotation for this link's model
		this.joint = new Joint((transform.position + modelOriginOffset) - parentPos, this.anim); // Accounts for model origin and finds offset from parent
		base.Init(); // Initializes children
	}

	// Updates the child's transforms based on joint's transformation
	public override void UpdateJointTransforms()
	{
		joint.Update(); // Since the joint isn't a MonoBehavior and doesn't get updated automatically

		// Complete local transformation (rotation first, translation second)
		RotateAround(modelOriginOffset, joint.GetRotation());
		Translate(joint.GetTranslation());
	}
}
