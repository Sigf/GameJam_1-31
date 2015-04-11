﻿using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public inputState _state;
	private charController2D _controller;

	private Ability[] abilities = new Ability[5];
	private Ability equiped_ability;
	private int health;
	private int dna;

	private bool menu_active = false;
	
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
		//this.abilities [3] = null;
		//this.abilities [4] = null;

		this.equiped_ability = abilities [0];

	}
	

	// Update is called once per frame
	void Update () {


	}
	
	public int getHealth(){
		return this.health;
	}

	public int getDNA(){
		return this.dna;
	}

	public Ability[] getAbilityArray(){
		return this.abilities;
	}

	public Ability getCurrentAbility(){
		return this.equiped_ability;
	}

	public void setCurrentAbility( int choice){
		this.equiped_ability = this.abilities [choice];
	}

	public void addHealth(int value){
		this.health += value;
	}

	public void addDNA(int value){
		this.dna += value;
	}

	public void castAbility(){
		if(equiped_ability != null)equiped_ability.Cast(new Vector3(0,0,0));
		else Debug.Log ("No Skill select, normal attack.");
	}
}