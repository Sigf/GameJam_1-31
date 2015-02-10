using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public inputState _state;
	private charController2D _controller;
	
	// Use this for initialization
	void Start () {
		_state = new inputState();
		_controller = GetComponent<charController2D>();
	}

	void HandleInput(){
		if(Input.GetKeyDown(KeyCode.W))
		{
			_state.wPressed = true;
		}
		else if(Input.GetKeyUp (KeyCode.W))
		{
			_state.wPressed = false;
		}
		if(Input.GetKeyDown (KeyCode.S))
		{
			_state.sPressed = true;
		}
		else if(Input.GetKeyUp (KeyCode.S))
		{
			_state.sPressed = false;
		}
		if(Input.GetKeyDown (KeyCode.D))
		{
			_state.dPressed = true;
		}
		else if(Input.GetKeyUp (KeyCode.D))
		{
			_state.dPressed = false;
		}
		if(Input.GetKeyDown (KeyCode.A))
		{
			_state.aPressed = true;
		}
		else if(Input.GetKeyUp (KeyCode.A))
		{
			_state.aPressed = false;
		}
		if(Input.GetKeyDown (KeyCode.Alpha1)){
			_state.onePressed = true;
		}
		else if(Input.GetKeyDown (KeyCode.Alpha2)){
			_state.twoPressed = true;
		}
		else if(Input.GetKeyDown (KeyCode.Alpha3)){
			_state.threePressed = true;
		}
		else if(Input.GetKeyDown (KeyCode.Alpha4)){
			_state.fourPressed = true;
		}
		else if(Input.GetKeyDown (KeyCode.Alpha5)){
			_state.fivePressed = true;
		}
		if(Input.GetKeyDown (KeyCode.Mouse0)){
			_state.atkPressed = true;
		}
		else if(Input.GetKeyUp (KeyCode.Mouse0)){
			_state.atkPressed = false;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		HandleInput ();
		_controller.passInput(ref _state);

	}
}
