using UnityEngine;
using System.Collections;

public class dna_splash : MonoBehaviour {

	public int count = 10;
	public float max_distance = 1.0f;
	public GameObject dna;

	// Use this for initialization
	void Start () {
		float x_origin = gameObject.transform.position.x;
		float y_origin = gameObject.transform.position.y;

		float rand_x = 0.0f;
		float rand_y = 0.0f;

		for (int i = 0; i < count; i++) {
			rand_x = Random.Range (-max_distance, max_distance);
			rand_y = Random.Range (-max_distance, max_distance);
			Instantiate(dna, new Vector3(x_origin + rand_x, y_origin + rand_y, 0.0f), Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
