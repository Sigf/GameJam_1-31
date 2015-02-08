using System;
using UnityEngine;
using System.Collections;

public class Ability : MonoBehaviour{
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

	public enum AuraType{
		effectSelf,
		effectTeamRadius,
		effectEnemiesRadius,
		effectAllEnemies,
		effectAllTeam
	}

	public enum AuraDetails{
		healing,
		damage,
		buff,
		healingAndDamage,
		healingAndBuff,
		buffAndDamage,
		all
	}

	public enum trajectoryType{
		travelUntilHit,
		travelUntilRange,
		travelUntilEvent,
	}

	public enum TypeEvent{
		buttonPress
	}

	public int id;
	public atkType attackType;
	public AuraType auraType;
	public dmgType damageType;
	public int dmgAmount;
	public int abilityLevel;
	public int healAmount;
	public int abilityXP = 0;

	//melee information
	public float abilityWidth;
	public float abilityHeight;


	//ranged information
	public float abilityInitialSpeed;
	public float abilityAcceleration;
	public float abilityMaxSpeed;
	public float maxRange;
	public int projectileLimit;
	public GameObject attackSprite;
	public trajectoryType travelUntil;
	public TypeEvent typeEvent;




	//aura information
	public float radius;
	public AuraDetails auraDetails;


	public float atkCooldown;
	public bool onCooldown;

	public Animation atkAnimation;
	public AudioClip atkSound;

	public void resetCooldown(){
		onCooldown = false;
	}

}
