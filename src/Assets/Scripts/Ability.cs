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
	public enum trajectoryType{
		travelUntilHit,
		travelUntilRange,
		travelUntilEvent,
	}

	public enum eventType{
		buttonPress
	}
	public int id;
	public atkType attackType;
	public healingType healType;
	public dmgType damageType;
	public int dmgAmount;
	public int abilityLevel;
	public int healAmount;
	public int abilityXP;

	//melee information
	public float abilityWidth;
	public float abilityHeight;


	//ranged information
	public float abilityInitialSpeed;
	public float abilityAcceleration;
	public float abilityMaxSpeed;
	public float maxRange;
	public GameObject attackSprite;
	public trajectoryType travelUntil;



	//aura information



	public float atkCooldown;
	public bool onCooldown;

	public Animation atkAnimation;
	public AudioClip atkSound;

	public void resetCooldown(){
		onCooldown = false;
	}

}
