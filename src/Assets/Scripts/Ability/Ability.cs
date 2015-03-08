using System;
using UnityEngine;
using System.Collections;

[System.Serializable]
public class Ability {
	public enum Element{
		Frost,
		Poison,
		Fire,
		Electric,
		Dark
	}

	Element element;
	int xp;
	int curLevel;
	int[] nextLevelXp;
	int dmg;
	int dmg_lvl = 0;
	float cdTimer;
	bool finalUpgrade;

	public virtual void Cast()
	{

	}

	public virtual void Upgrade()
	{

	}
}
