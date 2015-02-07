using UnityEngine;
using System.Collections;


public class abilityClass {
	public enum dmgType{
		Physical,
		Poison,
		Frost,
		Fire,
		Water,
		Electric,
		Void,
	}
	public enum atkType{
		melee,
		ranged,
		aura
	}
	public enum healingType{
		noHealing,
		healsPlayer,
		healsMinions,
		healsAll
	}

	public int dmgAmount;
	public int abilityLevel;
	public int abilityXP;

	public float atkCooldown;
	public bool onCooldown;

	public Animation atkAnimation;

}
