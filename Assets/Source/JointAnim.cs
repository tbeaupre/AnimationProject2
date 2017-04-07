using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointAnim : MonoBehaviour {
	[SerializeField] bool pos = true;
	[SerializeField] Vector3 rotVel = new Vector3(0, 0, 0);
	[SerializeField] Vector3 rotAccel = new Vector3(0, 0, 0.1f);
	[SerializeField] Vector3 maxRotVel = new Vector3(0, 0, 20);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector3 GetRotation()
	{
		if (pos)
		{
			rotVel += rotAccel;
			if (rotVel.x > maxRotVel.x || rotVel.y > maxRotVel.y || rotVel.z > maxRotVel.z)
			{
				pos = false;
			}
		} else
		{
			rotVel -= rotAccel;
			if (rotVel.x < -maxRotVel.x || rotVel.y < -maxRotVel.y || rotVel.z < -maxRotVel.z)
			{
				pos = true;
			}
		}
		return rotVel;
	}
}
