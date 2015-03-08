using UnityEngine;
using System.Collections;
//Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
//This line should always be present at the top of scripts which use pathfinding
using Pathfinding;

public class AstarAI : MonoBehaviour
{
	//The point to move to
	public Transform target;
	private const float skinWidth = 0.02f;
	private const int totalRays = 8;
	private float _horizontalDistanceBetweenRays, _verticalDistanceBetweenRays;
	public LayerMask wallMask;


	private Seeker seeker;
	
	//The calculated path
	public Path path;
	
	//The AI's speed per second
	public float acceleration = 2;
	public float maxSpeed = 4;
	//The max distance from the AI to a waypoint for it to continue to the next waypoint
	public float nextWaypointDistance = 3;
	
	//The waypoint we are currently moving towards
	private int currentWaypoint = 0;

	private Vector3 lastPosition;
	private Vector3 _velocity;
	private BoxCollider2D _boxCollider;
	private Vector3 _rayTopLeft, _rayBottomLeft, _rayBottomRight;
	private bool isCollidingLeft, isCollidingRight, isCollidingAbove, isCollidingBelow;
	private float lastPathUpdate;
	private bool player;
	
	public void Start ()
	{
		seeker = GetComponent<Seeker>();
		player = true;
		lastPathUpdate = 0.0f;
		_velocity = new Vector3(0.0f, 0.0f, 0.0f);
		isCollidingLeft = isCollidingRight = isCollidingAbove = isCollidingBelow = false;
		//Start a new path to the targetPosition, return the result to the OnPathComplete function
		seeker.StartPath( transform.position, target.position, OnPathComplete );
		lastPosition = target.position;
		_boxCollider = GetComponent<BoxCollider2D>();
		
		var colliderWidth = _boxCollider.size.x - (2 * skinWidth);
		_horizontalDistanceBetweenRays = colliderWidth / (totalRays - 1);
		
		var colliderHeight = _boxCollider.size.y - (2 * skinWidth);
		_verticalDistanceBetweenRays = colliderHeight / (totalRays - 1);
	}

	public void OnPathComplete ( Path p )
	{
		//Debug.Log( "Yay, we got a path back. Did it have an error? " + p.error );
		if (!p.error)
		{
			path = p;
			//Reset the waypoint counter
			currentWaypoint = 0;
		}
	}
	
	public void FixedUpdate ()
	{
		if (path == null)
		{
			//We have no path to move after yet
			return;
		}
		
		if (currentWaypoint >= path.vectorPath.Count)
		{
			if(!player){
			//Debug.Log( "End Of Path Reached" );
			return;
			}
			else{
				seeker.StartPath( transform.position, target.position, OnPathComplete );
			}
		}
		
		//Direction to the next waypoint
		Vector3 dir = ( path.vectorPath[ currentWaypoint ] - transform.position ).normalized;
		//Debug.Log ("First dir calc: " + dir.x + ", " + dir.y);
		MoveCalculation (dir);
		
		//Check if we are close enough to the next waypoint
		//If we are, proceed to follow the next waypoint
		if(lastPosition != target.position)
		{
			if(Mathf.Abs (Vector3.Magnitude(target.position - lastPosition)) >= 0.4f){
				if(Time.time - lastPathUpdate >= 0.3f){
				seeker.StartPath( transform.position, target.position, OnPathComplete );
				lastPosition = target.position;
				lastPathUpdate = Time.time;
				}

			}
		}
		if (Vector3.Distance( transform.position, path.vectorPath[ currentWaypoint ] ) < nextWaypointDistance)
		{
			currentWaypoint++;
			return;
		}
	}

	public void MoveCalculation(Vector3 dir)
	{

		_velocity = dir;
		_velocity *= acceleration * Time.fixedDeltaTime;
		Move (_velocity);
		
	}
	
	public void calculateRayOrigins()
	{
		var size = new Vector2(_boxCollider.size.x, _boxCollider.size.y)/2;
		var center = new Vector2(_boxCollider.center.x, _boxCollider.center.y)/2;
		
		_rayTopLeft = transform.position + new Vector3(center.x - size.x + skinWidth, center.y + size.y - skinWidth);
		_rayBottomLeft = transform.position + new Vector3(center.x -size.x + skinWidth, center.y - size.y + skinWidth);
		_rayBottomRight = transform.position + new Vector3(center.x + size.x - skinWidth, center.y -size.y + skinWidth);
	}
	
