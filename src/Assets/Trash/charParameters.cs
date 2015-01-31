using System;
using UnityEngine;
using System.Collections;
[Serializable]
public class charParameters {
	public float acceleration;
	public float maxSpeed;
	public float atk1CD, atk2CD, atk3CD, atk4CD, atk5CD;
	public float atk1MS, atk2MS, atk3MS, atk4MS, atk5MS;


	public void setAtkCD(int atkNumber, float CD)
	{
		switch(atkNumber)
		{
		case 1:
			atk1CD = CD;
			break;
		case 2:
			atk2CD = CD;
			break;
		case 3:
			atk3CD = CD;
			break;
		case 4:
			atk4CD = CD;
			break;
		case 5:
			atk5CD = CD;
			break;
		}
	}
	public void setAtkMS(int atkNumber, float MS)
	{
		switch(atkNumber)
		{
		case 1:
			atk1MS = MS;
			break;
		case 2:
			atk2MS = MS;
			break;
		case 3:
			atk3MS = MS;
			break;
		case 4:
			atk4MS = MS;
			break;
		case 5:
			atk5MS = MS;
			break;
		}
	}

}
