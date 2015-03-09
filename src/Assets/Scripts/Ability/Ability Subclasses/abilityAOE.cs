using UnityEngine;
using System.Collections;

public class abilityAOE : Ability {
	float _radius;
	int _radiusLevel;

	float _duration;
	int _durationLevel;

	bool _lingering;

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
