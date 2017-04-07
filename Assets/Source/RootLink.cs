using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootLink : Link {

	// Use this for initialization
	void Start () {
		this.Init(this);
	}
	
	// Update is called once per frame
	void Update () {
		this.UpdateLink(new Vector3(0,0,0), new Vector3(0,0,0));
	}
}
