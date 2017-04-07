using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildLink : Link {
	private Link parent;
	[SerializeField] Joint joint; // The joint which this link comes from
	[SerializeField] Vector3 arcRot;
	[SerializeField] Vector3 arcTrans;
	[SerializeField] JointAnim anim; // The animation that will affect this link

	// Use this for initialization
	void Start() {
	}
	
	// Update is called once per frame
	void Update() {
		
	}

	protected override void Init(Link parent)
	{
		this.parent = parent;
		this.modelRotation = transform.eulerAngles - parent.transform.eulerAngles;
		this.joint = new Joint((transform.position + modelOrigin) - parent.transform.position, this.anim);
		// Init the children
		base.Init(parent);
	}

	public override void UpdateLocalTransforms()
	{
		joint.Update();
		arcRot = joint.GetRotation();
		arcTrans = joint.GetTranslation();
		// Complete local transformation (rotation first, translation second)
		RotateAround(modelOrigin, arcRot);
		Translate(arcTrans);
	}

	public void RotateAround(Vector3 point, Vector3 euler)
	{
		transform.RotateAround(point, new Vector3(0, 0, 1), euler.z);
		transform.RotateAround(point, new Vector3(1, 0, 0), euler.x);
		transform.RotateAround(point, new Vector3(0, 1, 0), euler.y);
	}
}
