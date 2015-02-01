using UnityEngine;
using System.Collections;

public class follow_player : MonoBehaviour {
	public GameObject target;
	public float speed = 2.0f;
	private Vector3 old_pos;
	private Vector3 new_pos;
	private float now;
	private float old_time;
	private float length;


	// Use this for initialization
	void Start () {
		old_time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		now = Time.time;
		float dist =(now - old_time) * speed;
		length = Vector3.Distance (transform.position, target.transform.position);
		float transition_speed = dist / length;
		Vector3 initial_pos = new Vector3 (transform.position.x, transform.position.y, -10.0f);
		Vector3 final_pos = new Vector3 (target.transform.position.x, target.transform.position.y, -10.0f);
		transform.position = Vector3.Lerp (initial_pos, final_pos, transition_speed);
	}
}
