using UnityEngine;
using System.Collections;

public class playerStats : Ability{
	public int hp;

	public Ability atk1{get; set;}
	public Ability atk2{get; set;}
	public Ability atk3{get; set;}
	public Ability atk4{get; set;}
	public Ability atk5{get; set;}
	public Ability curAbility{get; set;}

	// Use this for initialization
	void start () {

		hp = 100;
		atk1.resetCooldown();
		atk2.resetCooldown();
		atk3.resetCooldown();
		atk4.resetCooldown();
		atk5.resetCooldown();
		atk1.id = 1;
		atk2.id = 2;
		atk3.id = 3;
		atk4.id = 4;
		atk5.id = 5;
		curAbility.id = 1;
	
	}
	public void printCurAbility(){
		if(curAbility.id == atk1.id){
			Debug.Log ("Current Ability: Atk 1");
		}
		if(curAbility.id == atk2.id){
			Debug.Log ("Current Ability: Atk 2");
		}
		if(curAbility.id == atk3.id){
			Debug.Log ("Current Ability: Atk 3");
		}
		if(curAbility.id == atk4.id){
			Debug.Log ("Current Ability: Atk 4");
		}
		if(curAbility.id == atk5.id){
			Debug.Log ("Current Ability: Atk 5");
		}
	}

}
