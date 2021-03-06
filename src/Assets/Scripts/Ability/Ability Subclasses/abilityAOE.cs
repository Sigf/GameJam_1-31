﻿using UnityEngine;
using System.Collections;

/* 
 * AOE STATS TABLE (arbritary for now, is going to change with playtesting)
 * damage: 0.5, 1.5, 4.0, 9.0, 18.0
 * radius: 1.0, 1.5, 2.0, 2.5, 3.0
 * duration: 0.2, 0.4, 0.6, 0.8, 1.0
 * 
 */

public class abilityAOE : Ability {

	float[] damage_array = new float[5]{0.5f, 1.5f, 4.0f, 9.0f, 18.0f};
	float[] radius_array = new float[5]{0.4f, 0.6f, 0.8f, 1.0f, 1.2f};
	float[] duration_array = new float[5]{1.0f, 1.5f, 2.0f, 2.5f, 3.0f};

	float radius;
	int radiusLevel;

	float duration;
	int durationLevel;

	bool lingering;

	public abilityAOE(Element new_element) : base(new_element)
	{
		this.attackType = AttackType._AOE;

		this.radiusLevel = 0;
		this.durationLevel = 0;

		this.radius = radius_array [radiusLevel];
		this.duration = duration_array [durationLevel];
		this.damage = damage_array[damageLevel];

		this.lingering = false;

		if (this._debug) {
			Debug.Log ("AOE Ability instanciated!");
		}
	}

	public override void Cast(Vector3 castPoint)
	{
		if(Time.time >= cdEndTime)
		{
			GameObject newInstance = MonoBehaviour.Instantiate (Resources.Load ("AOE_Attack"), castPoint, Quaternion.identity) as GameObject;
			AOE_Attack script = newInstance.GetComponent<AOE_Attack>();
            script.init(this);
			Debug.Log("Cast called for " + this.getName());

			cdEndTime = Time.time + cdTimer;
		}
	}

	public override int upgrade(int dna_given, string type)
	{
		int dna_required;

		switch (type)
		{
		case "damage":
			dna_required = this.nextLevelXp[damageLevel];
			if (dna_given >= dna_required) {
				damageLevel += 1;
				this.damage = damage_array [damageLevel];
				return dna_given - dna_required;
			} 
			
			else {
				return -1;
			}

		case "radius":
			dna_required = this.nextLevelXp[radiusLevel];
			if (dna_given >= dna_required) {
				radiusLevel += 1;
				this.radius = radius_array [radiusLevel];
				return dna_given - dna_required;
			} 
			
			else {
				return -1;
			}

		case "duration":
			dna_required = this.nextLevelXp[durationLevel];
			if (dna_given >= dna_required) {
				durationLevel += 1;
				this.duration = duration_array [durationLevel];
				return dna_given - dna_required;
			} 
			
			else {
				return -1;
			}
		}
		return -1;
	}

	public override void draw_status(int x, int y)
	{
		int cell_height = 25;
		int cell_width = 160;

		string element_str = getElementString ();

		GUI.Box (new Rect(x, y, cell_width, cell_height), element_str + " - AOE");
		GUI.Box (new Rect(x, y + cell_height, cell_width, cell_height), "Damage(" + this.damageLevel + "): " + this.damage);
		GUI.Box (new Rect(x, y + 2*cell_height, cell_width, cell_height), "Radius(" + this.radiusLevel + "): " + this.radius);
		GUI.Box (new Rect(x, y + 3*cell_height, cell_width, cell_height), "Duration(" + this.durationLevel + "): " + this.duration);
	}

	public override int getDnaRequired(string type)
	{
		switch (type)
		{
		case "damage":
			return this.nextLevelXp[damageLevel];
		
		case "radius":
			return this.nextLevelXp[radiusLevel];

		case "duration":
			return this.nextLevelXp[durationLevel];
		}
		return -1;
	}

	public override string getName ()
	{
		return getElementString() + " - AOE";
	}

	// accessors

	public float getRadius()
	{
		return this.radius;
	}

	public int getRadiusLevel()
	{
		return this.radiusLevel;
	}

	public float getDuration()
	{
		return this.duration;
	}

	public int getDurationLevel()
	{
		return this.durationLevel;
	}

	public bool isLingering()
	{
		return this.lingering;
	}

}
