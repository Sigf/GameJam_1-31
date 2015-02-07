using UnityEngine;
using System.Collections;

public class reveal_content : MonoBehaviour {

	void Start(){
		Renderer[] renderers = GetComponentsInChildren<Renderer> ();
		foreach (Renderer r in renderers) {
			r.enabled = false;		
			}
	}

	void reveal() {
		Renderer[] renderers = GetComponentsInChildren<Renderer> ();
		foreach (Renderer r in renderers) {
			r.enabled = true;		
		}
	}
}
