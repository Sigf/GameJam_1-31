using UnityEngine;
using System.Collections;

[System.Serializable]
public class playerStats {
	public int hp;

	public Ability[] abilities;

	[HideInInspector]
	public int curAbility;


	public void loadAbilities()
	{
		curAbility = 1;
		//abilities [0] = new abilityAOE (Ability.Element.Fire);
		//abilities [1] = new abilityProjectile (Ability.Element.Poison);
		//abilities [2] = new abilityRay (Ability.Element.Dark);
	}

	public void printCurAbility(){
		Debug.Log ("Current Ability is: " + curAbility);
	}

	public void setAbility(int id, Ability ability){
		abilities[id - 1] = ability;
	}


}
