using UnityEngine;
using System.Collections;

public class AOE_Attack : MonoBehaviour {

	public Ability ability;
	private GameObject player;
	private float startTime;
	private float duration;
	private float radius;
	
	public SpriteRenderer aoe;
	GameObject temp;
	
	
	void Awake () {
		this.player = GameObject.Find("player_control");
		this.transform.parent = player.transform;
		transform.rotation = player.transform.GetChild(0).transform.GetChild(0).transform.rotation;
		aoe = gameObject.GetComponent <SpriteRenderer>();
		
	}

	void Update () {
		if (ability == null)return;
		if(Time.time - startTime >= duration){
			Destroy (gameObject);
		}
        
    }

	public void init(Ability ability)
	{
		startTime = Time.time;
		radius = ((abilityAOE)ability).getRadius ();
		duration = ((abilityAOE)ability).getDuration ();
		
		this.ability = ability;
		
		string element = ability.getElementString();
		switch (element) {
		case("Fire"):
			temp = Resources.Load<GameObject>("AOE_fire");
			aoe.sprite = temp.GetComponent<SpriteRenderer>().sprite;
			break;
			
		case("Frost"):
			temp = Resources.Load<GameObject>("AOE_frost");
			aoe.sprite = temp.GetComponent<SpriteRenderer>().sprite;
			break;
			
		case("Poison"):
			temp = Resources.Load<GameObject>("AOE_poison");
			aoe.sprite = temp.GetComponent<SpriteRenderer>().sprite;
			break;
			
		case("Electric"):
			temp = Resources.Load<GameObject>("AOE_fire");
			aoe.sprite = temp.GetComponent<SpriteRenderer>().sprite;
			break;
			
		case("Dark"):
			temp = Resources.Load<GameObject>("AOE_dark");
			aoe.sprite = temp.GetComponent<SpriteRenderer>().sprite;
			break;
		}
		Vector3 newScale = new Vector3(radius, radius, 0.0f);
		Debug.Log ("Radius is " + radius);
		this.transform.localScale = newScale;
	}
}
