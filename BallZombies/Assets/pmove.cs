using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pmove : MonoBehaviour {
	public Rigidbody rb;
	public Transform tf;

	public GameObject a;
	public GameObject b;
	public GameObject c;
	public GameObject d;
	public GameObject e;
	public GameObject f;
	public GameObject g;
	public GameObject h;
	public GameObject help;
	public launch1 launchscript;

	// Use this for initialization
	private float forwardForce = 100;//100 make private
	private float sideForce = 200;//200 make private
	public float jump;//0-90 attribute
	public bool hasBall = false;
	public int speedAttribute = 90;
	public int ballCount = 0;
	public float xForce = 0;
	public int standardSpeed = 90;
	public int health = 1000;
	public int score = 0;


	//The ball or balls
	public GameObject b0;
	//public GameObject[] balls;
	public float getVelocityX(){
		return rb.velocity.x;
	}

	//public Vector3 trans = ((1.25)(.5)(1.25));

	//public void Throw(){

	//}
	public float getXForce(){
		return xForce;
	}
	public bool isTouchingZomb(GameObject zomb){
		if (Mathf.Abs(Mathf.Abs(tf.position.z) - Mathf.Abs(zomb.transform.position.z)) <= 1 && Mathf.Abs(Mathf.Abs(tf.position.x) - Mathf.Abs(zomb.transform.position.x)) <= 1){
			return true;
		}
		return false;
	}

	void OnCollisionEnter(Collision otherObject){
		if (otherObject.gameObject.tag == "enemy") {
			health -= 4;
		}
		if (otherObject.gameObject == a) {
			rb.useGravity = false;
		}
		if (otherObject.gameObject == d) {
			standardSpeed -= 1;
		}
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 v3Velocity = rb.velocity;
		//sprint option
		if (Input.GetKey(KeyCode.LeftShift)) {
			speedAttribute = standardSpeed * 2;
		}
		if (!(Input.GetKey(KeyCode.LeftShift))) {
			speedAttribute = standardSpeed;
		}

		//if (v3Velocity.x <5 && v3Velocity.z < 3 && v3Velocity.y < 10) {
		if (Input.GetKey ("w") && transform.position.y < 2.2 && v3Velocity.z < (speedAttribute/12)) {
			rb.AddForce (0, 0, forwardForce * Time.deltaTime);
		}
		if (Input.GetKey ("s") && transform.position.y < 2.2 && v3Velocity.z > -(speedAttribute/13)) {
			rb.AddForce (0, 0, forwardForce * Time.deltaTime * (-1));
		}
		if (Input.GetKey ("a") && transform.position.y < 2.2 && v3Velocity.x > -(speedAttribute/11)) {
			xForce += sideForce * Time.deltaTime * -1;
			rb.AddForce (sideForce * Time.deltaTime * -1, 0, 0);
		}
		if (Input.GetKey ("d") && transform.position.y < 2.2 && v3Velocity.x < (speedAttribute/11)) {
			xForce += sideForce * Time.deltaTime;
			rb.AddForce (sideForce * Time.deltaTime, 0, 0);
		}
		if ((Input.GetKey ("4") || Input.GetKey ("3")) && transform.position.y < 3) {
			rb.AddForce (0,( jump + 51) * Time.deltaTime, 0);
		}
		//stablizing z axis
		if (!(Input.GetKey ("w") || Input.GetKey ("s")) && rb.velocity.z > 1.5) {
			rb.AddForce (0, 0, -1);
		}
		if (!(Input.GetKey ("w") || Input.GetKey ("s")) && rb.velocity.z < -1.5) {
			rb.AddForce (0, 0, 1.4f);
		}
		//stablizing x axis
		if (!(Input.GetKey ("a") || Input.GetKey ("d")) && rb.velocity.x > 1) {
			xForce = 0;
			rb.AddForce (-1, 0, 0);
		}
		if (!(Input.GetKey ("a") || Input.GetKey ("d")) && rb.velocity.x < -1) {
			xForce = 0;
			rb.AddForce (1, 0, 0);
		}

		//duck- in the case for a sphere
		if ((Input.GetKey ("x") || Input.GetKey ("c")) && tf.localScale.y >= .5) {
			tf.localScale += new Vector3 (0.1f, -0.1f, 0.1f); 

		}
		if (!(Input.GetKey ("x") || Input.GetKey ("c")) && tf.localScale.y < 1) {
			tf.localScale += new Vector3 (-0.1f, 0.1f, -0.1f);
		}
		if (tf.position.y > 3) {
			health -= 1;
		}

			//}
		
		if (hasBall == false) {
			if (2 > Mathf.Abs (Mathf.Abs(b0.transform.position.x) - Mathf.Abs(tf.position.x)) && 2 > Mathf.Abs (Mathf.Abs(b0.transform.position.z) - Mathf.Abs(tf.position.z)) && tf.position.y < 2.2 && ballCount == 0) {
				if (Input.GetKey ("j")){
					hasBall = true;
				}
			}
		}
		if (hasBall == true) {
			if (Input.GetKey ("k")) {
				hasBall = false;
				ballCount -= 1;
			}
			//b0.transform.SetPositionAndRotation (new Vector3 (tf.position.x + .52f, tf.position.y + .52f, tf.position.z + .52f), new Quaternion (0,0,0,0));
		}
//		//for the zombie bit
//		if (isTouchingZomb (a)) {
//			rb.useGravity = false;
//		}
//		if (isTouchingZomb (b)) {
//			health -= 5;
//		}
//		if (isTouchingZomb (c)) {
//			health -= 1;
//		}
//		if (isTouchingZomb (d)) {
//			standardSpeed -= 2;
//		}
//		if (isTouchingZomb (e)) {
//			health -= 2;
//		}
//		if (isTouchingZomb (f)) {
//			health -= 2;
//		}
//		if (isTouchingZomb (g)) {
//			health -= 2;
//		}
//		if (isTouchingZomb (h)) {
//			health -= 2;
//		}
		if (isTouchingZomb (help)) {
			standardSpeed = 99;
			if (health < 1000) {
				health += 1;
			}
			rb.useGravity = true;
		}
		if (health <= 0) {
			health = 0;
			Debug.Log("You Lose");
			Time.timeScale = 0;
		}
		if (tf.position.y > 9 && health > 0) {
			health -= 40;
		}
//		if (launchscript.amountLiving () < 1) {
//			Debug.Log ("You Win");
//			Time.timeScale = 0;
//		}
		if (standardSpeed < 0) {
			standardSpeed = 0;
		}
			

	}
}