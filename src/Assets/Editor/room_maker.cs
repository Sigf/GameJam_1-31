using UnityEngine;
using UnityEditor;
using System.Collections;

public class room_maker : EditorWindow {

	int height;
	int width;

	GameObject floor_tile;
	GameObject wall_tile;
	GameObject wall_corner;
	string room_name;

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
		if (GUILayout.Button ("Create Room")) {
			GameObject root = new GameObject(room_name);
			createWall(Vector3.zero, width, false, root);
			createWall(new Vector3(0.0f + (width/100), 0.0f, 0.0f), height, true, root);

		}
	}

	void createWall (Vector3 position, int length, bool vertical, GameObject root) {
		GameObject wall;

		wall = (GameObject)Instantiate(wall_corner, position + new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
		wall.transform.parent = root.transform;

		for (int i=1; i < length; i++) {
			if(vertical) {
				wall = (GameObject)Instantiate(wall_tile, position + new Vector3(0.0f, 0.08f*i, 0.0f), Quaternion.AngleAxis(90, Vector3.back));
				wall.transform.parent = root.transform;
			}
			else {
				wall = (GameObject)Instantiate(wall_tile, position + new Vector3(0.08f*i, 0.0f, 0.0f), Quaternion.identity);
				wall.transform.parent = root.transform;
			}
		}
	}

	void createFlooe (int length, int width) {

	}
}
