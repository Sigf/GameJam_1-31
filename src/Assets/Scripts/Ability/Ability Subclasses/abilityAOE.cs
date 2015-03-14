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

	public override void draw_status(int x, int y)
	{

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
