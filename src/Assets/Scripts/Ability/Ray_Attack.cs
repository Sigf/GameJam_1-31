using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ray_Attack : MonoBehaviour {

	public Ability ability;
	private GameObject player;

	public float timeToLive;
	public GameObject ray_sprite;
	public GameObject impact_sprite;
	private float start_time = Time.time;
	private float now;
	private float max_range;

	private List<Object> ray_body;

	// Use this for initialization
	void Start () {
		this.player = GameObject.Find("player_control");
		ray_body = new List<Object> ();
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

		draw_ray(player_pos, mouse_pos);

	}

	public void init(Ability ability, float max_range){
		this.ability = ability;
		this.max_range = max_range;
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

	private void draw_ray(Vector2 player_pos, Vector2 mouse_pos){
		Vector2 direction = (mouse_pos - player_pos).normalized;
		
		RaycastHit2D hit = Physics2D.Raycast(player_pos, direction, 1000.0f);
		
		if (hit) {
			//Debug.DrawLine(player_pos, hit.point, Color.red, 0.0f ,false);

			float ray_width = 0.08f;
			float distance = hit.distance;

			if(distance > this.max_range){
				distance = this.max_range;
				direction *= distance;
			}

			else{
				direction = (hit.point - player_pos);
			}

			int ray_sections = Mathf.CeilToInt(distance / ray_width);
			Vector2 newPos;
			float angle;

			Quaternion rotation = Quaternion.identity;

			for(int i = 0; i < ray_sections; i++){
				newPos = player_pos + ((float)i / ray_sections)*direction;

				angle = Vector3.Angle (Vector3.up, direction);
				// inverting angle if it is more than 180 degrees.
				if (player_pos.x < mouse_pos.x){
					angle *= -1.0f;
				}

				rotation = Quaternion.AngleAxis(angle, Vector3.forward);

				Object new_body = GameObject.Instantiate(this.ray_sprite, newPos, rotation);
				ray_body.Add(new_body);
			}

			Vector2 impact_pos = player_pos + direction;
			Object new_impact = GameObject.Instantiate(this.impact_sprite, impact_pos, rotation);
			ray_body.Add(new_impact);
		}
	}

	private void clear_ray(){
		foreach (Object body in ray_body) {
			Destroy(body);
		}
	}

	void OnRenderObject(){
		this.clear_ray();
	}

	void OnDestroy(){
		this.clear_ray();
	}

}
