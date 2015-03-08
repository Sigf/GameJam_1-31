using UnityEngine;
using System.Collections;

public class player_attack : MonoBehaviour {

	private Animator animator;
	private int animation_time;
	private bool cooldown;
	private bool left;
	private Vector3 mousePos;
	

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		animator.SetInteger ("attacks", 0);
		cooldown = false;
		left = false;
		animation_time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if(left) animator.SetInteger ("attacks", 2);
			else animator.SetInteger ("attacks", 1);

			cooldown = true;
			left = !left;
		}

		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		float rot_z = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
	}

	void FixedUpdate() {
		if (cooldown) {
			animation_time ++;
		}

		if (animation_time >= 20) {
			cooldown = false;
			animation_time = 0;
			animator.SetInteger ("attacks", 0);
		}
	}
}
