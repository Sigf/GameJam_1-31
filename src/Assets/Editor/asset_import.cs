using UnityEngine;
using UnityEditor;
using System.Collections;

/*
 * This tool is to streamline the import of assets as they are for the most part
 * made of the same components. It will also set the correcct resolution and filter
 * mode. It will import the sprite to the sprite folder, create a prefab of of it and
 * put it in the ressource folder. It will give the user the option to add a collider.
 */

public class asset_import : EditorWindow {

	private int selectedType = 0;
	private bool destructable = false;
	private int framesOfDestruction;
	private string[] types = new string[]{"Floor", "Wall", "Door", "Obstacle", "Enemy", "Playable Character"};
	private string assetPath;
	private Texture2D assetTexture;
	private TextureImporter importer;

	private Sprite singleSprite;
	private Sprite[] animationList;
	private Sprite[] animation;

	[MenuItem("Window/Asset Import")]
	public static void ShowWindow() {
		EditorWindow.GetWindow (typeof(asset_import));
	}

	void OnGUI(){
		GUILayout.Label ("Import Settings", EditorStyles.boldLabel);
		selectedType = EditorGUILayout.Popup("Type", selectedType, types);

		if(selectedType == 0){
			singleSprite = (Sprite)EditorGUILayout.ObjectField("Floor Sprite", singleSprite, typeof(Sprite), false);

		}
		if(selectedType == 1){
			singleSprite = (Sprite)EditorGUILayout.ObjectField("Wall Sprite", singleSprite, typeof(Sprite), false);
			destructable = EditorGUILayout.Toggle("Destructable?", destructable);
			if(destructable){
				framesOfDestruction = EditorGUILayout.IntField("How Many Frames?", framesOfDestruction);
				if(framesOfDestruction > 0){
					animation = new Sprite[framesOfDestruction];
				}
				for(int i = 0; i < framesOfDestruction; i++){
					animation[i] = (Sprite)EditorGUILayout.ObjectField("Level " + (i + 1), animation[i], typeof(Sprite), false);
                }
            }
		}
		if(selectedType == 2){
			singleSprite = (Sprite)EditorGUILayout.ObjectField("Wall Sprite", singleSprite, typeof(Sprite), false);
		}
		if(selectedType == 3){
			singleSprite = (Sprite)EditorGUILayout.ObjectField("Wall Sprite", singleSprite, typeof(Sprite), false);
		}
		if(selectedType == 4){
			singleSprite = (Sprite)EditorGUILayout.ObjectField("Wall Sprite", singleSprite, typeof(Sprite), false);
		}
		if(selectedType == 5){
			singleSprite = (Sprite)EditorGUILayout.ObjectField("Wall Sprite", singleSprite, typeof(Sprite), false);
		}

		if (GUILayout.Button ("Test")) {
			if (assetPath != "") {
				importer = AssetImporter.GetAtPath(assetPath) as TextureImporter;
				importer.mipmapEnabled = true;
				importer.isReadable = true;
				importer.maxTextureSize = 32;
				importer.filterMode = FilterMode.Point;
			}

			Debug.Log (assetPath);
		}
	}
}
