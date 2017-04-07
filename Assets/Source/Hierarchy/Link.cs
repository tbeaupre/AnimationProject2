using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A link in the model hierarchy
public abstract class Link : MonoBehaviour {
	[SerializeField] protected Vector3 modelRotation = new Vector3(0, 0, 0); // The model's rotation
	[SerializeField] protected Vector3 parentOriginOffset = new Vector3(0, 0, 0); // This link's offset vector from the parent's mesh's origin
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
	public void UpdateLink(Vector3 parentPos, Vector3 parentRot) {
		
		// Reset to model origin and model rotation
		transform.position = new Vector3(0, 0, 0);
		transform.eulerAngles = modelRotation;

		JointTransforms();

		ParentTransforms(parentPos, parentRot);

		// Update each child node using the newly calculated rotations and translations
		foreach (Link child in this.children)
		{
			child.UpdateLink(transform.position, transform.eulerAngles);
		}
	}

	// Updates the link's local rotation and translation
	public virtual void JointTransforms() {
		/* Override this to add in either:
		 * 	Root: World transformation and translation
		 * 	Child: Joint transformation
		*/
	}

	public void ParentTransforms(Vector3 parentPos, Vector3 parentRot) {
		Rotate(parentRot);
		//transform.Rotate(parentRot);
		transform.Translate(parentPos);
		//Vector3 parentRotatedOriginOffset = Quaternion.Euler(parentRot) * parentOriginOffset;
		//transform.Translate(parentPos + parentRotatedOriginOffset);
	}

	// Rotates the model around a point in space using euler angles. Uses XYZ order
	public void Rotate(Vector3 euler)
	{
		transform.Rotate(euler.x, 0, 0);
		transform.Rotate(0, euler.y, 0);
		transform.Rotate(0, 0, euler.z);
	}

	public virtual void Translate(Vector3 offset)
	{
		transform.position += offset;
	}
}
