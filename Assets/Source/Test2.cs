using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour {
	Vector3 translate = new Vector3(3, 0, 0);
	Vector3 rotate = new Vector3(0, 30, 0);

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(0, 0, 0);
		transform.eulerAngles = new Vector3(0, 0, 0);

		transform.Translate(translate, Space.World);
		transform.Rotate(rotate, Space.World);

		transform.Translate(translate, Space.World);
		transform.Rotate(rotate, Space.World);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
