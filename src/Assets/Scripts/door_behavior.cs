using UnityEngine;
using System.Collections;

public class door_behavior : MonoBehaviour {

	public Sprite open_spr;
	public Sprite close_spr;
	public GameObject player;
	private SpriteRenderer _renderer;

	// Use this for initialization
	void Start () {
		_renderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other){
		_renderer.sprite = open_spr;
		print ("hit!");
	}

	void OnTriggerExit (Collider other) {
		_renderer.sprite = close_spr;
		print ("bye");
	}
}
