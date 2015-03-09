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

	public Element element;
	public int xp;
	public int curLevel;
	public int[] nextLevelXp;
	public int dmg;
	public int dmg_lvl = 0;
	public float cdTimer;
	public bool onCD;
	public bool finalUpgrade;

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
