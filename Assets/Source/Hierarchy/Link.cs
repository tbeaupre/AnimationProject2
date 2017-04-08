using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A link in the model hierarchy
public abstract class Link : MonoBehaviour {
	[SerializeField] protected Vector3 modelRotation = new Vector3(0, 0, 0); // The model's rotation
	[SerializeField] protected Vector3 parentOriginOffset = new Vector3(0, 0, 0); // This link's offset vector from the parent's mesh's origin
	[SerializeField] protected List<ChildLink> children = new List<ChildLink>(); // The list of the link's children
	protected Transform rootTransform;

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

	public void UpdateLink(Transform rootTransform)
	{
		// Update each child node using the newly calculated rotations and translations
		foreach (Link child in this.children)
		{
			child.UpdateLink(transform, rootTransform);
		}
	}

	// Updates the link's position
	public void UpdateLink(Transform parentTransform, Transform rootTransform) {
		this.rootTransform = rootTransform;
		Vector3 parentPos = parentTransform.position;
		Vector3 parentRot = parentTransform.eulerAngles;

		// Reset to model origin and model rotation
		transform.position = new Vector3(0, 0, 0);
		transform.eulerAngles = modelRotation;

		JointRotate();
		JointTranslate();

		transform.position += parentOriginOffset;

		ParentRotate(parentRot);
		ParentTranslate(parentPos, parentRot);

		// Update each child node using the newly calculated rotations and translations
		foreach (Link child in this.children)
		{
			child.UpdateLink(transform, rootTransform);
		}
	}

	// Updates the link's local rotation and translation
	public virtual void JointTranslate() {
		/* Override this to add in either:
		 * 	Root: World transformation and translation
		 * 	Child: Joint transformation
		*/
	}

	// Updates the link's local rotation and translation
	public virtual void JointRotate() {
		/* Override this to add in either:
		 * 	Root: World transformation and translation
		 * 	Child: Joint transformation
		*/
	}

	public void ParentTranslate(Vector3 parentPos, Vector3 parentRot) {
		//transform.position += parentPos;
		Vector3 rotOffset = Quaternion.Euler(parentRot) * parentPos;
		transform.position += rotOffset;
	}

	public void ParentRotate(Vector3 parentRot) {
		Rotate(parentRot);
	}

	// Rotates the model around a point in space using euler angles. Uses YZX order
	public void Rotate(Vector3 euler)
	{
		transform.rotation *= Quaternion.AngleAxis(euler.y, rootTransform.up) *
			Quaternion.AngleAxis(euler.z, rootTransform.forward) *
			Quaternion.AngleAxis(euler.x, rootTransform.right);

		//SubRotate(euler.y, rootTransform.up);
		//SubRotate(euler.z, rootTransform.forward);
		//SubRotate(euler.x, rootTransform.right);
	}

	private void SubRotate(float angle, Vector3 direction)
	{
		Vector3 pos = transform.position;
		Quaternion rotation = Quaternion.AngleAxis(angle, direction);
		pos = rotation * pos;
		transform.position = pos;
		transform.rotation *= rotation;
	}

	public virtual void Translate(Vector3 offset)
	{
		transform.position += offset;
	}
}
