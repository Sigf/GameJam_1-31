using UnityEngine;
using System.Collections;

public class playerStats : Ability{
	public int hp;

	public Ability atk1 = new Ability();
	public Ability atk2 = new Ability();
	public Ability atk3 = new Ability();
	public Ability atk4 = new Ability();
	public Ability atk5 = new Ability();
	public Ability curAbility = new Ability();


	public void loadAbilities(){
		atk1.id = 1;
		atk1.attackType = atkType.melee;
		atk2.id = 2;
		atk3.id = 3;
		atk4.id = 4;
		atk5.id = 5;
		curAbility.id = 1;

	}

	public void printCurAbility(){
		Debug.Log ("Current Ability is: " + curAbility.id);
	}

	public void setAbility(int id, Ability ability){
		if(id == 1){
			atk1 = ability;
			return;
		}
		if(id == 2){
			atk2 = ability;
			return;
		}
		if(id == 3){
			atk3 = ability;
			return;
		}
		if(id == 4){
			atk4 = ability;
			return;
		}
		if(id == 5){
			atk5 = ability;
			return;
		}

	}


}
