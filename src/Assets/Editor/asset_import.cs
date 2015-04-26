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
	private string name;
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
			name = EditorGUILayout.TextField("Name", name);
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

		if (GUILayout.Button ("Import")) {
			if(selectedType == 0){
				Object newPrefab = PrefabUtility.CreateEmptyPrefab("Assets/Prefabs/" + name + ".prefab");
				GameObject newObject = new GameObject();
				SpriteRenderer sr = newObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
				sr.sprite = singleSprite;
				BoxCollider2D bc = newObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
				PrefabUtility.ReplacePrefab(newObject, newPrefab, ReplacePrefabOptions.ConnectToPrefab);
				this.Close();
			}
			if(selectedType == 1){
                
            }
			if(selectedType == 2){
                
            }
			if(selectedType == 3){
                
            }
			if(selectedType == 4){
                
            }
			if(selectedType == 5){
                
            }


		}
	}
}
