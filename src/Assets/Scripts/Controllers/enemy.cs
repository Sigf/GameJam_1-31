﻿using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ProcessHit(Ability hit){
		Debug.Log ("Hit by " + hit.GetType() + " and took " + hit.getDamage() + " Damage");
	}

}
