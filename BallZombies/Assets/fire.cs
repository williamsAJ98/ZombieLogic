using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public GameObject player;
	public Transform tf;
	public Rigidbody rb;
	public pScript playerScript;

	public int charge;

	public float constantdX;
	public float constantZ;
	public float direction;
	
	// Update is called once per frame
	void Update () {
		if (tf.position.y <=21) {
			
			for (int i = 0; i < 10; i++) {
				if (Mathf.Abs (rb.velocity.z) < 15 && Mathf.Abs (rb.velocity.x) < 15 && tf.position.y > 18.5) {
					direction = charge * (player.transform.position.x - tf.position.x) * constantdX;

					rb.AddForce (playerScript.xForce * .001f + charge * (player.transform.position.x - tf.position.x) * constantdX, 0, charge * (player.transform.position.z - tf.position.z) * constantZ);
				}
			}
		}
//		//collision
//		if (Mathf.Abs(Mathf.Abs(tf.position.x) - Mathf.Abs(player.transform.position.x)) < .62 && Mathf.Abs(Mathf.Abs(tf.position.z) - Mathf.Abs(player.transform.position.z)) <= .5 && Mathf.Abs(Mathf.Abs(tf.position.y) - Mathf.Abs(player.transform.position.y)) < 1){
//			Debug.Log("hit");
//			playerScript.health -= 20;
//		}
//		if ((Mathf.Abs(Mathf.Abs(tf.position.x) - Mathf.Abs(projectile0.transform.position.x)) <= .5 && Mathf.Abs(Mathf.Abs(tf.position.z) - Mathf.Abs(projectile0.transform.position.z)) <= .5 && projectile0.transform.position.y <= 3)){
//			if (chase == true) {
//				decreaseLiving ();
//			}
//			chase = false;
//		}
	}
}
