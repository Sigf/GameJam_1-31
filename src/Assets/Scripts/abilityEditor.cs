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

			settings.dmgAmount = EditorGUILayout.IntField("Damage", settings.dmgAmount);

			settings.abilityLevel = EditorGUILayout.IntField("Level", settings.abilityLevel);

			settings.abilityInitialSpeed = EditorGUILayout.FloatField("Initial Speed", settings.abilityInitialSpeed);

			settings.abilityMaxSpeed = EditorGUILayout.FloatField("Max Speed", settings.abilityMaxSpeed);

			settings.abilityAcceleration = EditorGUILayout.FloatField("Ability Acceleration", settings.abilityAcceleration);

			settings.travelUntil = (Ability.trajectoryType)EditorGUILayout.EnumPopup ("Travel Type", settings.travelUntil);

			if(settings.travelUntil == Ability.trajectoryType.travelUntilHit){

				settings.projectileLimit = EditorGUILayout.IntField ("Projectile Limit", settings.projectileLimit);

			}

			else if(settings.travelUntil == Ability.trajectoryType.travelUntilRange){

				settings.maxRange = EditorGUILayout.FloatField("Range", settings.maxRange);

			}
			else if(settings.travelUntil == Ability.trajectoryType.travelUntilEvent){

				settings.typeEvent = (Ability.TypeEvent)EditorGUILayout.EnumPopup ("Event Type", settings.typeEvent);

			}

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
