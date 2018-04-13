//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class attributes : MonoBehaviour {
//
//	//in this I will put the attributes neded and write methods for them to be accessed by other scripts. the values in here will be used when 
//	//doing processes that can be enhanced by adding uncertainty based on the strength of the attribute.
//	public int playerType;
//	public int throwPower;
//	public int throwAccuracy;
//	public int speed;
//	public int acceleration;
//	public int dodge;
//	public int catching;
//	public int tipCatch;
//	public int specialMove;
//	public int jumping;
//	public double overall;
//	//small
//	if (playerType == 1) {
//		overall = speed * 0.3 + dodge * 0.3 + accuracy * 0.1 + specialMove * 0.15 + jumping * 0.05 + tipCatch * 0.1;
//	}
//	//big
//	if(playerType == 2) {
//		overall = throwPower * .3 + speed * .1 + catching * .3 + accuracy * .2 + jumping * .05 + tipCatch * .05;
//	}
//	//balanced
//	if(playerType == 3) {
//		overall = throwPower * .15 + speed * .2 + dodge * .1 + catching * .1 + accuracy * .2 + specialMove * .10 + jumping * .05 + tipCatch * .1;
//	}
//
//	
//	// Update is called once per frame
////	void FixedUpdate () {
////		
////	}
//}
