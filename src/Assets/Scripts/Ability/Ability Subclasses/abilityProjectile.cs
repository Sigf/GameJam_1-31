using UnityEngine;
using System.Collections;

public class abilityProjectile : Ability {
	GameObject _projectile;
	int _numProjectiles;
	int _numProjectilesLevel;

	float _speed;
	int _speedLevel;

	float _range;
	int _rangeLevel;

	bool _explosive;

	bool _lingering;

	public void Start()
	{

	}

	public override void Cast(Vector3 castPoint)
	{
		if(!onCD)
		{
			if(_numProjectiles == 1){
				GameObject newInstace = MonoBehaviour.Instantiate (_projectile, castPoint, Quaternion.identity) as GameObject;
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
				 * or maybe just labeling the positions 1-8, and then having an array of castPoint would be good, so it essentially just iterates through each and passes them the info they need */
			}
		}
	}

	public override void Upgrade()
	{

	}
}
