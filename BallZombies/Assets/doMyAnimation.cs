using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doMyAnimation : MonoBehaviour {

	// Use this for initialization
	public Animator myFirst;

	void Start() {
		myFirst = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("g")) {
			myFirst.Play ("screen right dive");
		}
	}
}
