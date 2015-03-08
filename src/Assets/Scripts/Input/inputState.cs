using UnityEngine;
using System.Collections;

public class inputState {
	public bool wPressed{get; set;}
	public bool sPressed{get; set;}
	public bool dPressed{get; set;}
	public bool aPressed{get; set;}
	public bool onePressed {get; set;}
	public bool twoPressed {get; set;}
	public bool threePressed {get; set;}
	public bool fourPressed {get; set;}
	public bool fivePressed {get; set;}
	public bool atkPressed {get; set;}

	public void Reset(){
		wPressed = 
			sPressed = 
				dPressed = 
				aPressed = 
				onePressed =
				twoPressed =
				threePressed =
				fourPressed =
				fivePressed =
				atkPressed =
				false;

	}

	public void ResetAtkPress(){
		onePressed =
			twoPressed =
				threePressed =
				fourPressed =
				fivePressed =
				false;
	}

	public void printState()
	{
		Debug.Log ("W: " + wPressed + "A: " + aPressed + "S: " + sPressed + "D: " + dPressed + "1: " + onePressed + "2: " + twoPressed + "3: " + threePressed + "4: " + fourPressed + "5: " + fivePressed + "Atk: " + atkPressed);
	}

}
