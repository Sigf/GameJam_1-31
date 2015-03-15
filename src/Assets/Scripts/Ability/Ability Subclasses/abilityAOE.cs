using UnityEngine;
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
	float[] radius_array = new float[5]{1.0f, 1.5f, 2.0f, 2.5f, 3.0f};
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
		if(!onCD)
		{

		}
	}

	public override void Upgrade()
	{
		
	}

	public override int updateDamage(int dna_given)
	{
		int dna_required = this.nextLevelXp[damageLevel];
		
		if (dna_given >= dna_required) {
			damageLevel += 1;
			this.damage = damage_array [damageLevel];
			return dna_given - dna_given;
		} 

		else {
			return -1;
		}
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
