using UnityEngine;
using System.Collections;

public class abilityFunctions : MonoBehaviour {
	public void castAbility(Ability ability){
		if(!ability.onCooldown){
			if(ability.attackType == Ability.atkType.melee){
				processMelee (ability);
			}
			if(ability.attackType == Ability.atkType.ranged){
				processRanged (ability);
        	}
			if(ability.attackType == Ability.atkType.aura){
				processAura (ability);
			}
		}
	}

	public void processMelee(Ability ability){

	}

	public void processRanged(Ability ability){
		GameObject projectile = Instantiate (ability.attackSprite, transform.position, transform.rotation) as GameObject;
		projectile.SendMessage("setVariables", ability);

	}

	public void processAura(Ability ability){

	}
	
}
