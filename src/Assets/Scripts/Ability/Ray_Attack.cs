using UnityEngine;
using System.Collections;

public class Ray_Attack : MonoBehaviour {

	public Ability ability;
	private GameObject player;

	private Vector2 player_pos;
	private Vector2 mouse_pos;

	public float timeToLive;
	private float start_time = Time.time;
	private float now;

	// Use this for initialization
	void Start () {
		this.player = GameObject.Find("player_control");
	}
	
	// Update is called once per frame
	void Update () {
		if (ability == null)return;

		this.now = Time.time;

		if (this.now >= this.start_time + this.timeToLive) {
			Object.Destroy(this);
		}

		this.player_pos = this.player.transform.position;

		this.mouse_pos = Input.mousePosition;
		
		//int layer = LayerMask.NameToLayer ("Wall");
		
		this.mouse_pos = Camera.main.ScreenToWorldPoint (mouse_pos);
		
		Vector2 direction = (mouse_pos - player_pos).normalized;
		
		RaycastHit2D hit = Physics2D.Raycast(this.player_pos, direction, 10000.0f);
		
		if (hit) {
			Debug.DrawLine(this.player_pos, hit.point, Color.red, 0.0f ,false);
		}
	}
}
