﻿using System.Collections;
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
		this.joint = new Joint(this.anim);
		base.Init(); // Initializes children
	}

	// Updates the child's transforms based on joint's translation
	public override void JointTranslate()
	{
		transform.position += joint.GetTranslation();
	}

	// Updates the child's transforms based on joint's rotation
	public override void JointRotate()
	{
		joint.Update(); // Since the joint isn't a MonoBehavior and doesn't get updated automatically
		Rotate(joint.GetRotation());
	}
}
