using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Text;
using System.IO;

public class level_loader : EditorWindow {


	private string filePath = "";
	private string room_name;

	private GameObject floor;

	private GameObject wall_top;
	private GameObject wall_right;
	private GameObject wall_bottom;
	private GameObject wall_left;

	private GameObject wall_outer1;
	private GameObject wall_outer2;
	private GameObject wall_outer3;
	private GameObject wall_outer4;

	private GameObject wall_inner1;
	private GameObject wall_inner2;
	private GameObject wall_inner3;
	private GameObject wall_inner4;

	private string asset_folder_path = "";
	private string prefix = "";
	private string complete_path = "";


	[MenuItem("Window/Load Level")]
	public static void ShowWindow() {
		EditorWindow.GetWindow (typeof(level_loader));
	}

	void OnGUI(){
		if (GUILayout.Button ("Select Map File")) {
			filePath = EditorUtility.OpenFilePanel("Select the .map file", "", "map");
		}

		if (GUILayout.Button ("Load")) {
			if(filePath != ""){
				loadAssets();
				load (filePath);
			}
			else{
				Debug.Log ("no file selected");
			}
		}

		room_name = EditorGUILayout.TextField ("Name:", room_name);
		prefix = EditorGUILayout.TextField ("Prefix:", prefix);

		floor = (GameObject)EditorGUILayout.ObjectField ("Floor:", floor, typeof(GameObject), false);

        asset_folder_path = EditorGUILayout.TextField("Asset sub-folder", asset_folder_path);

	}

	private void loadAssets(){
		complete_path = "Assets/Prefabs/" + asset_folder_path + "/" + prefix;
		Debug.Log("path:" + complete_path);
		if (asset_folder_path != "") {

			wall_top = AssetDatabase.LoadAssetAtPath(complete_path + "1.prefab", typeof(GameObject)) as GameObject;
			wall_right = AssetDatabase.LoadAssetAtPath(complete_path + "2.prefab", typeof(GameObject))as GameObject;
			wall_bottom = AssetDatabase.LoadAssetAtPath(complete_path + "3.prefab", typeof(GameObject))as GameObject;
			wall_left = AssetDatabase.LoadAssetAtPath(complete_path + "4.prefab", typeof(GameObject))as GameObject;
			
			wall_inner1 = AssetDatabase.LoadAssetAtPath(complete_path + "5.prefab", typeof(GameObject))as GameObject;
			wall_inner2 = AssetDatabase.LoadAssetAtPath(complete_path + "6.prefab", typeof(GameObject))as GameObject;
			wall_inner3 = AssetDatabase.LoadAssetAtPath(complete_path + "7.prefab", typeof(GameObject))as GameObject;
			wall_inner4 = AssetDatabase.LoadAssetAtPath(complete_path + "8.prefab", typeof(GameObject))as GameObject;
			
			wall_outer1 = AssetDatabase.LoadAssetAtPath(complete_path + "9.prefab", typeof(GameObject))as GameObject;
			wall_outer2 = AssetDatabase.LoadAssetAtPath(complete_path + "10.prefab", typeof(GameObject))as GameObject;
			wall_outer3 = AssetDatabase.LoadAssetAtPath(complete_path + "11.prefab", typeof(GameObject))as GameObject;
			wall_outer4 = AssetDatabase.LoadAssetAtPath(complete_path + "12.prefab", typeof(GameObject))as GameObject;
		}
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
						tile = (GameObject)Instantiate(wall_bottom, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "3"){
						tile = (GameObject)Instantiate(wall_right, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "4"){
						tile = (GameObject)Instantiate(wall_top, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "5"){
						tile = (GameObject)Instantiate(wall_left, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "6"){
						tile = (GameObject)Instantiate(wall_outer2, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "7"){
						tile = (GameObject)Instantiate(wall_outer1, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "8"){
						tile = (GameObject)Instantiate(wall_outer4, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "9"){
						tile = (GameObject)Instantiate(wall_outer3, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "A"){
						tile = (GameObject)Instantiate(wall_inner2, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "B"){
						tile = (GameObject)Instantiate(wall_inner1, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "C"){
						tile = (GameObject)Instantiate(wall_inner4, position, Quaternion.identity);
						tile.transform.parent = root.transform;
					}

					else if(entries[i] == "D"){
						tile = (GameObject)Instantiate(wall_inner3, position, Quaternion.identity);
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
