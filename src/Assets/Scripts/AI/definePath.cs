using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class definePath : MonoBehaviour {
	public Transform[] points;
	public enum Circular{
		No,
		Yes
	}
	public Circular circle = Circular.No;
	private int index = 0;
	private int direction = 1;
	
	
	public IEnumerator<Transform> getPathEnumerator()
	{
		//throw new NotImplementedException();
		if (points == null || points.Length < 1) 
		{
			yield break;
		}
		while (true) {
			yield return points[index];
			if(points.Length == 1)
			{
				continue;
			}
			if(index <= 0)
			{
				direction = 1;
			}
			else if(index >= points.Length - 1)
			{
				direction = -1;
			}
			index += direction;
		}
	}
	
	public void Reset(){
		index = -1;
		direction = 1;
	}
	
	
	
	public void OnDrawGizmos()
	{ //drawn into scene view of Unity
		
		if (points == null || points.Length < 2) 
		{
			return;
		}
		var _points = points.Where (t => t!= null).ToList (); //for if point is deleted
		if(_points.Count < 2){
			return;
		}
		if(circle == Circular.No){
			for (int i = 1; i < points.Length; i++) 
			{
				Gizmos.DrawLine(points[i - 1].position, points[i].position);
			}
		}
		else{
			for(int i = 1; i < points.Length; i++){
				Gizmos.DrawLine(points[i - 1].position, points[i].position);
				if(i == points.Length - 1){
					Gizmos.DrawLine(points[i].position, points[0].position);
				}
			}
		}
	}
}
