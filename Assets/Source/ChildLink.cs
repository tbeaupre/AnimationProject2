using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildLink : Link {
	[SerializeField] private Joint joint; // The joint which this link comes from

	// Use this for initialization
	void Start() {
	}
	
	// Update is called once per frame
	void Update() {
		
	}

	protected override void Init(Vector3 parentTranslate, Vector3 parentRotate)
	{
		this.modelRotation = transform.eulerAngles - parentRotate;
		this.joint = new Joint(transform.position);
		base.Init(parentTranslate, parentRotate);
	}

	public override void UpdateLocalTransforms()
	{
		// Complete local transformation (rotation first, translation second)
		transform.Rotate(joint.GetRotation());
		transform.Translate(joint.GetTranslation());
	}
}
