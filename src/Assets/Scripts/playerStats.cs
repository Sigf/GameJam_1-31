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

	// Use this for initialization
	void Start () {

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
		Debug.Log ("Current Ability is: " + curAbility.id);
	}


}
