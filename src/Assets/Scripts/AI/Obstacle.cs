using UnityEngine;
using System.Collections;

[System.Serializable]
public class Obstacle {
	public enum fireOn{
		timeInterval,
		onClearShot,
		onCollision
	};

	public enum aimTowards{
		front,
		player,
		fixedPoint
	};

	public float cdTime;
	public bool onCD;
	public float lastFired;

	public GameObject firePoint;
	public fireOn whenFire;
	public aimTowards whereAim;
	public Vector2 front;
	public string triggerTag;

	public float timeInterval;
	public bool isIndestructible;
	public float hp = 100;

}
