using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour {

	// Use this for initialization
	public Transform tf;
	public GameObject player;
	public pScript playerScript;
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(Mathf.Abs(tf.position.x) - Mathf.Abs(player.transform.position.x)) < .7 && Mathf.Abs(Mathf.Abs(tf.position.z) - Mathf.Abs(player.transform.position.z)) <= .7 && Mathf.Abs(Mathf.Abs(tf.position.y) - Mathf.Abs(player.transform.position.y)) < 1){
			Debug.Log("hit");
			playerScript.health -= 10;
		}
	}
}
