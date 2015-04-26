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
	private bool tileSet = false;
	private bool destructable = false;
	private int framesOfDestruction;
	private string name;
	private string[] types = new string[]{"Floor", "Wall", "Door", "Obstacle", "Enemy", "Playable Character"};
	private string assetPath;
	private Texture2D assetTexture;
	private TextureImporter importer;

	private Sprite singleSprite;
	private Sprite[] tileSetSprites;
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
			DisplayFloorOptions ();
		}
		if(selectedType == 1){
			DisplayWallOptions ();
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
				CreateFloorPrefab();
			}
			if(selectedType == 1){
				CreateWallPrefab ();
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

	private void DisplayFloorOptions(){
		singleSprite = (Sprite)EditorGUILayout.ObjectField("Floor Sprite", singleSprite, typeof(Sprite), false);
		name = EditorGUILayout.TextField("Name", name);
	}

	private void DisplayWallOptions(){
		name = EditorGUILayout.TextField("Name", name);
		singleSprite = (Sprite)EditorGUILayout.ObjectField("Wall Sprite", singleSprite, typeof(Sprite), false);
		destructable = EditorGUILayout.Toggle("Destructable?", destructable);


		if(destructable){
			framesOfDestruction = EditorGUILayout.IntField("How Many Frames?", framesOfDestruction);
			if(framesOfDestruction > 0 && animation.Length != framesOfDestruction){
				animation = new Sprite[framesOfDestruction];
			}
			for(int i = 0; i < framesOfDestruction; i++){
				animation[i] = (Sprite)EditorGUILayout.ObjectField("Level " + (i + 1), animation[i], typeof(Sprite), false);
				if(animation[i] != null){
					Debug.Log (animation[i].name);
				}

            }
        }
    }
    
    private void CreateFloorPrefab(){
		Object newPrefab = PrefabUtility.CreateEmptyPrefab("Assets/Prefabs/Level/Floor Tiles/" + name + ".prefab");
		GameObject newObject = new GameObject();
		SpriteRenderer sr = newObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
		sr.sprite = singleSprite;
		BoxCollider2D bc = newObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
		PrefabUtility.ReplacePrefab(newObject, newPrefab, ReplacePrefabOptions.ConnectToPrefab);
		DestroyImmediate (newObject);
        this.Close();
    }
    private void CreateWallPrefab(){
		Object newPrefab;
		if(destructable && framesOfDestruction > 0){
			string guid = AssetDatabase.CreateFolder("Assets/Prefabs/Level/Wall Tiles/Destructable", name);
			string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);
			newPrefab = PrefabUtility.CreateEmptyPrefab("Assets/Prefabs/Level/Wall Tiles/Destructable/" + name + "/" + name + ".prefab");
			GameObject newObject = new GameObject();
			SpriteRenderer sr = newObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
			sr.sprite = singleSprite;
			BoxCollider2D bc = newObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
			PrefabUtility.ReplacePrefab(newObject, newPrefab, ReplacePrefabOptions.ConnectToPrefab);
            DestroyImmediate (newObject);
			for(int i = 0; i < framesOfDestruction; i++){
				newPrefab = PrefabUtility.CreateEmptyPrefab("Assets/Prefabs/Level/Wall Tiles/Destructable/" + name + "/" + name + (i+1) + ".prefab");
				newObject = new GameObject();
				sr = newObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
				sr.sprite = animation[i];
				bc = newObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
				PrefabUtility.ReplacePrefab(newObject, newPrefab, ReplacePrefabOptions.ConnectToPrefab);
                DestroyImmediate (newObject);
            }
		}

		else{
			newPrefab = PrefabUtility.CreateEmptyPrefab("Assets/Prefabs/Level/Wall Tiles/" + name + ".prefab");
			GameObject newObject = new GameObject();
			SpriteRenderer sr = newObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
			sr.sprite = singleSprite;
			BoxCollider2D bc = newObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
			PrefabUtility.ReplacePrefab(newObject, newPrefab, ReplacePrefabOptions.ConnectToPrefab);
            DestroyImmediate (newObject);
		}

        this.Close();
    }
}
