﻿using System;
using UnityEngine;
using System.Collections;

[System.Serializable] //made it serializable so that way we can use it in editor extensions and such
public abstract class Ability {

	public bool _debug = false;

	public enum Element{
		Frost,
		Poison,
		Fire,
		Electric,
		Dark
	}

	public enum AttackType{
		_AOE,
		_Projectile,
		_Ray
	}

	protected Element element;
	protected AttackType attackType;

	// xp might night to move to player class now that the player invests xp.
	//public int xp;

	// each stats of the ability have separate levels.
	//public int curLevel;

	// Static int array of required xp to invest for each levels.
	protected int[] nextLevelXp = new int[5]{10, 20, 40, 80, 160};

	protected float damage;
	protected int damageLevel = 0;

	protected float cdTimer;
	protected bool onCD;
	protected float cdEndTime;

	protected bool finalUpgrade;

	public Ability(Element new_element)
	{
		this.element = new_element;
		this.damageLevel = 0;
		this.onCD = false;
		this.finalUpgrade = false;

		if (this._debug) {
			Debug.Log ("New Ability created.");
			Debug.Log ("Element is:");
			Debug.Log (element);
		}
	}

	public string getElementString()
	{
		string element_str = "";
		
		switch (this.element) 
		{
		case Element.Frost:
			element_str = "Frost";
			break;

		case Element.Poison:
			element_str = "Poison";
			break;
		
		case Element.Fire:
			element_str = "Fire";
			break;

		case Element.Electric:
			element_str = "Electric";
			break;

		case Element.Dark:
			element_str = "Dark";
			break;
		}

		return element_str;
	}

	public abstract void Cast (Vector3 castPoint);

	public abstract int upgrade(int dna_given, string type);

	public abstract void draw_status (int x, int y);

	public abstract int getDnaRequired (string type);

	public abstract string getName ();

	// accessors

	public float getDamage()
	{
		return this.damage;
	}

	public int getDamageLevel()
	{
		return this.damageLevel;
	}

	public AttackType getType(){
		return this.attackType;
	}
}
