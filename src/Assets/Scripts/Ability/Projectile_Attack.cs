using UnityEngine;
using System.Collections;

public class Projectile_Attack : MonoBehaviour {
	public Ability ability;
	private GameObject player;
	
	public SpriteRenderer projectile;
	GameObject temp;

	
	void Awake () {
		Debug.Log ("Call start");
		this.player = GameObject.Find("player_control");
		transform.rotation = player.transform.GetChild(0).transform.GetChild(0).transform.rotation;
		projectile = gameObject.GetComponent <SpriteRenderer>();

	}

	void Update () {
		if (ability == null)return;
	}

	public void init(Ability ability)
	{
		Debug.Log ("call init");
		this.ability = ability;

		string element = ability.getElementString();
		switch (element) {
		case("Fire"):
			temp = Resources.Load<GameObject>("projectile_fire");
			projectile.sprite = temp.GetComponent<SpriteRenderer>().sprite;
			break;
			
		case("Frost"):
			temp = Resources.Load<GameObject>("projectile_frost");
			projectile.sprite = temp.GetComponent<SpriteRenderer>().sprite;
            break;
			
		case("Poison"):
			temp = Resources.Load<GameObject>("projectile_poison");
			projectile.sprite = temp.GetComponent<SpriteRenderer>().sprite;
            break;
			
		case("Electric"):
			temp = Resources.Load<GameObject>("projectile_fire");
			projectile.sprite = temp.GetComponent<SpriteRenderer>().sprite;
            break;
                
        case("Dark"):
			temp = Resources.Load<GameObject>("projectile_dark");
			projectile.sprite = temp.GetComponent<SpriteRenderer>().sprite;
            break;
        }
    }
}
