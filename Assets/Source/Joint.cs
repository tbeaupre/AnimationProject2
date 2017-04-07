using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour {
	[SerializeField] private Vector3 posOffset = new Vector3(0, 0, 0); // The link origin's positional offset from the parent
	[SerializeField] private Vector3 translation = new Vector3(0, 0, 0); // The change in the link's translation
	[SerializeField] private Vector3 rotation = new Vector3(0, 0, 0); // The change in the link's rotation

	public Joint (Vector3 posOffset)
	{
		this.posOffset = posOffset;
	}

	// Use this for initialization
	void Start () { }
	
	// Update is called once per frame
	void Update () { }

	public Vector3 GetTranslation()
	{
		return (this.posOffset + this.translation);
	}

	public Vector3 GetRotation()
	{
		return this.rotation;
	}
}
