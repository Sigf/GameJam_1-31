using System;
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

	protected Element element;

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

	public virtual void Cast(Vector3 castPoint)
	{
		if(!onCD)
		{

		}
	}

	public virtual void Upgrade()
	{

	}

	public abstract void draw_status (int x, int y);

	// accessors

	public float getDamage()
	{
		return this.damage;
	}

	public int getDamageLevel()
	{
		return this.damageLevel;
	}
}
