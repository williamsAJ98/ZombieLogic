using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseActions : MonoBehaviour {
	public GameObject b0;


	// Use this for initialization

		private string xAxis = "Mouse X";
		private string yAxis = "Mouse Y";
		public int charge = 0;
		public int maxCharge;
		public float xA;
		public float yA;

	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButtonDown(0)) {
			xA = Input.GetAxis(xAxis);
			yA = Input.GetAxis(yAxis);
			Debug.Log (xA + ", " + yA);

		}
	}
}
