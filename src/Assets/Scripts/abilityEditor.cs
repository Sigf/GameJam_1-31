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
