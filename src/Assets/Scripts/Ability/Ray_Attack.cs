using UnityEngine;
using System.Collections;

public class Ray_Attack : MonoBehaviour {

	public Ability ability;
	private GameObject player;

	public float timeToLive;
	public GameObject ray_sprite;
	public GameObject impact_sprite;
	private float start_time = Time.time;
	private float now;

	// Use this for initialization
	void Start () {
		this.player = GameObject.Find("player_control");
	}
	
	// Update is called once per frame
	void Update () {
		if (ability == null)return;

		this.now = Time.time;

		if (this.now >= this.start_time + this.timeToLive) {
			Object.Destroy(this);
		}

		Vector2 player_pos = this.player.transform.position;

		Vector2 mouse_pos = Input.mousePosition;
		
		//int layer = LayerMask.NameToLayer ("Wall");
		
		mouse_pos = Camera.main.ScreenToWorldPoint (mouse_pos);

		draw_ray(player_pos, mouse_pos, 1000.0f);

	}

	public void init(Ability ability){
		this.ability = ability;
		this.timeToLive = ((abilityRay)ability).getDuration();

		string element = ability.getElementString();

		switch (element) {
		case("Fire"):
			this.ray_sprite = Resources.Load<GameObject>("ray_fire_body");
			this.impact_sprite = Resources.Load<GameObject>("ray_fire_impact");
			break;

		case("Frost"):
			this.ray_sprite = Resources.Load<GameObject>("ray_frost_body");
			this.impact_sprite = Resources.Load<GameObject>("ray_frost_impact");
			break;

		case("Poison"):
			this.ray_sprite = Resources.Load<GameObject>("ray_poison_body");
			this.impact_sprite = Resources.Load<GameObject>("ray_poison_impact");
			break;

		case("Electric"):
			this.ray_sprite = Resources.Load<GameObject>("ray_electric_body");
			this.impact_sprite = Resources.Load<GameObject>("ray_electric_impact");
			break;

		case("Dark"):
			this.ray_sprite = Resources.Load<GameObject>("ray_dark_body");
			this.impact_sprite = Resources.Load<GameObject>("ray_dark_impact");
			break;
		}
	}

	private void draw_ray(Vector2 player_pos, Vector2 mouse_pos, float max_range){
		Vector2 direction = (mouse_pos - player_pos).normalized;
		
		RaycastHit2D hit = Physics2D.Raycast(player_pos, direction, max_range);
		
		if (hit) {
			Debug.DrawLine(player_pos, hit.point, Color.red, 0.0f ,false);

			// display the sprites here

			float ray_width = 0.08f;
			float impact_width = 0.16f;

			direction = (hit.point - player_pos);

			int ray_sections = Mathf.CeilToInt(hit.distance / ray_width);
			Vector2 newPos;
			Vector3 up = new Vector3(1.0f, 0.0f, 0.0f);

			Quaternion rotation = Quaternion.identity;

			for(int i = 0; i < ray_sections; i++){
				newPos = player_pos + ((float)i / ray_sections)*direction;
				Debug.Log ((float)i / ray_sections);
				//Debug.Log(direction);
				//Debug.Log ("Player_pos: " + player_pos + "|| point_pos: " + newPos);
				rotation = Quaternion.AngleAxis(Vector3.Angle (Vector3.right, direction), Vector3.forward);
				GameObject.Instantiate(this.ray_sprite, newPos, rotation);
			}

		}
	}
}
