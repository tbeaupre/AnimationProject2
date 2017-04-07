using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootLink : Link {
	[SerializeField] private Vector3 translation;
	[SerializeField] private Vector3 rotation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.UpdateLink(new Vector3(0,0,0), new Vector3(0,0,0));
	}
}
