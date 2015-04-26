using UnityEngine;
using System.Collections;

public class pickup : MonoBehaviour {

	public int value = 10;
	private GameObject _player;

	// Use this for initialization
	void Start () {
		_player = GameObject.Find("player_control");
	}
	
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Player") {
			Debug.Log("hit");
			player script = _player.GetComponent<player>();
			script.addDNA(value);
			Destroy(gameObject);
		}
	}

	public int getValue(){
		return value;
	}
}
