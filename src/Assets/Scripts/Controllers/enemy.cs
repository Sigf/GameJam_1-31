using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
	public Ability _ability;
	public float hp;
	public bool isInvulnerable;

	private SpriteRenderer _sr;
	private bool onHitCD;
	private float hitCD = 0.1f;
	private float hitTime = 0.0f;
	// Use this for initialization
	void Start () {
		_sr = gameObject.GetComponent<SpriteRenderer>();
		onHitCD = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(isInvulnerable){
			return;
		}
		if(onHitCD){
			_sr.color = new Color(1.0f, 0.0f, 0.0f);
			if(Time.time - hitTime >= hitCD){
				onHitCD = false;
				_sr.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
	}

	public void ProcessHit(Ability hit){
		if(isInvulnerable){
			return;
		}
		Debug.Log ("Hit by " + hit.GetType() + " and took " + hit.getDamage() + " Damage");
		if(!onHitCD){
			hp -= hit.getDamage ();
			onHitCD = true;
			hitTime = Time.time;
			if(hp <= 0){
				Destroy (gameObject);
			}
		}
	}

}
