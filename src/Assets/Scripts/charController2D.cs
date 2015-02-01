using UnityEngine;
using System.Collections;

public class charController2D : MonoBehaviour {
	private const float skinWidth = 0.02f;
	private const int totalRays = 8;
	private float _verticalDistanceBetweenRays, _horizontalDistanceBetweenRays;

	public charControllerParameters parameters;
	public controllerState State{get; private set;}
	public LayerMask wallMask;
	private Vector2 _normalizedForce;
	private Vector2 _velocity;
	private Transform _transform;
	private inputState _curState;
	private BoxCollider2D _boxCollider;
	private Vector2 _rayTopLeft;
	private Vector2 _rayBottomLeft;
	private Vector2 _rayBottomRight;

	public void Awake()
	{
		State = new controllerState();
		_velocity = _normalizedForce = new Vector2(0.0f, 0.0f);
		_transform = transform;
		_boxCollider = GetComponent<BoxCollider2D>();

		var colliderWidth = _boxCollider.size.x - (2 * skinWidth);
		_horizontalDistanceBetweenRays = colliderWidth / (totalRays - 1);

		var colliderHeight = _boxCollider.size.y - (2 * skinWidth);
		_verticalDistanceBetweenRays = colliderHeight / (totalRays - 1);
	}

	public void LateUpdate()
	{
		Move (_velocity * Time.deltaTime);
	}

	public void MoveCalculation()
	{
		if(Mathf.Abs (_normalizedForce.x) + Mathf.Abs (_normalizedForce.y) >= 2.0f){
			_normalizedForce /= 2;
		}
		_velocity.x = Mathf.Lerp (_velocity.x, _normalizedForce.x * parameters.maxSpeed, parameters.acceleration * Time.deltaTime);
		_velocity.y = Mathf.Lerp (_velocity.y, _normalizedForce.y * parameters.maxSpeed, parameters.acceleration * Time.deltaTime);

	}

	public void calculateRayOrigins()
	{
		var size = new Vector2(_boxCollider.size.x, _boxCollider.size.y)/2;
		var center = new Vector2(_boxCollider.center.x, _boxCollider.center.y)/2;

		_rayTopLeft = _transform.position + new Vector3(center.x - size.x + skinWidth, center.y + size.y - skinWidth);
		_rayBottomLeft = _transform.position + new Vector3(center.x -size.x + skinWidth, center.y - size.y + skinWidth);
		_rayBottomRight = _transform.position + new Vector3(center.x + size.x - skinWidth, center.y -size.y + skinWidth);
	}

	public void Move(Vector2 deltaMovement)
	{
		calculateRayOrigins ();
		if(Mathf.Abs(deltaMovement.x) > 0.001f){
			moveHorizontally(ref deltaMovement);
		}
		if(Mathf.Abs (deltaMovement.y) > 0.001f){
			moveVertically (ref deltaMovement);
		}
		_transform.Translate (deltaMovement, Space.Self);

		if(Time.deltaTime > 0.0f)
		{
			_velocity = deltaMovement / Time.deltaTime;
		}
		_velocity.x = Mathf.Min (_velocity.x, parameters.maxSpeed);
		_velocity.y = Mathf.Min (_velocity.y, parameters.maxSpeed);
	}

	public void moveHorizontally(ref Vector2 deltaMovement)
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
				State.isCollidingRight = true;
			}
			else
			{
				deltaMovement.x += skinWidth;
				State.isCollidingLeft = true;
			}
			if(rayDistance < skinWidth + .0001f)
			{
				break;
			}
		}
	}
	

	public void moveVertically(ref Vector2 deltaMovement)
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
				State.isCollidingAbove = true;
			}
			else
			{
				deltaMovement.y += skinWidth;
				State.isCollidingBelow = true;
			}
			if(rayDistance < skinWidth + .0001f)
			{
				break;
			}

		}
	}

	public void passInput(ref inputState state)
	{
		_curState = state;
		processInput ();
	}

	public void processInput()
	{
		_normalizedForce = new Vector2(0.0f, 0.0f);
		if(_curState.aPressed)
		{
			_normalizedForce.x -= 1.0f;
		}
		if(_curState.dPressed)
		{
			_normalizedForce.x += 1.0f;
		}
		if(_curState.wPressed)
		{
			_normalizedForce.y += 1.0f;
		}
		if(_curState.sPressed)
		{
			_normalizedForce.y -= 1.0f;
		}
		MoveCalculation ();
		
	}


}
