using UnityEngine;
using System.Collections;


public class Ability {
	public enum dmgType{
		physical,
		poison,
		frost,
		fire,
		water,
		electric,
		darkmatter
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
	public float abilityWidth;
	public float abilityHeight;

	public float abilityInitialSpeed;
	public float abilityAcceleration;
	public float abilityMaxSpeed;

	public float atkCooldown;
	public bool onCooldown;

	public Animation atkAnimation;
	public AudioClip atkSound;



}
