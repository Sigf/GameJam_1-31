using UnityEngine;
using System.Collections;

public class follow_mouse : MonoBehaviour {

	private Vector3 mousePos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = mousePos;
	}
}
