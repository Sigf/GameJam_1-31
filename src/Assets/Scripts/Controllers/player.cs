using UnityEngine;
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
		if(Input.GetKeyDown (KeyCode.Mouse0)){
			_state.atkPressed = true;
			if(equiped_ability != null)equiped_ability.Cast(new Vector3(0,0,0));
			else Debug.Log ("No Skill select, normal attack.");
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
}