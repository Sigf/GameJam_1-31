using UnityEngine;
using System.Collections;
using System.Reflection;

public class obstacleAI : MonoBehaviour {
	public Obstacle parameters;

	void Start () {

	}
	

	void Update () {
	
	}

	//Will print out all member variables of the parameters object
	void PrintStats(){
		const BindingFlags flags = /*BindingFlags.NonPublic | */BindingFlags.Public | 
			BindingFlags.Instance | BindingFlags.Static;
		FieldInfo[] fields = parameters.GetType().GetFields(flags);
		foreach (FieldInfo fieldInfo in fields)
		{
			Debug.Log("Obj: parameters" + ", Field: " + fieldInfo.Name + ": " + fieldInfo.GetValue(parameters));
		}

	}
}