	public void Move(Vector3 deltaMovement)
	{
		calculateRayOrigins ();
		float originalX = deltaMovement.x;
		float originalY = deltaMovement.y;
		//Debug.Log ("Y: at entry " + deltaMovement.y);
		if(Mathf.Abs(deltaMovement.x) > 0.001f){
			moveHorizontally(ref deltaMovement);
		}
		if(Mathf.Abs (deltaMovement.y) > 0.001f){
			//Debug.Log (deltaMovement.y);
			moveVertically (ref deltaMovement);
		}
		if(isCollidingRight && originalX > 0.0f)
		{
			deltaMovement.y = acceleration * Mathf.Sign (deltaMovement.y) * Time.fixedDeltaTime;
		}
		else if(isCollidingLeft && originalX < 0.0f){
			deltaMovement.y = acceleration * Mathf.Sign (deltaMovement.y) * Time.fixedDeltaTime;
		}
		if(isCollidingBelow && originalY < 0.0f)
		{
			deltaMovement.x = acceleration * Mathf.Sign (deltaMovement.x) * Time.fixedDeltaTime;
		}
		else if(isCollidingAbove && originalY > 0.0f)
		{
			deltaMovement.x = acceleration * Mathf.Sign (deltaMovement.x) * Time.fixedDeltaTime;;
		}

		transform.Translate (deltaMovement);
		//Debug.Log (deltaMovement.x + ", " + deltaMovement.y);
		
		if(Time.fixedDeltaTime > 0.0f)
		{
			_velocity = deltaMovement / Time.fixedDeltaTime;
		}
		_velocity.x = Mathf.Min (_velocity.x, maxSpeed);
		_velocity.y = Mathf.Min (_velocity.y, maxSpeed);
		Reset ();
	}
	
	public void moveHorizontally(ref Vector3 deltaMovement)
	{
		var isGoingRight = deltaMovement.x > 0.0f;
		var rayDistance = Mathf.Abs(deltaMovement.x) + skinWidth;
		var rayDirection = isGoingRight ? Vector2.right : -Vector2.right;
		var rayOrigin = isGoingRight ? _rayBottomRight : _rayBottomLeft;
		
		for(var i = 0; i < totalRays; i++)
		{
			var rayVector = new Vector2(rayOrigin.x, rayOrigin.y + (i * _verticalDistanceBetweenRays));
			Debug.DrawRay (rayVector, rayDirection * rayDistance, Color.red);
			
			var rayCastHit = Physics2D.Raycast (rayVector, rayDirection, rayDistance, wallMask);
			if(!rayCastHit)
			{
				continue;
			}
			deltaMovement.x = rayCastHit.point.x - rayVector.x;
			rayDistance = Mathf.Abs (deltaMovement.x);
			if(isGoingRight)
			{
				deltaMovement.x -= skinWidth;
				isCollidingRight = true;
			}
			else
			{
				deltaMovement.x += skinWidth;
				isCollidingLeft = true;
			}
			if(rayDistance < skinWidth + .0001f)
			{
				break;
			}
		}
	}
	
	
	public void moveVertically(ref Vector3 deltaMovement)
	{
		var isGoingUp = deltaMovement.y > 0;
		var rayDistance = Mathf.Abs (deltaMovement.y) + skinWidth;
		var rayDirection = isGoingUp ? Vector2.up : -Vector2.up;
		var rayOrigin = isGoingUp ? _rayTopLeft : _rayBottomLeft;
		
		for(var i = 0; i < totalRays; i++)
		{
			var rayVector = new Vector2(rayOrigin.x + (i * _horizontalDistanceBetweenRays), rayOrigin.y);
			Debug.DrawRay (rayVector, rayDirection * rayDistance, Color.red);
			
			var rayCastHit = Physics2D.Raycast(rayVector, rayDirection, rayDistance, wallMask);
			if(!rayCastHit)
			{
				continue;
			}
			deltaMovement.y = rayCastHit.point.y - rayVector.y;
			rayDistance = Mathf.Abs (deltaMovement.y);
			if(isGoingUp)
			{
				deltaMovement.y -= skinWidth;
				isCollidingAbove = true;
			}
			else
			{
				deltaMovement.y += skinWidth;
				isCollidingBelow = true;
			}
			if(rayDistance < skinWidth + .0001f)
			{
				break;
			}
			
		}
	}
	private void Reset()
	{
		isCollidingLeft = isCollidingRight = isCollidingAbove = isCollidingBelow = false;
	}
}