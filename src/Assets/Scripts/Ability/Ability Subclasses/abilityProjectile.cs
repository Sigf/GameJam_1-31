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
			GameObject newInstace = MonoBehaviour.Instantiate (_projectile, castPoint, Quaternion.identity) as GameObject;
			onCD = true;
		}
	}

	public override void Upgrade()
	{

	}
}
