using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class editText : MonoBehaviour {

	// Use this for initialization

	public TextMesh tm;
	public Transform tf;
	public GameObject player;
	public pmove pm;
	

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey ("h")) {
			tf.SetPositionAndRotation (new Vector3 ((player.transform.position.x), player.transform.position.y + 0, (player.transform.position.z)), new Quaternion (0, 0, 0, 0));
			tm.text = "Help: \nWASD = Move \nshift = Sprint \nJ = Pick Up Ball \nN = Charge Throw \nL = Throw \nK = Drop Ball \nThe white ball heals you\n" +
			" hold the throwing ball.\nThe Gold enemy will take away your gravity.\nThe Pink enemy will take your speed.\nEverything else will take your health";
		} else {
			tf.SetPositionAndRotation (new Vector3 ((player.transform.position.x), player.transform.position.y + 5, (player.transform.position.z)), new Quaternion (0, 0, 0, 0));
			tm.text = "Health- " + pm.health + "\nSpeed- " + pm.standardSpeed + "\nScore: " + pm.score +"\nhold \"H\" for HELP";
		}
	}
}
