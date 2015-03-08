using UnityEngine;
using System.Collections;
using UnityEditor;

[System.Serializable]
[CustomEditor(typeof(playerStats))]
public class pickupEditor : Editor 
{
	private playerStats _stats;
	
	public override void OnInspectorGUI()
	{
	
	

		if(GUI.changed)
		{

		}
	}
}

/* This script will be used to design ability pickups
 * I think that all abilities should be hand crafted for enemies (non-procedural)
 * to keep the rooms more as actual formulated challenges rather than random chance and things
 * thrown together based on statistical chance
 * This tends to make games more interesting
 * 
 * Each room should have an "ideal" combination to victory, as well as the inverse
 * These should vary from room to room, to keep the player on their toes
 * as they never know what the coming room will throw at them
*/

