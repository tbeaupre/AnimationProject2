using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A link in the model hierarchy
public abstract class Link : MonoBehaviour {
	[SerializeField] protected Vector3 modelRotation = new Vector3(0, 0, 0); // The model's rotation
	[SerializeField] protected Vector3 modelOriginOffset = new Vector3(0, 0, 0); // The model's origin offset vector
	[SerializeField] protected Vector3 modelOrigin = new Vector3(0, 0, 0); // The model's origin
	[SerializeField] protected List<ChildLink> children = new List<ChildLink>(); // The list of the link's children

	// Use this for initialization
	void Start () { }
	
	// Update is called once per frame
	void Update () { }

	protected void Init()
	{
		foreach (ChildLink child in this.children)
		{
			child.Init(transform.position, transform.eulerAngles);
		}
	}

	// Updates the link's position
	public void UpdateLink(Vector3 parentPos, Vector3 parentRot, Vector3 parentOriginOffset) {
		//Vector3 rotatedParentOriginOffset = Quaternion.Euler(parentRot) * parentOriginOffset;
		Vector3 rotatedOriginOffset = transform.Rotate * modelOriginOffset;
		modelOrigin = transform.position - rotatedOriginOffset;

		// Reset to model origin and model rotation
		transform.position = new Vector3(0, 0, 0);
		transform.eulerAngles = new Vector3(0, 0, 0);

		UpdateModelTransforms();

		UpdateJointTransforms();

		// Complete parent transformation (rotation first, translation second)
		// FOR TESTING PURPOSES
		//RotateAround((parentPos), parentRot);
		//RotateAround((parentPos + parentOrigin), parentRot);
		RotateAround((parentPos - parentOriginOffset), parentRot);
		Translate(parentPos);

		// Update each child node using the newly calculated rotations and translations
		foreach (Link child in this.children)
		{
			child.UpdateLink(transform.position, transform.eulerAngles, modelOriginOffset);
		}
	}

	public void UpdateModelTransforms() {
		Vector3 modelOrigin = -modelOriginOffset;
		transform.Translate(modelOriginOffset, Space.World);
		RotateAround(modelOrigin, modelRotation);
	}

	// Updates the link's local rotation and translation
	public virtual void UpdateJointTransforms() {
		/* Override this to add in either:
		 * 	Root: World transformation and translation
		 * 	Child: Joint transformation
		*/
	}

	// Rotates the model around a point in space using euler angles. Uses ZXY order
	public void RotateAround(Vector3 point, Vector3 euler)
	{
		transform.RotateAround(point, new Vector3(0, 0, 1), euler.z);
		transform.RotateAround(point, new Vector3(1, 0, 0), euler.x);
		transform.RotateAround(point, new Vector3(0, 1, 0), euler.y);
	}

	public virtual void Translate(Vector3 offset)
	{
		transform.position += offset;
	}
}
