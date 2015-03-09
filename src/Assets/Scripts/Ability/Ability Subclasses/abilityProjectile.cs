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
				cdEndTime = Time.time + cdTimer;
				onCD = true;
			}
			else
			{
				//TODO: Need to get the boxcollider width and evenly distribute the projectiles in front of the players
			}
		}
	}

	public override void Upgrade()
	{

	}
}
