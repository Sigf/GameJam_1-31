using UnityEngine;
using System.Collections;
using UnityEditor;
[System.Serializable]
[CustomEditor(typeof(Ability))]

public class abilityEditor : Editor {
		public override void OnInspectorGUI ()
	{
		Ability settings = (Ability)target;

		settings.attackType = (Ability.atkType)EditorGUILayout.EnumPopup("Attack Type", settings.attackType);

		if(settings.attackType == Ability.atkType.ranged){

			settings.damageType = (Ability.dmgType)EditorGUILayout.EnumPopup("Damage Type", settings.damageType);

			settings.abilityLevel = EditorGUILayout.IntField("Level", settings.abilityLevel);

			settings.abilityInitialSpeed = EditorGUILayout.FloatField("Initial Speed", settings.abilityInitialSpeed);
			
			settings.abilityMaxSpeed = EditorGUILayout.FloatField("Max Speed", settings.abilityMaxSpeed);
			
			settings.abilityAcceleration = EditorGUILayout.FloatField("Ability Acceleration", settings.abilityAcceleration);

			settings.travelUntil = (Ability.trajectoryType)EditorGUILayout.EnumPopup ("Travel Type", settings.travelUntil);

			if(settings.travelUntil == Ability.trajectoryType.travelUntilEvent){

				settings.typeEvent = (Ability.TypeEvent) EditorGUILayout.EnumPopup ("Event Type", settings.typeEvent);

				if(settings.typeEvent == Ability.TypeEvent.time){

					settings.projectileTimeLimit = EditorGUILayout.FloatField("Time", settings.projectileTimeLimit);
		
					settings.ricochet = true;

				}

			}

			if(settings.travelUntil == Ability.trajectoryType.travelUntilHit){
				
				settings.projectileLimit = EditorGUILayout.IntField ("Projectile Limit", settings.projectileLimit);

				settings.ricochet = EditorGUILayout.Toggle("Ricochet?", settings.ricochet);

				if(settings.ricochet){

					settings.ricochetType = Ability.RicochetType.goUntilNumHits;

					settings.projectileHitLimit = EditorGUILayout.IntField("Num Hits", settings.projectileHitLimit);

				}
				
			}
			
			else if(settings.travelUntil == Ability.trajectoryType.travelUntilRange){
				
				settings.maxRange = EditorGUILayout.FloatField("Range", settings.maxRange);
				settings.ricochet = EditorGUILayout.Toggle("Ricochet?", settings.ricochet);
				
				if(settings.ricochet){
					
					settings.ricochetType = Ability.RicochetType.goUntilRange;
					
				}
				
			}

			settings.overTime = EditorGUILayout.BeginToggleGroup("Damage Over Time", settings.overTime);

			settings.dmgAmount = EditorGUILayout.IntField("   -Damage", settings.dmgAmount);

			settings.duration = EditorGUILayout.FloatField ("   -Duration", settings.duration);

			settings.duration = EditorGUILayout.FloatField ("   -Increment", settings.increment);

			settings.percentChanceDOT = EditorGUILayout.IntField("   -% Chance", settings.percentChanceDOT);

			EditorGUILayout.EndToggleGroup();


		}

		else if(settings.attackType == Ability.atkType.melee){

			settings.damageType = (Ability.dmgType)EditorGUILayout.EnumPopup("Damage Type", settings.damageType);

			settings.dmgAmount = EditorGUILayout.IntField("Damage", settings.dmgAmount);

			settings.abilityLevel = EditorGUILayout.IntField("Level", settings.abilityLevel);

		}

		else if(settings.attackType == Ability.atkType.aura){

			settings.auraType = (Ability.AuraType)EditorGUILayout.EnumPopup ("Aura Type", settings.auraType);

			settings.auraDetails = (Ability.AuraDetails)EditorGUILayout.EnumPopup ("Aura Details", settings.auraDetails);

			//conditional to open damage options
			if(settings.auraDetails == Ability.AuraDetails.damage || settings.auraDetails == Ability.AuraDetails.buffAndDamage || settings.auraDetails == Ability.AuraDetails.healingAndDamage || settings.auraDetails == Ability.AuraDetails.all){

				settings.damageType = (Ability.dmgType)EditorGUILayout.EnumPopup("Damage Type", settings.damageType);

				settings.dmgAmount = EditorGUILayout.IntField("Damage", settings.dmgAmount);

			}



		}


	}


}
