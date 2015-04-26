using UnityEngine;
using System.Collections;

public class player_pickup : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "pickup") {
			Debug.Log("hit");
			pickup script = coll.gameObject.GetComponent<pickup>();
			int value = script.getValue();
			this.SendMessage("addDNA", value);
			Destroy(coll.gameObject);
		}
	}
}
