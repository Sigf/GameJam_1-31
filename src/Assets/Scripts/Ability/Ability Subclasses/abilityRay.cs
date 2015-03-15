using UnityEngine;
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
		this.attackType = AttackType._Ray;

		this.damageLevel = 0;
		this.widthLevel = 0;
		this.durationLevel = 0;

		this.damage = damage_array [damageLevel];
		this.width = width_array [widthLevel];
		this.duration = duration_array [durationLevel];

		this.lingering = false;
		this.piercing = false;

		if (this._debug) {
			Debug.Log ("Ray Ability instanciated!");
		}
	}

	public override void Cast(Vector3 castPoint)
	{
		if(!onCD)
		{
			Debug.Log("Cast called for " + this.getName());
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
			
		case "width":
			dna_required = this.nextLevelXp[widthLevel];
			if (dna_given >= dna_required) {
				widthLevel += 1;
				this.width = width_array [widthLevel];
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
		
		GUI.Box (new Rect(x, y, cell_width, cell_height), element_str + " - Ray");
		GUI.Box (new Rect(x, y + cell_height, cell_width, cell_height), "Damage(" + this.damageLevel + "): " + this.damage);
		GUI.Box (new Rect(x, y + 2*cell_height, cell_width, cell_height), "Width(" + this.widthLevel + "): " + this.width);
		GUI.Box (new Rect(x, y + 3*cell_height, cell_width, cell_height), "Duration(" + this.durationLevel + "): " + this.duration);
	}

	public override int getDnaRequired(string type)
	{
		switch (type)
		{
		case "damage":
			return this.nextLevelXp[damageLevel];
			
		case "width":
			return this.nextLevelXp[widthLevel];
			
		case "duration":
			return this.nextLevelXp[durationLevel];
		}
		return -1;
	}

	public override string getName ()
	{
		return getElementString() + " - Ray";
	}

	// Accessors

	public float getWidth()
	{
		return this.width;
	}
	
	public int getWidthLevel()
	{
		return this.widthLevel;
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

	public bool isPiercing()
	{
		return this.piercing;
	}
}
