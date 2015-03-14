﻿using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public inputState _state;
	private charController2D _controller;

	private Ability[] abilities = new Ability[5];
	private int health;
	private int dna;
	
	// Use this for initialization
	void Start () {
		_state = new inputState();
		_controller = GetComponent<charController2D>();

		this.health = 100;
		this.dna = 0;

		this.abilities [0] = new abilityAOE (Ability.Element.Fire);
		this.abilities [1] = new abilityProjectile (Ability.Element.Dark);
		this.abilities [2] = new abilityRay (Ability.Element.Fire);
		this.abilities [3] = new abilityProjectile (Ability.Element.Electric);
		this.abilities [4] = new abilityRay (Ability.Element.Frost);

	}

	void HandleInput(){
		if(Input.GetKeyDown(KeyCode.W))
		{
			_state.wPressed = true;
		}
		else if(Input.GetKeyUp (KeyCode.W))
		{
			_state.wPressed = false;
		}
		if(Input.GetKeyDown (KeyCode.S))
		{
			_state.sPressed = true;
		}
		else if(Input.GetKeyUp (KeyCode.S))
		{
			_state.sPressed = false;
		}
		if(Input.GetKeyDown (KeyCode.D))
		{
			_state.dPressed = true;
		}
		else if(Input.GetKeyUp (KeyCode.D))
		{
			_state.dPressed = false;
		}
		if(Input.GetKeyDown (KeyCode.A))
		{
			_state.aPressed = true;
		}
		else if(Input.GetKeyUp (KeyCode.A))
		{
			_state.aPressed = false;
		}
		if(Input.GetKeyDown (KeyCode.Alpha1)){
			_state.onePressed = true;
		}
		else if(Input.GetKeyDown (KeyCode.Alpha2)){
			_state.twoPressed = true;
		}
		else if(Input.GetKeyDown (KeyCode.Alpha3)){
			_state.threePressed = true;
		}
		else if(Input.GetKeyDown (KeyCode.Alpha4)){
			_state.fourPressed = true;
		}
		else if(Input.GetKeyDown (KeyCode.Alpha5)){
			_state.fivePressed = true;
		}
		if(Input.GetKeyDown (KeyCode.Mouse0)){
			_state.atkPressed = true;
		}
		else if(Input.GetKeyUp (KeyCode.Mouse0)){
			_state.atkPressed = false;
		}

		// debug key strokes
		if (Input.GetKeyDown (KeyCode.F1)) {
			this.health -= 5;
		}

		if (Input.GetKeyDown (KeyCode.F2)) {
			this.health += 5;
		}

		if (Input.GetKeyDown (KeyCode.F3)) {
			this.dna -= 5;
		}

		if (Input.GetKeyDown (KeyCode.F4)) {
			this.dna += 5;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		HandleInput ();
		_controller.passInput(ref _state);

	}

	void OnGUI() {
		GUI.Box (new Rect(10, 10, 160, 20), "Health: " + this.health);
		GUI.Box (new Rect(10, 30, 160, 20), "DNA: " + this.dna);
		GUI.Box (new Rect(10, 50, 160, 20), "--Abilities--");
		for (int i = 0; i < abilities.Length; i++)
		{
			abilities[i].draw_status(10 + (i*160), 70);
		}
		//Debug.Log (this.health);
	}
}
