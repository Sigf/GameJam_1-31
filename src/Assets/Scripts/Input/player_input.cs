using UnityEngine;
using System.Collections;

public class player_input : MonoBehaviour {

	private player playerScript;
	private player_stats_UI playerUI;
	private charController2D playerController;

	public bool debug = false;

	private bool wPressed = false;
	private bool sPressed = false;
	private bool dPressed = false;
	private bool aPressed = false;

	private bool onePressed = false;
	private bool twoPressed = false;
	private bool threePressed = false;
	private bool fourPressed = false;
	private bool fivePressed = false;

	private bool f1Pressed = false;
	private bool f2Pressed = false;
	private bool f3Pressed = false;
	private bool f4Pressed = false;

	private bool mPressed = false;

	private bool atkPressed = false;

	// Use this for initialization
	void Start () {

		playerScript = gameObject.GetComponent<player> ();
		playerUI = gameObject.GetComponent<player_stats_UI> ();
		playerController = gameObject.GetComponent<charController2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		// updates states
		checkKeyStates();

		// check for wasd for movment
		handleMovment();

		// check for F keys for debug abilities
		handleFKeys();

		// check for number keys for abilities changes
		handleNumKeys();

		// check for letter keys
		handleLetterKeys();

		// check for mouse events
		handleMouseKeys();
	}

	void checkKeyStates(){

		this.wPressed = Input.GetKey (KeyCode.W);
		this.aPressed = Input.GetKey (KeyCode.A);
		this.sPressed = Input.GetKey (KeyCode.S);
		this.dPressed = Input.GetKey (KeyCode.D);

		this.onePressed = Input.GetKey (KeyCode.Alpha1);
		this.twoPressed = Input.GetKey (KeyCode.Alpha2);
		this.threePressed = Input.GetKey (KeyCode.Alpha3);
		this.fourPressed = Input.GetKey (KeyCode.Alpha4);
		this.fivePressed = Input.GetKey (KeyCode.Alpha5);

		this.f1Pressed = Input.GetKey (KeyCode.F1);
		this.f2Pressed = Input.GetKey (KeyCode.F2);
		this.f3Pressed = Input.GetKey (KeyCode.F3);
		this.f4Pressed = Input.GetKey (KeyCode.F4);

		this.atkPressed = Input.GetKey(KeyCode.Mouse0);

		this.mPressed = Input.GetKey (KeyCode.M);

	}
	void handleMovment(){

		float xForce = 1.0f;
		float yForce = 1.0f;

		if (wPressed) {
			gameObject.SendMessage("addForce", new Vector2(0.0f, yForce), SendMessageOptions.RequireReceiver);
			if (debug) Debug.Log("W pressed!");
		}

		if (aPressed) {
			gameObject.SendMessage("addForce", new Vector2(-xForce, 0.0f), SendMessageOptions.RequireReceiver);
			if (debug) Debug.Log("A pressed!");
		}

		if (sPressed) {
			gameObject.SendMessage("addForce", new Vector2(0.0f, -yForce), SendMessageOptions.RequireReceiver);
			if (debug) Debug.Log("S pressed!");
		}

		if (dPressed) {
			gameObject.SendMessage("addForce", new Vector2(xForce, 0.0f), SendMessageOptions.RequireReceiver);
			if (debug) Debug.Log("D pressed!");
		}
	}

	void handleFKeys(){
		if (f1Pressed) {
			gameObject.SendMessage("addHealth", -10, SendMessageOptions.RequireReceiver);
			if (debug) Debug.Log("F1 pressed!");
		}

		if (f2Pressed) {
			gameObject.SendMessage("addHealth", 10, SendMessageOptions.RequireReceiver);
			if (debug) Debug.Log("F2 pressed!");
		}

		if (f3Pressed) {
			gameObject.SendMessage("addNDA", -20, SendMessageOptions.RequireReceiver);
			if (debug) Debug.Log("F3 pressed!");
		}

		if (f4Pressed) {
			gameObject.SendMessage("addDNA", 20, SendMessageOptions.RequireReceiver);
			if (debug) Debug.Log("F4 pressed!");
		}
	}

	void handleNumKeys(){
		if (onePressed) {
			gameObject.SendMessage("setCurrentAbility", 0, SendMessageOptions.RequireReceiver);
			if (debug) Debug.Log("1 pressed!");
		}

		if (twoPressed) {
			gameObject.SendMessage("setCurrentAbility", 1, SendMessageOptions.RequireReceiver);
			if (debug) Debug.Log("2 pressed!");
		}

		if (threePressed) {
			gameObject.SendMessage("setCurrentAbility", 2, SendMessageOptions.RequireReceiver);
			if (debug) Debug.Log("3 pressed!");
		}

		if (fourPressed) {
			gameObject.SendMessage("setCurrentAbility", 3, SendMessageOptions.RequireReceiver);
			if (debug) Debug.Log("4 pressed!");
		}

		if (fivePressed) {
			gameObject.SendMessage("setCurrentAbility", 4, SendMessageOptions.RequireReceiver);
			if (debug) Debug.Log("5 pressed!");
		}
	}

	void handleLetterKeys(){
		if (mPressed) {
			if (debug) Debug.Log("M pressed!");
		}
	}

	void handleMouseKeys(){
		if (atkPressed) {
			if (debug) Debug.Log("Left mouse button clicked!");
		}
	}
}
