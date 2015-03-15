using UnityEngine;
using System.Collections;

/* 
 * PROJECTILE STATS TABLE (arbritary for now, is going to change with playtesting)
 * damage: 2.0, 5.0, 8.0, 15.0, 30.0
 * projectiles: 1, 2, 3, 4, 5
 * range: 5.0, 10.0, 15.0, 20.0, 25.0
 * speed: 1.0, 1.5, 2.0, 2.5, 3.0
 * 
 */

public class abilityProjectile : Ability {
	GameObject projectile;

	float[] damage_array = new float[5]{2.0f, 5.0f, 8.0f, 15.0f, 30.0f};
	float[] speed_array = new float[5]{1.0f, 1.5f, 2.0f, 2.5f, 3.0f};
	float[] range_array = new float[5]{5.0f, 10.0f, 15.0f, 20.0f, 25.0f};
	int[] projectiles_array = new int[5]{1, 2, 3, 4, 5};

	float range;
	int rangeLevel;

	float speed;
	int speedLevel;

	int projectiles;
	int projectilesLevel;

	bool explosive;
	bool lingering;

	public abilityProjectile(Element new_element) : base(new_element)
	{
		this.attackType = AttackType._Projectile;

		this.rangeLevel = 0;
		this.speedLevel = 0;
		this.projectilesLevel = 0;

		this.damage = damage_array [damageLevel];
		this.range = range_array [rangeLevel];
		this.speed = speed_array [speedLevel];
		this.projectiles = projectiles_array [projectilesLevel];

		this.explosive = false;
		this.lingering = false;

		if (this._debug) {
			Debug.Log ("Projectile Ability instanciated!");
		}
	}

	public void Start()
	{

	}

	public override void Cast(Vector3 castPoint)
	{
		if(!onCD)
		{
			if(projectiles == 1){
				GameObject newInstace = MonoBehaviour.Instantiate (projectile, castPoint, Quaternion.identity) as GameObject;
				//TODO: Send message of type abilityProjectile to a setter function within the projectile


				cdEndTime = Time.time + cdTimer;
				onCD = true;
			}
			else
			{
				/*TODO: Need to get the boxcollider width and evenly distribute the projectiles in front of the players
				 * unless we want to have more interesting shapes.  I think perhaps allowing the player to choose the angles
				 * before a challenge could add another level of depth to the strategy
				 * May be a bit more difficult to implement, but not by much.  Could essentially just have an array of bools for each possible castposition from say, 1-8, that each cast would iterate through
				 * or maybe just labeling the positions 1-8, and then having an array of castPoint would be good, so it essentially just iterates through each and passes them the info they need 
				 * We could even incorporate both, perhaps have a dropdown option that lets them choose if the projectiles are unidirectional or not
				 */
			}
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
		
		GUI.Box (new Rect(x, y, cell_width, cell_height), element_str + " - Projectile");
		GUI.Box (new Rect(x, y + cell_height, cell_width, cell_height), "Damage(" + this.damageLevel + "): " + this.damage);
		GUI.Box (new Rect(x, y + 2*cell_height, cell_width, cell_height), "Range(" + this.rangeLevel + ": " + this.range);
		GUI.Box (new Rect(x, y + 3*cell_height, cell_width, cell_height), "Speed(" + this.speedLevel + "): " + this.speed);
		GUI.Box (new Rect(x, y + 4*cell_height, cell_width, cell_height), "Projectiles Count(" + this.projectilesLevel + "): " + this.projectiles);
	}

	// Accessor

	public float getRange()
	{
		return this.range;
	}
	
	public int getRangeLevel()
	{
		return this.rangeLevel;
	}

	public float getSpeed()
	{
		return this.speed;
	}
	
	public int getSpeedLevel()
	{
		return this.speedLevel;
	}

	public int getProjectiles()
	{
		return this.projectiles;
	}
	
	public int getProjectilesLevel()
	{
		return this.projectilesLevel;
	}

	public bool isExplosive()
	{
		return this.explosive;
	}

	public bool isLingering()
	{
		return this.lingering;
	}
}
