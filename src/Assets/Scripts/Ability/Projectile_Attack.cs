using UnityEngine;
using System.Collections;

public class Projectile_Attack : MonoBehaviour {
	public Ability ability;
	private GameObject player;
	
	public GameObject projectile;

	
	void Start () {
		this.player = GameObject.Find("player_control");
	}

	void Update () {
		
	}
}
