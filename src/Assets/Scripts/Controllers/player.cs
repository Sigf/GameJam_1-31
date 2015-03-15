using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public inputState _state;
	private charController2D _controller;

	private Ability[] abilities = new Ability[5];
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
		//this.abilities [3] = new abilityProjectile (Ability.Element.Electric);
		//this.abilities [4] = new abilityRay (Ability.Element.Frost);
		this.abilities [3] = null;
		this.abilities [4] = null;

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

		// toggle menu
		if (Input.GetKeyDown (KeyCode.M)) {
			this.menu_active = this.menu_active ? false : true;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		HandleInput ();
		_controller.passInput(ref _state);

	}

	void OnGUI() {
		GUI.Box (new Rect(10, 10, 160, 25), "Health: " + this.health);
		GUI.Box (new Rect(10, 35, 160, 25), "DNA: " + this.dna);
		GUI.Box (new Rect(10, 60, 160, 25), "Abilities (M to toggle)");
		if (menu_active)
		{
			for (int i = 0; i < abilities.Length; i++) 
			{
				if(abilities[i] != null){
					abilities [i].draw_status (10 + (i * 160), 85);
					displayUpdateButtons(10 + (i * 160),230, abilities[i]);
				}
				else {
					GUI.Box(new Rect(10 + (i * 160), 85, 160, 25), "--Empty--");
				}
			}
		}
		//Debug.Log (this.health);
	}

	void displayUpdateButtons(int x, int y, Ability ability)
	{
		int type = (int)ability.getType();

		int cell_height = 25;
		int cell_width = 160;

		switch(type)
		{
		case 0:

			if(GUI.Button(new Rect(x, y + (0 * cell_height), cell_width, cell_height), "Update Damage(" + ability.getDnaRequired("damage") + ")" )){
				int attempt_update = ability.upgrade(this.dna, "damage");
				if(attempt_update > -1) this.dna = attempt_update;
			}
			
			if(GUI.Button(new Rect(x, y + (1 * cell_height), cell_width, cell_height), "Update Radius(" + ability.getDnaRequired("radius") + ")" )){
				int attempt_update = ability.upgrade(this.dna, "radius");
				if(attempt_update > -1) this.dna = attempt_update;
			}
			
			if(GUI.Button(new Rect(x, y + (2 * cell_height), cell_width, cell_height), "Update Duration(" + ability.getDnaRequired("duration") + ")" )){
				int attempt_update = ability.upgrade(this.dna, "duration");
				if(attempt_update > -1) this.dna = attempt_update;
			}
			break;

		case 1:

			if(GUI.Button(new Rect(x, y + (0 * cell_height), cell_width, cell_height), "Update Damage(" + ability.getDnaRequired("damage") + ")" )){
				int attempt_update = ability.upgrade(this.dna, "damage");
				if(attempt_update > -1) this.dna = attempt_update;
			}
			
			if(GUI.Button(new Rect(x, y + (1 * cell_height), cell_width, cell_height), "Update Range(" + ability.getDnaRequired("range") + ")" )){
				int attempt_update = ability.upgrade(this.dna, "range");
				if(attempt_update > -1) this.dna = attempt_update;
			}
			
			if(GUI.Button(new Rect(x, y + (2 * cell_height), cell_width, cell_height), "Update Speed(" + ability.getDnaRequired("speed") + ")" )){
				int attempt_update = ability.upgrade(this.dna, "speed");
				if(attempt_update > -1) this.dna = attempt_update;
			}

			if(GUI.Button(new Rect(x, y + (3 * cell_height), cell_width, cell_height), "Update Projectiles(" + ability.getDnaRequired("projectiles") + ")" )){
				int attempt_update = ability.upgrade(this.dna, "projectiles");
				if(attempt_update > -1) this.dna = attempt_update;
			}
			break;

		case 2:

			if(GUI.Button(new Rect(x, y + (0 * cell_height), cell_width, cell_height), "Update Damage(" + ability.getDnaRequired("damage") + ")" )){
				int attempt_update = ability.upgrade(this.dna, "damage");
				if(attempt_update > -1) this.dna = attempt_update;
			}

			if(GUI.Button(new Rect(x, y + (1 * cell_height), cell_width, cell_height), "Update Width(" + ability.getDnaRequired("width") + ")" )){
				int attempt_update = ability.upgrade(this.dna, "width");
				if(attempt_update > -1) this.dna = attempt_update;
			}

			if(GUI.Button(new Rect(x, y + (2 * cell_height), cell_width, cell_height), "Update Duration(" + ability.getDnaRequired("duration") + ")" )){
				int attempt_update = ability.upgrade(this.dna, "duration");
				if(attempt_update > -1) this.dna = attempt_update;
			}
			break;
		}
	}
}