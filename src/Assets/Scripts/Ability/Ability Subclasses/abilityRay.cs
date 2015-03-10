using UnityEngine;
using System.Collections;

public class abilityRay : Ability {
	float _width;
	int _widthLevel;

	float _duration;
	int _durationLevel;

	bool _lingering;

	bool _piercing;
	float _percentReduction;

	public abilityRay(Element new_element) : base(new_element)
	{
		Debug.Log("Ray Ability instanciated!");
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
