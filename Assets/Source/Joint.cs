using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour {
	[SerializeField] private Vector3 offset = new Vector3(0, 0, 0); // The link origin's offset from the parent
	private Vector3 translation = new Vector3(0, 0, 0); // The change in the link's translation
	private Vector3 rotation = new Vector3(0, 0, 0); // The change in the link's rotation

	public Joint () { }

	// Use this for initialization
	void Start () { }
	
	// Update is called once per frame
	void Update () { }

	public Vector3 GetTranslation()
	{
		return (this.offset + this.translation);
	}

	public Vector3 GetRotation()
	{
		return this.rotation;
	}
}
