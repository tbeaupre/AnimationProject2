using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildLink : Link {
	[SerializeField] private Joint joint = new Joint(); // The joint which this link comes from

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void UpdateLocalTransforms()
	{
		// Complete local transformation (rotation first, translation second)
		transform.Rotate(joint.GetRotation());
		transform.Translate(joint.GetTranslation());
	}
}
