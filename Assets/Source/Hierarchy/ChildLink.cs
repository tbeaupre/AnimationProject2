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
		//this.modelOrigin = -modelOriginOffset; // meshOrigin - offset, assuming position and meshOrigin are (0,0,0)
		this.modelRotation = transform.eulerAngles - parentRot; // This is the base rotation for this link's model
		this.joint = new Joint(this.anim); // Accounts for model origin and finds offset from parent
		base.Init(); // Initializes children
	}

	// Updates the child's transforms based on joint's transformation
	public override void JointTransforms()
	{
		joint.Update(); // Since the joint isn't a MonoBehavior and doesn't get updated automatically
		// Might need to use (0,0,0) here!
		RotateAround(modelOrigin, joint.GetRotation());
		Translate(joint.GetTranslation());
	}
}
