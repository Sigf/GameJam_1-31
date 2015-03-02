using System;
using UnityEngine;
using System.Collections;

[System.Serializable]
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
		buttonPress,
		time
	}

	public enum RicochetType{
		goUntilTime,
		goUntilNumHits,
		goUntilRange
	}

	public int id;
	public atkType attackType;
	public AuraType auraType;
	public dmgType damageType;
	public int dmgAmount;
	public int abilityLevel;
	public int healAmount;
	public int abilityXP = 0;
	public bool overTime;
	public float duration;
	public float increment;
	public int percentChanceDOT;

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
	public bool ricochet;
	public RicochetType ricochetType;
	public float projectileTimeLimit;
	public int projectileHitLimit;




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
