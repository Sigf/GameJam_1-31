﻿using UnityEngine;
using System.Collections;

/* 
 * RAY STATS TABLE (arbritary for now, is going to change with playtesting)
 * damage: 0.5, 1.5, 4.0, 9.0, 18.0
 * duration: 1.0, 1.5, 2.0, 2.5, 3.0
 * width: 1.0, 1.2, 1.4, 1.6, 1.8
 * 
 */

public class abilityRay : Ability {

	float[] damage_array = new float[5]{0.5f, 1.5f, 4.0f, 9.0f, 18.0f};
	float[] duration_array = new float[5]{1.0f, 1.5f, 2.0f, 2.5f, 3.0f};
	float[] width_array = new float[5]{1.0f, 1.2f, 1.4f, 1.6f, 1.8f};

	float width;
	int widthLevel;

	float duration;
	int durationLevel;

	bool lingering;
	bool piercing;

	float percentReduction;

	public abilityRay(Element new_element) : base(new_element)
	{
		this.damageLevel = 0;
		this.widthLevel = 0;
		this.durationLevel = 0;

		this.damage = damage_array [damageLevel];
		this.width = width_array [widthLevel];
		this.duration = duration_array [durationLevel];

		this.lingering = false;
		this.piercing = false;

		Debug.Log("Ray Ability instanciated!");
	}

	public override void Cast(Vector3 castPoint)
	{
		if(!onCD)
		{

		}
	}

	public override void Upgrade()
	{
		
	}
}
