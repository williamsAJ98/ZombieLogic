using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pScript : MonoBehaviour {

	// Use this for initialization
//	void Start () {
//		
//	}
	public Rigidbody rb;
	public Transform tf;

	private float forwardForce = 1200;//100 make private
	private float sideForce = 1200;//200 make private for sphere// for cube-800
	public float jump = 90;//0-90 attribute
	public bool hasBall = false;
	public int speedAttribute = 90;
	public float xForce = 0;
	public int standardSpeed = 90;
	public int health = 200;
	private bool alive = true;


	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 v3Velocity = rb.velocity;
		if (alive) {

			if (Input.GetKey ("h")) {
				speedAttribute = standardSpeed * 2;
			}
			if (!(Input.GetKey ("h"))) {
				speedAttribute = standardSpeed;
			}

			//if (v3Velocity.x <5 && v3Velocity.z < 3 && v3Velocity.y < 10) {
			if (Input.GetKey ("e") && transform.position.y < 20 && v3Velocity.z < (speedAttribute / 12)) {
				rb.AddForce (0, 0, forwardForce * Time.deltaTime);
			}
			if (Input.GetKey ("d") && transform.position.y < 20 && v3Velocity.z > -(speedAttribute / 13)) {
				rb.AddForce (0, 0, forwardForce * Time.deltaTime * (-1));
			}
			if (Input.GetKey ("s") && transform.position.y < 20 && v3Velocity.x > -(speedAttribute / 11)) {
				xForce += sideForce * Time.deltaTime * -1;
				rb.AddForce (sideForce * Time.deltaTime * -1, 0, 0);
			}
			if (Input.GetKey ("f") && transform.position.y < 20 && v3Velocity.x < (speedAttribute / 11)) {
				xForce += sideForce * Time.deltaTime;
				rb.AddForce (sideForce * Time.deltaTime, 0, 0);
			}
			if ((Input.GetKey ("4") || Input.GetKey ("3")) && transform.position.y < 19.4) {
				rb.AddForce (0, (jump + 1500) * Time.deltaTime, 0);
			}
			//stablizing z axis
			if (!(Input.GetKey ("e") || Input.GetKey ("d")) && rb.velocity.z > 1.5) {
				rb.AddForce (0, 0, -1);
			}
			if (!(Input.GetKey ("w") || Input.GetKey ("s")) && rb.velocity.z < -1.5) {
				rb.AddForce (0, 0, 1.4f);
			}
			//stablizing x axis
			if (!(Input.GetKey ("s") || Input.GetKey ("f")) && rb.velocity.x > 1) {
				xForce = 0;
				rb.AddForce (-1, 0, 0);
			}
			if (!(Input.GetKey ("s") || Input.GetKey ("f")) && rb.velocity.x < -1) {
				xForce = 0;
				rb.AddForce (1, 0, 0);
			}

			//duck- in the case for a sphere
			if ((Input.GetKey ("x") || Input.GetKey ("c")) && tf.localScale.y >= 1) {
				tf.localScale += new Vector3 (0.1f, -0.1f, 0.1f); 

			}
			if (!(Input.GetKey ("x") || Input.GetKey ("c")) && tf.localScale.y < 2) {
				tf.localScale += new Vector3 (-0.1f, 0.1f, -0.1f);
			}
			if (health <= 0) {
				rb.constraints = RigidbodyConstraints.None;
				for (int i = 0; i < 100; i++) {
					rb.useGravity = false;
				}
				rb.useGravity = true;
				alive = false;

			}
		}
	}
}
