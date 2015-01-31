using UnityEngine;
using System.Collections;

public class charController : MonoBehaviour {
	public charParameters Parameters;
	private inputState _state;
	private CharacterController _controller;
	private Vector3 _velocity;
	private Vector3 _normalizedMovement;
	private float _acceleration;
	private float _maxSpeed;

	// Use this for initialization
	void Start () 
	{
		_state = new inputState();
		_controller = GetComponent <CharacterController>();
		_velocity = new Vector3(0.0f, 0.0f, 0.0f);
		_normalizedMovement = new Vector3(0.0f, 0.0f, 0.0f);
		_acceleration = Parameters.acceleration;
		_maxSpeed = Parameters.maxSpeed;
	}
	
	// Update is called once per frame
	void Update () 
	{
		HandleInput ();
		calculateMovement ();

	}


	void LateUpdate()
	{
		_velocity.x = Mathf.Min (_velocity.x, _maxSpeed);
		_velocity.y = Mathf.Min (_velocity.y, _maxSpeed);
		_controller.Move (_velocity * Time.deltaTime);
	}

	private void calculateMovement()
	{
		if(Mathf.Abs (_normalizedMovement.x) + Mathf.Abs(_normalizedMovement.y) >= 2.0f)
		{
			_normalizedMovement /= 2;
		}
		
		_velocity.x = Mathf.Lerp(_velocity.x, _normalizedMovement.x * _maxSpeed, _acceleration * Time.deltaTime);
		_velocity.y = Mathf.Lerp(_velocity.y, _normalizedMovement.y * _maxSpeed, _acceleration * Time.deltaTime);
	}

	private void HandleInput()
	{
		if(Input.GetKeyDown(KeyCode.W))
		{
			_state.wPressed = true;

		}
		else if(Input.GetKeyUp (KeyCode.W))
		{
			_state.wPressed = false;

		}
		if(Input.GetKeyDown(KeyCode.A))
		{
			_state.aPressed = true;

		}
		else if(Input.GetKeyUp (KeyCode.A))
		{
			_state.aPressed = false;

		}
		if(Input.GetKeyDown(KeyCode.S))
		{
			_state.sPressed = true;

		}
		else if(Input.GetKeyUp (KeyCode.S))
		{
			_state.sPressed = false;

		}
		if(Input.GetKeyDown(KeyCode.D))
		{
			_state.dPressed = true;

		}
		else if(Input.GetKeyUp (KeyCode.D))
		{
			_state.dPressed = false;

		}
		ProcessInput();


	}
	private void ProcessInput()
	{
		_normalizedMovement = new Vector3(0.0f, 0.0f, 0.0f);
		if(_state.wPressed)
		{
			_normalizedMovement.y += 1.0f;
		}
		if(_state.aPressed)
		{
			_normalizedMovement.x -= 1.0f;
		}
		if(_state.sPressed)
		{
			_normalizedMovement.y -= 1.0f;
		}
		if(_state.dPressed)
		{
			_normalizedMovement.x += 1.0f;
		}
	}

}
