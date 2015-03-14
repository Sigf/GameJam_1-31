using UnityEngine;
using System.Collections;

[System.Serializable]
public class playerStats {
	public int hp;

	[HideInInspector]
	public int curAbility;


	public void loadAbilities()
	{
		curAbility = 1;
	}

	public void printCurAbility(){
		//Debug.Log ("Current Ability is: " + curAbility);
	}

	public void setAbility(int id, Ability ability){
		//abilities[id - 1] = ability;
	}


}
