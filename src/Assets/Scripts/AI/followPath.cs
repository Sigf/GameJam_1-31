using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class followPath : MonoBehaviour {

	public enum FollowType
	{
		MoveTowards,
		Lerp,
		OneWayMoveTowards,
		OneWayLerp,
		Circular
	}
	public FollowType type = FollowType.MoveTowards;
	public definePath path;
	public float speed = 1;
	public float maxDistanceToGoal = 0.1f;
	
	private IEnumerator<Transform> _currentPoint;
	private bool oneWay = false;
	private bool last = false;
	
	public void Start()
	{
		if (path == null) 
		{
			Debug.LogError ("Path cannot be null", gameObject);
			return;
		}
		_currentPoint = path.getPathEnumerator ();//returns value from yield statement
		_currentPoint.MoveNext (); //sends back to the enumerator
		
		if (_currentPoint.Current == null) 
		{
			return;	//if next point is null, break out of the start function
		}
		transform.position = _currentPoint.Current.position;
		if(type == FollowType.OneWayLerp || type == FollowType.OneWayMoveTowards){
			oneWay = true;
		}
	}
	public void Update()
	{
		if (_currentPoint == null || _currentPoint.Current == null || last == true) 
		{
			return;
		}
		if (type == FollowType.MoveTowards) 
		{
			transform.position = Vector3.MoveTowards (transform.position, _currentPoint.Current.position, Time.deltaTime * speed);
		}
		else if(type == FollowType.Lerp)
		{
			transform.position = Vector3.Lerp (transform.position, _currentPoint.Current.position, Time.deltaTime * speed);
		}
		else if(type == FollowType.OneWayLerp)
		{
			transform.position = Vector3.Lerp (transform.position, _currentPoint.Current.position, Time.deltaTime * speed);
		}
		else if (type == FollowType.OneWayMoveTowards){
			transform.position = Vector3.MoveTowards (transform.position, _currentPoint.Current.position, Time.deltaTime * speed);
		}
		else if(type == FollowType.Circular){
			transform.position = Vector3.MoveTowards (transform.position, _currentPoint.Current.position, Time.deltaTime * speed);
		}
		
		var distanceSquared = (transform.position - _currentPoint.Current.position).sqrMagnitude;
		if (distanceSquared < maxDistanceToGoal * maxDistanceToGoal) 
		{
			if(_currentPoint.Current == path.points[path.points.Length - 1]){
				if(oneWay == true){
					last = true;
					return;
				}
				else if(type == FollowType.Circular){
					path.Reset ();
				}
			}
			_currentPoint.MoveNext ();
			
		}
	}
}
