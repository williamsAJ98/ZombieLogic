using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followObject : MonoBehaviour {

	// Use this for initialization
	public Transform camt;
	public GameObject player;
	private Vector3 behind;
	public GameObject backWall;
	public int backMax = 0;




	
	// Update is called once per frame
	void Update () {
		//behind = ((player.transform.position.x), (player.transform.position.y + 5), (player.transform.position.z - 5));
		if (camt.position.z - backWall.transform.position.z > backMax) {
			//Debug.Log (player.transform.position.z - backWall.transform.position.z);
			camt.SetPositionAndRotation (new Vector3 ((player.transform.position.x),player.transform.position.y + 6, (player.transform.position.z - 15)), new Quaternion (0, 0, 0, 0));
		} 
		if(!(camt.position.z - backWall.transform.position.z > backMax)){
			camt.SetPositionAndRotation (new Vector3 (player.transform.position.x, backWall.transform.position.y + 5, backWall.transform.position.z+1), new Quaternion (0, 0, 0, 0));
		}
	}
}
