using System;
using UnityEngine;
using System.Collections;

[System.Serializable] //made it serializable so that way we can use it in editor extensions and such
public class Ability {

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

	protected int dmg;
	protected int dmg_lvl = 0;
	protected int[] dmg_array = new int[]{5,10,15,20,25};

	protected float cdTimer;
	protected bool onCD;
	protected float cdEndTime;

	protected bool finalUpgrade;

	public Ability(Element new_element)
	{
		element = new_element;
		Debug.Log ("New Ability created.");
		Debug.Log ("Element is:");
		Debug.Log (element);
		onCD = false;
		finalUpgrade = false;
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
}
