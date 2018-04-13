using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class pickedUp : MonoBehaviour {
	public Rigidbody bmove;
	public Collider bcollide;
	public Transform tf;
	public GameObject player;
	private bool onPlayer = false;
	public int charge;
	public int throwPower = 80;
	public Vector3 velocity = new Vector3 (0,0,0);
	public pmove script1;






	// Update is called once per frame
	void FixedUpdate () {
		velocity = bmove.velocity;

		if (2 > Mathf.Abs (Mathf.Abs(tf.position.x) - Mathf.Abs(player.transform.position.x)) && 2 > Mathf.Abs (Mathf.Abs(tf.position.z) - Mathf.Abs(player.transform.position.z)) && tf.position.y < 2.2) {
			if (Input.GetKey ("j")) {
				charge = 0;
				bmove.useGravity = false;
				onPlayer = true;
			}
		}
		if (onPlayer && Input.GetKey ("k")) {
			bmove.useGravity = true;
			onPlayer = false;
		}
		if (onPlayer && Input.GetKey ("n")) {
			charge += 1;
			if (charge > 99) {
				charge = 80;
			}
		}
//		if (!(Input.GetKey("n"))){
//			
//			if (charge > 0) {
//				onPlayer = false;
//			}
//		}
		if (Input.GetKey ("l") && charge > 0) {
			onPlayer = false;
			tf.SetPositionAndRotation (new Vector3 (player.transform.position.x, player.transform.position.y + .52f, player.transform.position.z + .52f), new Quaternion (0, 0, 0, 0));
			bmove.AddForce (script1.getXForce(), 100, charge * throwPower * .5f);

			charge = 0;
		}
		
		if (onPlayer) {
			bmove.useGravity = false;
			tf.SetPositionAndRotation (new Vector3 (player.transform.position.x + .52f, player.transform.position.y + .52f, player.transform.position.z + .52f), new Quaternion (0, 0, 0, 0));
		}
		if (!onPlayer) {
			bmove.useGravity = true;
		}
		if (tf.position.y < 0) {
			tf.SetPositionAndRotation (new Vector3 (50, 4, -40), new Quaternion (0, 0, 0, 0));
		}
	}
}