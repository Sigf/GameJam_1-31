using UnityEngine;
using System.Collections;

public class Projectile_Attack : MonoBehaviour {
	public Ability ability;
	private GameObject player;
	private Vector2 startPos;
	private float speed;
	private float range;
	
	public SpriteRenderer projectile;
	GameObject temp;

	
	void Awake () {
		this.player = GameObject.Find("player_control");
		transform.rotation = player.transform.GetChild(0).transform.GetChild(0).transform.rotation;
		projectile = gameObject.GetComponent <SpriteRenderer>();

	}

	void Update () {
		if (ability == null)return;
		if(Mathf.Abs (Vector2.Distance(startPos, transform.position)) >= range){
			Destroy (gameObject);
		}
		transform.Translate (Vector3.up * speed * Time.deltaTime, Space.Self);

	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag.Equals ("Obstacles")){
			Destroy (gameObject);
		}
	}

	public void init(Ability ability)
	{
		startPos = transform.position;
		speed = ((abilityProjectile)ability).getSpeed ();
		range = ((abilityProjectile)ability).getRange ();

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
