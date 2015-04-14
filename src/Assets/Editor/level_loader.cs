using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Text;
using System.IO;

public class level_loader : EditorWindow {


	private string filePath = "";
	private string room_name;

	private GameObject floor;
	private GameObject wall;
	private GameObject corner;

	[MenuItem("Window/Load Level")]
	public static void ShowWindow() {
		EditorWindow.GetWindow (typeof(level_loader));
	}

	void OnGUI(){
		if (GUILayout.Button ("Select File")) {
			filePath = EditorUtility.OpenFilePanel("Select the .map file", "", "txt");
		}

		if (GUILayout.Button ("Load")) {
			if(filePath != ""){
				load (filePath);
			}
			else{
				Debug.Log ("no file selected");
			}
		}

		room_name = EditorGUILayout.TextField ("Name:", room_name);
		floor = (GameObject)EditorGUILayout.ObjectField ("Floor:", floor, typeof(GameObject), false);
		wall = (GameObject)EditorGUILayout.ObjectField ("Wall:", wall, typeof(GameObject), false);
		corner = (GameObject)EditorGUILayout.ObjectField ("Corner:", corner, typeof(GameObject), false);
	}

	private bool load(string file){
		Debug.Log ("Now loading " + file);
		StreamReader reader = new StreamReader (file, Encoding.Default);

		GameObject root = new GameObject(room_name);
		GameObject tile;

		using (reader) {
			string line = reader.ReadLine();
			int j = 0;
			Vector3 position;

			while(line != null){
				string[] entries = line.Split (' ');

				for(int i = 0; i < entries.Length; i++){
					position = new Vector2(0.0f + (0.16f*i), 0.0f + (0.16f * j));

					if(entries[i] == "1"){
						tile = (GameObject)Instantiate(wall, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "2"){
						tile = (GameObject)Instantiate(floor, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "3"){
						tile = (GameObject)Instantiate(corner, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}
				}

				j++;
				line = reader.ReadLine();
			}

			root.transform.localScale = new Vector3(1.0f, -1.0f, 1.0f);
		}


		return true;
	}
}
