using UnityEngine;
using System.Collections;

public class rangedAttack : MonoBehaviour {
	private Ability _this;
	private bool abilitiesSet = false;
	private Vector2 moveAmount;


	public void setVariables(Ability ability){
		_this.abilityInitialSpeed = ability.abilityInitialSpeed;
		_this.abilityMaxSpeed = ability.abilityMaxSpeed;
		_this.abilityAcceleration = ability.abilityAcceleration;
		abilitiesSet = true;
	}


	void Update () {
		if(!abilitiesSet){
			return;
		}
		if(_this.abilityAcceleration == 0.0f){
			moveAmount = new Vector3(0.0f, _this.abilityInitialSpeed * Time.deltaTime, 0.0f);
			transform.Translate (moveAmount, Space.Self);
		}


	}

	void OnTriggerEnter(Collider other){
		Destroy (gameObject);
	}
}
