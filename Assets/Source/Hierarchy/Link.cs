using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A link in the model hierarchy
public abstract class Link : MonoBehaviour {
	[SerializeField] protected Vector3 modelRotation = new Vector3(0, 0, 0); // The model's rotation
	[SerializeField] protected Vector3 modelOrigin = new Vector3(0, 0, 0); // The model's origin
	[SerializeField] protected List<ChildLink> children = new List<ChildLink>(); // The list of the link's children

	// Use this for initialization
	void Start () { }
	
	// Update is called once per frame
	void Update () { }

	protected virtual void Init(Vector3 parentPos, Vector3 parentRot)
	{
		foreach (ChildLink child in this.children)
		{
			child.Init(transform.position, transform.eulerAngles);
		}
	}

	// Updates the link's position
	public void UpdateLink(Vector3 parentPos, Vector3 parentRot) {
		// Reset to model origin and model rotation
		transform.position = -modelOrigin;
		transform.eulerAngles = modelRotation;

		// Complete local transformation
		UpdateLocalTransforms();

		// Complete parent transformation (rotation first, translation second)
		Rotate(parentRot);
		Translate(parentPos);

		// Update each child node using the newly calculated rotations and translations
		foreach (Link child in this.children)
		{
			child.UpdateLink(transform.position, transform.eulerAngles);
		}
	}

	// Updates the link's local rotation and translation
	public virtual void UpdateLocalTransforms() {
		/* Override this to add in either:
		 * 	Root: World transformation and translation
		 * 	Child: Joint transformation
		*/
	}

	public virtual void Rotate(Vector3 euler)
	{
		transform.eulerAngles += euler;
	}

	public virtual void Translate(Vector3 offset)
	{
		transform.position += offset;
	}
}
