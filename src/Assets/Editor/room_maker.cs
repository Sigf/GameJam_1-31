using UnityEngine;
using UnityEditor;
using System.Collections;

public class room_maker : EditorWindow {

	int height;
	int width;
	string room_name;
	bool ignore_left;
	bool ignore_top;
	bool ignore_right;
	bool ignore_bottom;

	GameObject floor_tile;
	GameObject wall_tile;
	GameObject wall_corner;

	float wall_sprite_width = 0.08f;
	float floor_sprite_width = 0.16f;

	[MenuItem("Window/Room Maker")]
	public static void ShowWindow() {
		EditorWindow.GetWindow (typeof(room_maker));
	}

	void OnGUI() {
		GUILayout.Label ("Room Settings", EditorStyles.boldLabel);
		room_name = EditorGUILayout.TextField ("Name:", room_name);
		height = EditorGUILayout.IntField ("Height:", height);
		width = EditorGUILayout.IntField ("Width:", width);
		floor_tile = (GameObject)EditorGUILayout.ObjectField ("Floor Tile:", floor_tile, typeof(GameObject), false);
		wall_tile = (GameObject)EditorGUILayout.ObjectField ("Wall Tile:", wall_tile, typeof(GameObject), false);
		wall_corner = (GameObject)EditorGUILayout.ObjectField ("Wall Corner:", wall_corner, typeof(GameObject), false);

		GUILayout.Label ("Ignore Wall", EditorStyles.boldLabel);
		ignore_left = EditorGUILayout.Toggle ("Left", ignore_left);
		ignore_right = EditorGUILayout.Toggle ("Right", ignore_right);
		ignore_top = EditorGUILayout.Toggle ("Top", ignore_top);
		ignore_bottom = EditorGUILayout.Toggle ("Bottom", ignore_bottom);

		if (GUILayout.Button ("Create Room")) {
			// create root game object to store the room
			GameObject root = new GameObject(room_name);
			root.AddComponent<reveal_content>();
			// create top wall
			if(!ignore_top) createWall(Vector3.zero, width, false, false, root);
			// create right wall
			if(!ignore_right) createWall(new Vector3(width * wall_sprite_width, 0.0f, 0.0f), height, true, false, root);
			// create bottom wall
			if(!ignore_bottom) createWall(new Vector3(width * wall_sprite_width, height * -wall_sprite_width, 0.0f), width, false, true, root);
			// create left wall
			if(!ignore_left) createWall(new Vector3(0.0f, height * -wall_sprite_width, 0.0f), height, true, true, root);
			//create floor

			int floor_height = Mathf.FloorToInt(height/2);
			int floor_width = Mathf.FloorToInt(width/2);
			createFloor(Vector3.zero, floor_width, floor_height, root);
		}
	}

	void createWall (Vector3 position, int length, bool vertical, bool go_left_or_up, GameObject root) {
		GameObject wall;

		if (vertical) {
			wall = (GameObject)Instantiate(wall_corner, position, Quaternion.identity);
			wall.transform.parent = root.transform;
			for (int i=1; i < length; i++) {
				if(go_left_or_up) {
					wall = (GameObject)Instantiate(wall_tile, position + new Vector3(0.0f, wall_sprite_width*i, 0.0f), Quaternion.AngleAxis(90, Vector3.back));
				}
				else {
					wall = (GameObject)Instantiate(wall_tile, position + new Vector3(0.0f, -wall_sprite_width*i, 0.0f), Quaternion.AngleAxis(90, Vector3.back));
				}
				wall.transform.parent = root.transform;
			}
		}

		else {
			wall = (GameObject)Instantiate(wall_corner, position, Quaternion.identity);
			wall.transform.parent = root.transform;
			for (int i=1; i < length; i++) {
				if(go_left_or_up) {
					wall = (GameObject)Instantiate(wall_tile, position + new Vector3(-wall_sprite_width*i, 0.0f, 0.0f), Quaternion.identity);
				}
				else {
					wall = (GameObject)Instantiate(wall_tile, position + new Vector3(wall_sprite_width*i, 0.0f, 0.0f), Quaternion.identity);
				}
				wall.transform.parent = root.transform;
			}
		}
	}

	void createFloor (Vector3 position, int floor_width, int floor_height, GameObject root) {
		GameObject floor;
		float offset = 0.12f;
		for(int i = 0; i < floor_width; i++) {
			for(int j = 0; j < floor_height; j++) {
				floor = (GameObject)Instantiate(floor_tile, position + new Vector3((floor_sprite_width * i) + offset, (-floor_sprite_width * j) - offset, 0.0f), Quaternion.identity);
				floor.transform.parent = root.transform;
			}
		}
	}
}
