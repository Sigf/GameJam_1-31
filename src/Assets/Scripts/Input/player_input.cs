using UnityEngine;
using System.Collections;

public class player_input : MonoBehaviour {

	private player playerScript;
	private player_stats_UI playerUI;
	private charController2D playerController;

	// Use this for initialization
	void Start () {
		playerScript = gameObject.GetComponent<player> ();
		playerUI = gameObject.GetComponent<player_stats_UI> ();
		playerController = gameObject.GetComponent<charController2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		// check for wasd for movment

		// check for F keys for debug abilities

		// check for number keys for abilities changes
	}
}
