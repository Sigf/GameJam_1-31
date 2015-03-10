using UnityEngine;
using System.Collections;

public class abilityAOE : Ability {
	float _radius;
	int _radiusLevel;
	int[] radius_array = new int[]{5,10,15,20,25};


	float _duration;
	int _durationLevel;
	int[] duration_array = new int[]{5,10,15,20,25};

	bool _lingering;

	public abilityAOE(Element new_element) : base(new_element)
	{
		_radiusLevel = 0;
		_durationLevel = 0;

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
