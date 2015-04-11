using UnityEngine;
using System.Collections;

public class player_stats_UI : MonoBehaviour {

	private player playerScript;

	private int player_health;
	private int player_dna;
	private Ability[] player_abilities;
	private Ability player_current_ability;

	private bool menu_active = false;
	
	void Start () {
		playerScript = gameObject.GetComponent<player> ();
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.M)) {
			this.menu_active = this.menu_active ? false : true;
		}
	}

	void OnGUI() {

		player_health = playerScript.getHealth ();
		player_dna = playerScript.getDNA ();
		player_abilities = playerScript.getAbilityArray ();
		player_current_ability = playerScript.getCurrentAbility ();


		GUI.Box (new Rect(10, 10, 160, 25), "Health: " + player_health);
		GUI.Box (new Rect(10, 35, 160, 25), "DNA: " + player_dna);
		GUI.Box (new Rect(10, 60, 160, 25), "Abilities (M to toggle)");
		
		if (player_current_ability != null) {
			GUI.Box (new Rect (170, 60, 160, 25), "Equiped: " + player_current_ability.getName ());
		} 
		else {
			GUI.Box (new Rect (170, 60, 160, 25), "No ability equiped!");
		}
		
		if (menu_active)
		{
			for (int i = 0; i < player_abilities.Length; i++) 
			{
				if(player_abilities[i] != null){
					player_abilities[i].draw_status (10 + (i * 160), 85);
					displayUpdateButtons(10 + (i * 160),230, player_abilities[i]);
				}
				else {
					GUI.Box(new Rect(10 + (i * 160), 85, 160, 25), "--Empty--");
				}
			}
		}
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
				int attempt_update = ability.upgrade(player_dna, "damage");
				if(attempt_update > -1) player_dna = attempt_update;
			}
			
			if(GUI.Button(new Rect(x, y + (1 * cell_height), cell_width, cell_height), "Update Radius(" + ability.getDnaRequired("radius") + ")" )){
				int attempt_update = ability.upgrade(player_dna, "radius");
				if(attempt_update > -1) player_dna = attempt_update;
			}
			
			if(GUI.Button(new Rect(x, y + (2 * cell_height), cell_width, cell_height), "Update Duration(" + ability.getDnaRequired("duration") + ")" )){
				int attempt_update = ability.upgrade(player_dna, "duration");
				if(attempt_update > -1) player_dna = attempt_update;
			}
			break;
			
		case 1:
			
			if(GUI.Button(new Rect(x, y + (0 * cell_height), cell_width, cell_height), "Update Damage(" + ability.getDnaRequired("damage") + ")" )){
				int attempt_update = ability.upgrade(player_dna, "damage");
				if(attempt_update > -1) player_dna = attempt_update;
			}
			
			if(GUI.Button(new Rect(x, y + (1 * cell_height), cell_width, cell_height), "Update Range(" + ability.getDnaRequired("range") + ")" )){
				int attempt_update = ability.upgrade(player_dna, "range");
				if(attempt_update > -1) player_dna = attempt_update;
			}
			
			if(GUI.Button(new Rect(x, y + (2 * cell_height), cell_width, cell_height), "Update Speed(" + ability.getDnaRequired("speed") + ")" )){
				int attempt_update = ability.upgrade(player_dna, "speed");
				if(attempt_update > -1) player_dna = attempt_update;
			}
			
			if(GUI.Button(new Rect(x, y + (3 * cell_height), cell_width, cell_height), "Update Projectiles(" + ability.getDnaRequired("projectiles") + ")" )){
				int attempt_update = ability.upgrade(player_dna, "projectiles");
				if(attempt_update > -1) player_dna = attempt_update;
			}
			break;
			
		case 2:
			
			if(GUI.Button(new Rect(x, y + (0 * cell_height), cell_width, cell_height), "Update Damage(" + ability.getDnaRequired("damage") + ")" )){
				int attempt_update = ability.upgrade(player_dna, "damage");
				if(attempt_update > -1) player_dna = attempt_update;
			}
			
			if(GUI.Button(new Rect(x, y + (1 * cell_height), cell_width, cell_height), "Update Width(" + ability.getDnaRequired("width") + ")" )){
				int attempt_update = ability.upgrade(player_dna, "width");
				if(attempt_update > -1) player_dna = attempt_update;
			}
			
			if(GUI.Button(new Rect(x, y + (2 * cell_height), cell_width, cell_height), "Update Duration(" + ability.getDnaRequired("duration") + ")" )){
				int attempt_update = ability.upgrade(player_dna, "duration");
				if(attempt_update > -1) player_dna = attempt_update;
			}
			break;
		}
	}
}
