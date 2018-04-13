using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class moveAI : MonoBehaviour {
	public Rigidbody rb;
	public Transform tf;


	//;
	// Use this for initialization
	private float forwardForce = 100;//100 make private
	private float sideForce = 100;//200 make private
	public float jump;//0-90 attribute
	public bool hasBall = false;
	public int speedAttribute;
	private int randy;
	public int level = 0;

	//The ball or balls
	public GameObject b0;
	//player
	public GameObject player;
	//public GameObject[] balls;


	//public Vector3 trans = ((1.25)(.5)(1.25));

	//public void Throw(){

	//}



	// Update is called once per frame
	void FixedUpdate () {
		if (level > 0) {
			if (b0.transform.position.y <= 2.1) {
				Vector3 v3Velocity = rb.velocity;
				randy = Random.Range (0, 110);

				//if (v3Velocity.x <5 && v3Velocity.z < 3 && v3Velocity.y < 10) {
				//forward - to computer it is backwards
				if (randy < 10 && transform.position.y < 2.2) {
					for (int i = Random.Range (500, 700); i > 0; i--) {
						if (v3Velocity.z < (speedAttribute / 13)) {
							rb.AddForce (0, 0, forwardForce * Time.deltaTime);
						}
					}
				}
				//back- forward to computer
				if (randy < 20 && randy > 10 && transform.position.y < 2.2) {
					for (int i = Random.Range (500, 800); i > 0; i--) {
						if (v3Velocity.z > -(speedAttribute / 12)) {
							rb.AddForce (0, 0, forwardForce * Time.deltaTime * (-1));
						}
					}
				}
				if (randy < 55 && randy > 20 && transform.position.y < 2.2) {
					for (int i = Random.Range (100, 800); i > 0; i--) {
						if (v3Velocity.x > -(speedAttribute / 11)) {
							rb.AddForce (sideForce * Time.deltaTime * -1, 0, 0);
						}
					}
				}
				//my right
				if (randy < 90 && randy > 55 && transform.position.y < 2.2) {
					for (int i = Random.Range (100, 800); i > 0; i--) {
						if (v3Velocity.x < (speedAttribute / 11)) {
							rb.AddForce (sideForce * Time.deltaTime, 0, 0);
						}
					}
				}
				//my left
				if (randy < 100 && randy > 90) {
					for (int i = Random.Range (20, 70); i > 0; i--) {
						if (transform.position.y < 3){
							rb.AddForce (0, (jump + 51) * Time.deltaTime, 0);
						}
					}
				}

				//duck- in the case for a sphere
				if (randy < 102 && randy > 100) {
					for (int i = Random.Range (20, 70); i > 0; i--) {
						if (tf.localScale.y >= .5){
							tf.localScale += new Vector3 (0.1f, -0.1f, 0.1f); 
						}
					}

				}
				if (!(randy < 102 && randy > 100) && tf.localScale.y < 1) {
					tf.localScale += new Vector3 (-0.1f, 0.1f, -0.1f);
				}
			}
		}

		//}

//		if (hasBall == false) {
//			if (2 > Mathf.Abs (b0.transform.position.x - tf.position.x) && 2 > Mathf.Abs (b0.transform.position.x - tf.position.x) && tf.position.y < 2.2) {
//				if (Input.GetKey ("j")){
//					hasBall = true;
//				}
//			}
//		}
//		if (hasBall == true) {
//			if (Input.GetKey ("k")) {
//				hasBall = false;
//			}
//			b0.transform.SetPositionAndRotation (new Vector3 (tf.position.x + .52f, tf.position.y + .52f, tf.position.z + .52f), new Quaternion (0,0,0,0));
//		}
//		if (level == 1) {
//			randy = Random.Range (1, 5);
//			randy = 1;
//			//while (b0.transform.position.y < 2.2) {
//				if (randy == 1) {
//					
//					//move chain goes here. might use transform. nope
//					//toward me
//					for (int i = Random.Range (500, 700); i > 0; i--) {
//						if (rb.velocity.z < -(speedAttribute / 13)) {
//							rb.AddForce (0, 0, forwardForce * Time.deltaTime * -1);
//						}
//					}
//					for (int i = Random.Range (500, 700); i > 0; i--) {
//						if (rb.velocity.x < -(speedAttribute / 11)) {
//							rb.AddForce (forwardForce * Time.deltaTime * -1, 0, 0);
//						}
//					}
//				}
			//}else if (hasBall) {
//
			//			} else {
//
//			}
		//}
	}
}