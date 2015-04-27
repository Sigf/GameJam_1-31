using UnityEngine;
using System.Collections;
using UnityEditor;

[System.Serializable]
[CustomEditor(typeof(obstacleAI))]
public class obstacleEditor : Editor 
{
	private bool fixedPointCreated ;
	private obstacleAI _AI;
	
	public override void OnInspectorGUI(){
		_AI = (obstacleAI)target;
		_AI.parameters.isIndestructible = EditorGUILayout.Toggle("Is Indestructable", _AI.parameters.isIndestructible);
		if(!_AI.parameters.isIndestructible){
			_AI.parameters.hp = EditorGUILayout.FloatField("HP", _AI.parameters.hp);
		}
		_AI.parameters.whenFire = (Obstacle.fireOn) EditorGUILayout.EnumPopup("Fire On", _AI.parameters.whenFire);
		if(_AI.parameters.whenFire == Obstacle.fireOn.timeInterval){
			TimeIntervalOptions();
		}
		if(_AI.parameters.whenFire == Obstacle.fireOn.onClearShot){
			OnClearShotOptions();
		}
		if(_AI.parameters.whenFire == Obstacle.fireOn.onCollision){
			_AI.parameters.triggerTag = EditorGUILayout.TextField("Trigger Tag", _AI.parameters.triggerTag);
		}


		if(_AI.parameters.whereAim == Obstacle.aimTowards.fixedPoint){
			if(_AI.transform.childCount < 1){
				CreateFixedPoint ();
			}
		}
		if(_AI.parameters.whereAim != Obstacle.aimTowards.fixedPoint){
			Transform findChild = _AI.transform.FindChild(_AI.transform.name + " Firing Point");
			if(findChild != null){
			DestroyImmediate (findChild.gameObject);
			}
		}

	}

	public void TimeIntervalOptions(){
		_AI.parameters.timeInterval = EditorGUILayout.FloatField("Time Interval", _AI.parameters.timeInterval);
		_AI.parameters.whereAim = (Obstacle.aimTowards)EditorGUILayout.EnumPopup ("Fire Towards", _AI.parameters.whereAim);
		if(_AI.parameters.whereAim == Obstacle.aimTowards.front){
			_AI.parameters.front = EditorGUILayout.Vector2Field("Front Relative To Obj", _AI.parameters.front);
		}
	}

	public void OnClearShotOptions(){
		_AI.parameters.cdTime = EditorGUILayout.FloatField("CD Time", _AI.parameters.cdTime);
		_AI.parameters.whereAim = (Obstacle.aimTowards)EditorGUILayout.EnumPopup ("Fire Towards", _AI.parameters.whereAim);
		if(_AI.parameters.whereAim == Obstacle.aimTowards.front){
			Debug.LogError ("Cannot Choose Front When Firing On Clear Shot");
			_AI.parameters.whereAim = Obstacle.aimTowards.player;
		}
	}

	public void OnCollisionOptions(){

	}

	public void CreateFixedPoint(){
		GameObject fixedPoint = new GameObject();
		fixedPoint.transform.parent = _AI.transform;
		fixedPoint.name = (_AI.transform.name + " Firing Point");
		fixedPoint.transform.position = _AI.transform.position;
	}

	public void DestroyFixedPoint(){

	}




}
