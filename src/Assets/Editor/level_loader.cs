﻿using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Text;
using System.IO;

public class level_loader : EditorWindow {


	private string filePath = "";
	private string room_name;

	private GameObject floor;
	//private GameObject wall;
	//private GameObject corner;

	private GameObject floor_top;
	private GameObject floor_right;
	private GameObject floor_bottom;
	private GameObject floor_left;

	private GameObject floor_outter1;
	private GameObject floor_outter2;
	private GameObject floor_outter3;
	private GameObject floor_outter4;

	private GameObject floor_inner1;
	private GameObject floor_inner2;
	private GameObject floor_inner3;
	private GameObject floor_inner4;


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
		//wall = (GameObject)EditorGUILayout.ObjectField ("Wall:", wall, typeof(GameObject), false);
		//corner = (GameObject)EditorGUILayout.ObjectField ("Corner:", corner, typeof(GameObject), false);

		floor_top = (GameObject)EditorGUILayout.ObjectField ("Top Wall:", floor_top, typeof(GameObject), false);
		floor_right = (GameObject)EditorGUILayout.ObjectField ("Right Wall:", floor_right, typeof(GameObject), false);
		floor_bottom = (GameObject)EditorGUILayout.ObjectField ("Bottom Wall:", floor_bottom, typeof(GameObject), false);
		floor_left = (GameObject)EditorGUILayout.ObjectField ("Left Wall:", floor_left, typeof(GameObject), false);

		GUILayout.Label ("Outter Corners", EditorStyles.boldLabel);
		floor_outter1 = (GameObject)EditorGUILayout.ObjectField ("Upper Right:", floor_outter1, typeof(GameObject), false);
		floor_outter2 = (GameObject)EditorGUILayout.ObjectField ("Lower Right:", floor_outter2, typeof(GameObject), false);
		floor_outter3 = (GameObject)EditorGUILayout.ObjectField ("Lower Left :", floor_outter3, typeof(GameObject), false);
		floor_outter4 = (GameObject)EditorGUILayout.ObjectField ("Upper Left:", floor_outter4, typeof(GameObject), false);

		GUILayout.Label ("Inner Corners", EditorStyles.boldLabel);
		floor_inner1 = (GameObject)EditorGUILayout.ObjectField ("Upper Right:", floor_inner1, typeof(GameObject), false);
		floor_inner2 = (GameObject)EditorGUILayout.ObjectField ("Lower Right:", floor_inner2, typeof(GameObject), false);
		floor_inner3 = (GameObject)EditorGUILayout.ObjectField ("Lower Left:", floor_inner3, typeof(GameObject), false);
		floor_inner4 = (GameObject)EditorGUILayout.ObjectField ("Upper Left:", floor_inner4, typeof(GameObject), false);
	}

	private bool load(string file){
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
					position = new Vector2(0.0f + (0.32f*i), 0.0f + (0.32f * j));

					if(entries[i] == "1"){
						tile = (GameObject)Instantiate(floor, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "2"){
						tile = (GameObject)Instantiate(floor_bottom, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "3"){
						tile = (GameObject)Instantiate(floor_right, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "4"){
						tile = (GameObject)Instantiate(floor_top, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "5"){
						tile = (GameObject)Instantiate(floor_left, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "6"){
						tile = (GameObject)Instantiate(floor_inner2, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "7"){
						tile = (GameObject)Instantiate(floor_inner1, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "8"){
						tile = (GameObject)Instantiate(floor_inner4, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "9"){
						tile = (GameObject)Instantiate(floor_inner3, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "A"){
						tile = (GameObject)Instantiate(floor_outter2, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "B"){
						tile = (GameObject)Instantiate(floor_outter1, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "C"){
						tile = (GameObject)Instantiate(floor_outter4, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "D"){
						tile = (GameObject)Instantiate(floor_outter3, position, Quaternion.identity);
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
