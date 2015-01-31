using UnityEngine;
using System.Collections;

public class controllerState {
	public bool isCollidingAbove{ get; set;}
	public bool isCollidingBelow{ get; set;}
	public bool isCollidingRight{get; set;}
	public bool isCollidingLeft{get; set;}
	public bool isEnteringDoor{get; set;}

	public void Reset(){
		isCollidingAbove = isCollidingBelow = isCollidingRight = isCollidingLeft = isEnteringDoor = false;

	}

}
