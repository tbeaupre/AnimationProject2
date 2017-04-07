using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A Special type of link which has no parent. It can be transformed freely and its children follow
public class RootLink : Link {
	// Use this for initialization
	void Start () {
		this.Init(); // The values in here are bogus
	}
	
	// Update is called once per frame
	void Update () {
		//this.UpdateLink(transform.position, transform.eulerAngles, new Vector3(0, 0, 0)); FOR TESTING PURPOSES
		this.UpdateLink(new Vector3(0, 0, 0), new Vector3(0, 0, 0));
	}
}
