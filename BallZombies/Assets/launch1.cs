using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launch1 : MonoBehaviour {

	// Use this for initialization
	public Transform tf;
	public Rigidbody rb;
	public GameObject player;
	public GameObject projectile0;
	public GameObject launcherS;
	public GameObject launcherR;
	public GameObject launcherG;
	public GameObject launcherR1;
	public int power = 70;
	public pmove play;

	public bool chase = true;
	//public GameObject projectile1;
	//public GameObject projectile2;
	public int charge = 0;
	public int randy;
	public float t = 0;
	public float d = 0;
	public float t0;
	public float constantX;
	public float constantdX;
	public float constantZ;
	public float direction;
	public float speed;
	public float jump; 


	//method
	public int getCharge(){
		return charge;
	}
	public float getXPosition(){
		return tf.position.x;
	}
	public float getYPosition(){
		return tf.position.y;
	}
	public float getZPosition(){
		return tf.position.z;
	}
	public static int zAlive = 8;
	public void decreaseLiving() {
		zAlive -= 1;
	}
	public int amountLiving(){
		return zAlive;
	}
	public void gravityOn(){
		rb.useGravity = true;
	}
//	public float isTouching (GameObject a){
//		
//

	void OnCollisionEnter(Collision ball){
		if (ball.gameObject.tag == "ball") {
			chase = false;
			play.score += 5;
			int rand = Random.Range (0, 10);
			if (rand > 8) {
				Instantiate (launcherS);
				launcherS.transform.position = new Vector3 (49, 400, -46);
			} else if (rand > 7) {
				Instantiate (launcherG);
				launcherG.transform.position = new Vector3 (49, 400, -50);
			} else {
				Instantiate (launcherR);
				launcherR.transform.position = new Vector3 (52, 400, -50);
				Instantiate (launcherR1);
				launcherR1.transform.position = new Vector3 (52, 400, -40);
			}
			if (gameObject != null) {
				Destroy (gameObject);
			}
		}
	}
	// Update is called once per frame
	void Start(){
		chase = true;
	}
	void FixedUpdate () {
		if (chase) {
			charge = Random.Range (40, 100);
			charge = 110;
			for (int i = 0; i < 10; i++) {
				if (Mathf.Abs (rb.velocity.z) < 15 && Mathf.Abs (rb.velocity.x) < 15 && tf.position.y < 6) {
					direction = charge * (player.transform.position.x - tf.position.x) * constantdX;
					speed = play.getXForce () * constantX;
					jump = (100 - charge) * .25f;
					jump = 0;
					rb.AddForce (play.getXForce () * constantX + charge * (player.transform.position.x - tf.position.x) * constantdX, jump, charge * (player.transform.position.z - tf.position.z) * constantZ);
				}
			}

		}
//		if ((Mathf.Abs(Mathf.Abs(tf.position.x) - Mathf.Abs(projectile0.transform.position.x)) <= .5 && Mathf.Abs(Mathf.Abs(tf.position.z) - Mathf.Abs(projectile0.transform.position.z)) <= .5 && projectile0.transform.position.y <= 3)){
//			if (chase == true) {
//				decreaseLiving ();
//			}
//			chase = false;
//		}
//			}
		//making it stop when idle
		//}
//		if (!(Input.GetKey("b"))){
//			if (rb.velocity.x > 1.5){
//				rb.AddForce (-1, 0, 0);
//			}
//			if (rb.velocity.x < -1.5){
//				rb.AddForce (1, 0, 0);
//			}
//			if (rb.velocity.z > 1.5){
//				rb.AddForce (-1, 0, 0);
//			}
//			if (rb.velocity.z > -1.5){
//				rb.AddForce (1, 0, 0);
//			}
//		}
	}
}
