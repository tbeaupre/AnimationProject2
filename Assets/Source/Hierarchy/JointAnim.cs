using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Joint Animations tell the joint what values it should currently have
public class JointAnim : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	// Calculates the rotational velocity which should be applied by the joint
	public virtual Vector3 GetRotation()
	{
		return new Vector3(0, 0, 0);
	}

	// Calculates the velocity which should be applied by the joint
	public virtual Vector3 GetTranslation()
	{
		return new Vector3(0, 0, 0);
	}
}
